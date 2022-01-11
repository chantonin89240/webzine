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
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}