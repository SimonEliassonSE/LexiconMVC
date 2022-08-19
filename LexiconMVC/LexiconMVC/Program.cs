
// enforce use of periods as decimal separator
//using System.Globalization;
//var cultureInfo = new CultureInfo("en-US");
//CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
//CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); // Vi vill ha med våran service MVC

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern: "{controller=ViewContent}/{action=Index}/{id?}");
// Pattern är hur det ska se ut 

app.MapControllerRoute(
    name: "FeverCheck",
    pattern: "FeverCheck",
    defaults: new { controller = "Doctor", action = "FeverCheck" });

//app.MapGet("/", () => "Hello World!");

app.Run();



