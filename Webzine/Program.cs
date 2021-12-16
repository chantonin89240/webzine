var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();



var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");

app.Run();
