namespace Webzine.WebApplication
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using NLog;
    using NLog.Web;
    using Webzine.EntitiesContext;
    using Webzine.Repository;
    using Webzine.Repository.Contracts;

    public static class Startup
    {
        public static WebApplication Initialize(string [] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);

            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var webzineDbContext = services.GetRequiredService<WebzineDbContext>();

                    // Supprime et cr�e la base de donn�es
                    webzineDbContext.Database.EnsureDeleted();
                    webzineDbContext.Database.EnsureCreated();

                    // Migration de la DB à voir
                    // services.GetService<DbTitreRepository>().Database.Migrate();
                    // Initialisation de la base de donn�es
                    SeedDataLocal.InitialisationDB(webzineDbContext);
                }
                catch (Exception e)
                {
                    var log = services.GetRequiredService<ILogger<Program>>();
                    log.LogError(e, "An error occurred seeding the DB.");
                }
            }

            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            // NLog: Setup NLog for Dependency injection
            // problème au lancement de l'app, l'app bloque en mode debug, et bloque sur le chargement de la config dans launchsettings.json en mode no debug
            // builder.Logging.ClearProviders(); 
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
 
            builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
            builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
            builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
            builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();

            builder.Services.AddDbContext<WebzineDbContext>(
                options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
            );
        }

        public static void Configure(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Route admin action form
                endpoints.MapControllerRoute(
                    name: "admin creation",
                    pattern: "{area:exists}/{controller=Home}/create",
                    defaults: new { action = "CreateAsk" });
                endpoints.MapControllerRoute(
                    name: "admin deletion",
                    pattern: "{area:exists}/{controller=Home}/delete/{id:int}",
                    defaults: new { action = "DeleteAsk" });
                endpoints.MapControllerRoute(
                    name: "admin edition",
                    pattern: "{area:exists}/{controller=Home}/edit/{id:int}",
                    defaults: new { action = "Edit" });
                // Route admin action form
                endpoints.MapControllerRoute(
                    name: "admin creation",
                    pattern: "{area:exists}/{controller=Home}/create",
                    defaults: new { action = "creation" });
                endpoints.MapControllerRoute(
                    name: "admin deletion",
                    pattern: "{area:exists}/{controller=Home}/delete/{id:int}",
                    defaults: new { action = "Suppression" });
                endpoints.MapControllerRoute(
                    name: "admin edition",
                    pattern: "{area:exists}/{controller=Home}/edit/{id:int}",
                    defaults: new { action = "Edit" });

                // Route admin index
                endpoints.MapControllerRoute(
                    name: "adminCommentIndex",
                    pattern: "/administration/commentaires",
                    defaults: new { area = "administration", controller = "Commentaire", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "adminArtisteIndex",
                    pattern: "/administration/artistes",
                    defaults: new { area = "administration", controller = "Artiste", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "adminStyleIndex",
                    pattern: "/administration/styles",
                    defaults: new { area = "administration", controller = "Style", action = "Index" });
                endpoints.MapControllerRoute(
                    name: "adminTitreIndex",
                    pattern: "/administration/titres",
                    defaults: new { area = "administration", controller = "Titre", action = "Index" });

                // Route base 
                endpoints.MapControllerRoute(
                    name: "contact",
                    pattern: "contact",
                    defaults: new { controller = "Contact", action = "Contact" });
                //endpoints.MapControllerRoute(
                //    name: "artiste",                                // PARTIE POUR ARTISTE! décommenter ne fois qu'il prend un nom (string)
                //    pattern: "artiste/{nomArtiste}",
                //    defaults: new { controller = "Artiste", action = "Artiste" });
                endpoints.MapControllerRoute(
                    name: "titre",
                    pattern: "titre/{id:int}",
                    defaults: new { controller = "Titre", action = "Titre" });
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