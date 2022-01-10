using Microsoft.AspNetCore;
using NLog;
using NLog.Web;
using Webzine.EntitiesContext;
using Webzine.Repository;
using Webzine.Repository.Contracts;

namespace Webzine
{
  public class Program
  {
    // public static IWebHost BuildWebHost(string[] args) =>
    //         WebHost.CreateDefaultBuilder(args)
    //             .UseStartup<Startup>()
    //             .Build();
                
    public static void Main(string[] args)
    {
      // BuildWebHost(args).Run();
      
      var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
      logger.Debug("init main");
      // NLog.LogManager.LoadConfiguration("nlog.config"); Ligne NLog Kevin

      try
      {
        var builder = WebApplication.CreateBuilder(args);

        // NLog: Setup NLog for Dependency injection
        // problème au lancement de l'app, l'app bloque en mode debug, et bloque sur le chargement de la config dans launchsettings.json en mode no debug
        // builder.Logging.ClearProviders(); 
        builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

        // Essai configuration données local ou BDD depuis appsettings.json
        // var Seed = builder.Configuration.GetSection("ConnectionData");
        // Console.WriteLine(Seed);

        builder.Host.UseNLog();

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
        builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
        builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
        builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();

        var app = builder.Build();

        using(var scope = app.Services.CreateScope())
        {
          var services = scope.ServiceProvider;
          try
          {
            var webzineDbContext = services.GetRequiredService<WebzineDbContext>();

            // Supprime et cr�e la base de donn�es
            webzineDbContext.Database.EnsureDeleted();
            webzineDbContext.Database.EnsureCreated();

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

        app.Run();
      }
      catch (Exception exception)
      {
          // NLog: catch setup errors
          logger.Error(exception, "Stopped program because of exception");
          throw;
      }
      finally
      {
          // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
          NLog.LogManager.Shutdown();
      }
    }

  }
}
