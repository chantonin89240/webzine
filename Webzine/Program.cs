//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
using Webzine.Repository;
using Webzine.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();

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
        name:"default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
