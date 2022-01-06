using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webzine.EntitiesContext;
using Webzine.Repository;
using Webzine.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();

NLog.LogManager.LoadConfiguration("nlog.config");

builder.Services.AddDbContext<WebzineDbContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
    );

// Supprime et crée la base de données
WebzineDbContext webzineDbContext = new WebzineDbContext();
webzineDbContext.Database.EnsureDeleted();
webzineDbContext.Database.EnsureCreated();
// SeedDataLocal.Initialize(services);
var db = webzineDbContext.Database.EnsureCreated();

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