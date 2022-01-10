namespace Webzine.WebApplication
{
    using Microsoft.EntityFrameworkCore;
    using Webzine.EntitiesContext;
    using Microsoft.Extensions.Configuration;
    public class Startup
    {
        private readonly IConfiguration configuration;

        public WebApplication Initialize(string [] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);

            return app;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddScoped<ITitreRepository, DbTitreRepository>();
            services.AddScoped<IArtisteRepository, DbArtisteRepository>();
            services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
            services.AddScoped<IStyleRepository, DbStyleRepository>();

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
    }

        public void Configure(IApplicationBuilder app)
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