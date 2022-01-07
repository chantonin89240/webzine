using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webzine.EntitiesContext;
using Webzine.Repository;
using Webzine.Repository.Contracts;

NLog.LogManager.LoadConfiguration("nlog.config");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
//builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();

builder.Services.AddDbContext<WebzineDbContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
    );

// Supprime et cr�e la base de donn�es
WebzineDbContext webzineDbContext = new WebzineDbContext();
webzineDbContext.Database.EnsureDeleted();
webzineDbContext.Database.EnsureCreated();
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