using NLog;
using NLog.Web;
using Webzine.WebApplication;
  
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Initialisation de l'application.");

try
{
  var app = Startup.Initialize(args);
  logger.Debug("L'application est correctement configurée.");
  app.Run();
  logger.Debug("L'application est démarrée.");
}
catch (Exception e)
{
    // NLog: catch setup errors
    logger.Error(e, "L'application a stoppé à cause d'une exception lors de sa configuration.");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}