using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webzine.EntitiesContext;
using Webzine.Repository;
using Webzine.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();

builder.Services.AddDbContext<WebzineDbContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
    );

//Supprime et crée la base de données
//Context.Database.ensureDeleted();
//Context.Database.ensureCreated();
//SeedDataLocal.Initialize(services);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
