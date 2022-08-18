var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); // Vi vill ha med våran service MVC

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern: "{controller=ViewContent}/{action=Index}/{id?}");
// Pattern är hur det ska se ut 

//app.MapControllerRoute(
//    name: "about",
//    pattern: "about",
//    defaults: new { controller = "Home", action = "About" });

//app.MapGet("/", () => "Hello World!");

app.Run();
