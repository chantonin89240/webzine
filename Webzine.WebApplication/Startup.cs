namespace Webzine.WebApplication
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Npgsql.EntityFrameworkCore.PostgreSQL;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    using NLog;
    using NLog.Web;
    using Webzine.EntitiesContext;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;
    using Webzine.Services;

    public static class Startup
    {
        public static string dataSetting;
        public static string sgbd;

        public static ILogger logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

        /// <summary>
        /// Méthode d'initialisation de l'application
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Application configurer prête à être lancer</returns>
        public static WebApplication Initialize(string [] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            var keywordsResearchApi = builder.Configuration.GetSection("Configuration").GetSection("KeywordSearchApiDeezer").Get<List<string>>();
            var resetDb = builder.Configuration.GetSection("Configuration").GetSection("ResetDb").Get<string>();

            if(dataSetting == "Database" || dataSetting == "LocalWithDatabase")
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    
                    try
                    {
                        logger.Debug("Contruction DbContext.");
                        var webzineDbContext = services.GetRequiredService<WebzineDbContext>();
                        logger.Debug("DbContext construit.");
                        // Supprime et cr�e la base de donn�es
                        if(resetDb == "on")
                        {
                            logger.Debug("Suppression de la base de données existante.");
                            webzineDbContext.Database.EnsureDeleted();
                            logger.Debug("Base de données supprimée.");
                            logger.Debug("Création de la base de données.");
                            webzineDbContext.Database.EnsureCreated();
                            logger.Debug("Base de données créée.");
                        }
                        
                        // Initialisation de la base de donn�es
                        switch (dataSetting)
                        {
                            case "Database":
                                if(resetDb == "on")
                                {
                                    logger.Debug("Initialisation Db avec l'API Deezer.");
                                    SeedDataApiDeezer.InitializeData(webzineDbContext, keywordsResearchApi);
                                    logger.Debug("Startup.cs - Initialisation Db à partie de l'API deezer complete.");
                                }
                                break;
                            case "LocalWithDatabase":
                                logger.Debug("Initialisation Db avec Local Repository.");
                                SeedDataLocal.InitialisationDB(webzineDbContext);
                                logger.Debug("Initialisation Db avec Local Repository complete.");
                                break;
                            default:
                                // Si il y a une erreur elle sera déjà remonter dans ConfigureServices();
                                break;
                        }
                        
                    }
                    catch (Exception e)
                    {
                        ILogger<Program> log = services.GetRequiredService<ILogger<Program>>();
                        log.LogError(e, "Une erreur est survenue dans le processus d'initialisation de la base de données.");
                    }   
                }
            }
            else if(dataSetting == "Local")
            {
                // Log Data Factory direct
                logger.Debug("Configuration Local Repository sans Db.");
            }
            else
            {
                // Log erreur configuration
                logger.Debug("Erreur configuration DataRepository");
            }

            Configure(app);

            return app;
        }

        /// <summary>
        /// Configuration des services du conteneur
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            logger.Debug("Début de la configuration des services.");

            dataSetting = builder.Configuration.GetSection("Configuration").GetValue<string>("DataRepository");
            sgbd = builder.Configuration.GetSection("Configuration").GetValue<string>("SGBD");

            // NLog: Setup NLog for Dependency injection
            // problème au lancement de l'app, l'app bloque en mode debug, et bloque sur le chargement de la config dans launchsettings.json en mode no debug
            // builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

            // Ajout des services dans le conteneur
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation()
                .AddMvcOptions(options =>
                    {
                        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                            _ => "Veuillez choisir une date.");
                    });

            // Définition du comportement de la création de champs type Datetime dans PostgreSQL (timestamp)
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Entities Context
            builder.Services.AddDbContext<WebzineDbContext>(
                options =>
                {
                    switch (sgbd)
                    {
                        case "PostgreSql":
                            options.UseNpgsql(builder.Configuration.GetConnectionString("WebzineDbPostgreSql"));
                            break;
                        case "SQLite":
                            options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbSqlite"));
                            break;
                        case "SqlServer":
                            options.UseSqlServer(builder.Configuration.GetConnectionString("WebzineDbSQLServer"));
                            break;
                        default:
                            // log erreur configuration type SGBDR
                            logger.Debug("La configuration de SGBD dans appsettings.json n'est pas correcte");
                            throw new NotImplementedException();
                            break;
                    }
                }
            );

            // Repository
            if(dataSetting == "Database")
            {
                builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
                builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
                builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
                builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
            }
            else if(dataSetting == "Local" || dataSetting == "LocalWithDatabase")
            {
                builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
                builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
                builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();
                builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
            }
            else
            {
                // log erreur configuration type de données
                logger.Debug("La configuration de DataRepository dans appsettings.json n'est pas correcte");
                throw new NotImplementedException();
            }

            // Bussiness Logic Layer
            builder.Services.AddScoped<IModeratorServices, ModeratorServices>();
        }

        /// <summary>
        /// Configuration de redirection des requête HTTP 
        /// Configuration des chemins des fichiers staiques vers wwwroot
        /// Configuration du routing
        /// </summary>
        /// <param name="app"></param>
        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Route admin action post form
                endpoints.MapControllerRoute(
                    name: "delete",
                    pattern: "{area:exists}/{controller=Home}/delete/{id?}",
                    defaults: new { action = "delete" });
                endpoints.MapControllerRoute(
                    name: "edit",
                    pattern: "{area:exists}/{controller=Home}/edit/{id:int}",
                    defaults: new { action = "edit" });

                // Route admin action get
                endpoints.MapControllerRoute(
                    name: "admin deletion",
                    pattern: "{area:exists}/{controller=Home}/delete/{id:int}",
                    defaults: new { action = "suppression" });
                endpoints.MapControllerRoute(
                    name: "admin edition",
                    pattern: "{area:exists}/{controller=Home}/edit/{id:int}",
                    defaults: new { action = "edit" });

                endpoints.MapControllerRoute(
                    name: "create",
                    pattern: "{area:exists}/{controller=Home}/create",
                    defaults: new { action = "create" });
                endpoints.MapControllerRoute(
                    name: "admin creation",
                    pattern: "{area:exists}/{controller=Home}/create",
                    defaults: new { action = "creation" });

                // Page pour les titres avec un style
                endpoints.MapControllerRoute(
                    name: "TitreStyle",
                    pattern: "titre/style/{nomStyle}",
                    defaults: new { controller = "Titre", action = "TitresStyle" });

                // Route admin index
                endpoints.MapControllerRoute(
                    name: "adminCommentIndex",
                    pattern: "/administration/commentaires",
                    defaults: new { area = "administration", controller = "commentaire", action = "index" });
                endpoints.MapControllerRoute(
                    name: "adminArtisteIndex",
                    pattern: "/administration/artistes",
                    defaults: new { area = "administration", controller = "artiste", action = "index" });
                endpoints.MapControllerRoute(
                    name: "adminStyleIndex",
                    pattern: "/administration/styles",
                    defaults: new { area = "administration", controller = "style", action = "index" });
                endpoints.MapControllerRoute(
                    name: "adminTitreIndex",
                    pattern: "/administration/titres",
                    defaults: new { area = "administration", controller = "titre", action = "index" });

                // Routes menant sur la webzine de base (hors administration)


                // Page pour un artiste
                endpoints.MapControllerRoute(
                    name: "artiste",                                // PARTIE POUR ARTISTE! décommenter ne fois qu'il prend un nom (string)
                    pattern: "artiste/{nomArtiste}",
                    defaults: new { controller = "Artiste", action = "Artiste" });

                /*                                  prépa bonus
                 * endpoints.MapControllerRoute(
                    name: "titre",
                    pattern: "titre/{idTitre:int}/{nomArtiste}/{nomTitre}",
                    defaults: new { controller = "titre", action = "titre" });
                 */

                // Page pour un article sur un titre
                endpoints.MapControllerRoute(
                    name: "titre",
                    pattern: "titre/{idTitre:int}",
                    defaults: new { controller = "titre", action = "titre" });

                //Liker un titre
                endpoints.MapControllerRoute(
                    name: "Liker Titre",
                    pattern: "titre/liker",
                    defaults: new { controller = "titre", action = "Liker" });

                // Commenter un titre
                endpoints.MapControllerRoute(
                    name: "Commenter Titre",
                    pattern: "titre/commenter",
                    defaults: new { controller = "commentaire", action = "index" });

                // Page d'acceuil
                endpoints.MapControllerRoute(
                    name: "accueil",
                    pattern: "page/{pageNumber}",
                    defaults: new { controller = "home", action = "index" });

                // Page Recherches
                endpoints.MapControllerRoute(
                    name: "Recherche",
                    pattern: "recherche",
                    defaults: new { area="", controller = "Recherche", action = "Index" });

                // Page Contacts
                endpoints.MapControllerRoute(
                    name: "contact",
                    pattern: "contact",
                    defaults: new { controller = "contact", action = "contact" });

                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}