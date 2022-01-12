namespace Webzine.WebApplication
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Npgsql.EntityFrameworkCore.PostgreSQL;
    using Microsoft.Extensions.Configuration;
    using NLog.Web;
    using Webzine.EntitiesContext;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;

    public static class Startup
    {
        public static string dataPath;
        public static string sgbd;
        public static WebApplication Initialize(string [] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var webzineDbContext = services.GetRequiredService<WebzineDbContext>();

                    // Supprime et cr�e la base de donn�es
                    webzineDbContext.Database.EnsureDeleted();
                    webzineDbContext.Database.EnsureCreated();

                    // Initialisation de la base de donn�es
                    if(dataPath == "Database")
                    {
                        SeedDataLocal.InitialisationDB(webzineDbContext);
                    }
                    else
                    {

                    }

                }
                catch (Exception e)
                {
                    var log = services.GetRequiredService<ILogger<Program>>();
                    log.LogError(e, "An error occurred seeding the DB.");
                }
            }

            Configure(app);

            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            dataPath = builder.Configuration.GetValue<string>("DataRepository");
            sgbd = builder.Configuration.GetValue<string>("SGBD");

            // NLog: Setup NLog for Dependency injection
            // problème au lancement de l'app, l'app bloque en mode debug, et bloque sur le chargement de la config dans launchsettings.json en mode no debug
            // builder.Logging.ClearProviders(); 
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();            

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            if(dataPath == "Database")
            {
                builder.Services.AddDbContext<WebzineDbContext>(
                
                    options => {
                        switch (sgbd)
                        {
                            case "PostgreSql":
                                options.UseNpgsql(builder.Configuration.GetConnectionString("WebzineDbPostgreSql"));
                                break;
                            case "Sqlite":
                                options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbSqlite"));
                                break;
                            case "SqlServer":
                                options.UseSqlServer(builder.Configuration.GetConnectionString("WebzineDbSQLServer"));
                                break;
                            default:
                                break;
                        }
                    }
                );
                
                builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
                builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
                builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
                builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
            }
            else
            {
                builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
                builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
                builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();
                builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
            }


            
        }

        public static void Configure(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Route admin action post form
                endpoints.MapControllerRoute(
                    name: "create",
                    pattern: "{area:exists}/{controller=Home}/create",
                    defaults: new { action = "create" });
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
                    name: "admin creation",
                    pattern: "{area:exists}/{controller=Home}/create",
                    defaults: new { action = "creation" });
                endpoints.MapControllerRoute(
                    name: "admin deletion",
                    pattern: "{area:exists}/{controller=Home}/delete/{id:int}",
                    defaults: new { action = "suppression" });
                endpoints.MapControllerRoute(
                    name: "admin edition",
                    pattern: "{area:exists}/{controller=Home}/edit/{id:int}",
                    defaults: new { action = "edit" });

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

                // Route base 
                endpoints.MapControllerRoute(
                    name: "contact",
                    pattern: "contact",
                    defaults: new { controller = "contact", action = "contact" });
                //endpoints.MapControllerRoute(
                //    name: "artiste",                                // PARTIE POUR ARTISTE! décommenter ne fois qu'il prend un nom (string)
                //    pattern: "artiste/{nomArtiste}",
                //    defaults: new { controller = "Artiste", action = "Artiste" });
                endpoints.MapControllerRoute(
                    name: "titre",
                    pattern: "titre/{id:int}",
                    defaults: new { controller = "titre", action = "titre" });
                //endpoints.MapControllerRoute(
                //    name: "TitreStyle",                             // PARTIE POUR TITRE-STYLE! Décommenter une fois qu'il prend un nom de style (string).
                //    pattern: "titre/style/{nomStyle}",
                //    defaults: new { controller="Titre", action="TitresStyle" });
                // ///////////////////// //
                // **TODO POST METHODS** //
                // ///////////////////// //
                endpoints.MapControllerRoute(
                    name: "accueil",
                    pattern: "page/{id}",
                    defaults: new { controller = "home", action = "index" });
                
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