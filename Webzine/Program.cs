using Microsoft.EntityFrameworkCore;
using Webzine.EntitiesContext;
using Webzine.Repository;
using Webzine.Repository.Contracts;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
// NLog.LogManager.LoadConfiguration("nlog.config");

try
{
  var builder = WebApplication.CreateBuilder(args);

  // NLog: Setup NLog for Dependency injection
  //builder.Logging.ClearProviders();
  builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

  var Seed = builder.Configuration.GetSection("ConnectionData");
  Console.WriteLine(Seed);

  builder.Host.UseNLog();

  builder.Services.AddControllersWithViews();
  builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
  builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
  builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
  builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
  builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();

  WebzineDbContext webzineDbContext = new WebzineDbContext();

  builder.Services.AddDbContext<WebzineDbContext>(
          options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
      );

  // Supprime et cr�e la base de donn�es
  webzineDbContext.Database.EnsureDeleted();
  webzineDbContext.Database.EnsureCreated();
  // Initialisation de la base de donn�es
  SeedDataLocal.InitialisationDB(webzineDbContext);

  var app = builder.Build();

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