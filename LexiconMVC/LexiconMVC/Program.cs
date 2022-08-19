
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); // Vi vill ha med våran service MVC
// Måste inte finnas för att använda session(standard lifslängd är 30 min, men ger oss mer kontroll över session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(900);
});

var app = builder.Build();

app.UseSession(); // Måste finnas för att använda session
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern: "{controller=ViewContent}/{action=Index}/{id?}");
// Pattern är hur det ska se ut 

app.MapControllerRoute(
    name: "FeverCheck", // Namnet på routen
    pattern: "FeverCheck", // Ger oss möjligheten att komma åt actionen gemom att på startsidan skriva /FeverCheck
    defaults: new { controller = "Doctor", action = "FeverCheck" }); // Säger villken controller som ska användas och villken action present i controllen som ska köras

// Behöver yterligare 1 app.MapControllerRoute som genom att skriva /GeussingGame tar oss till den actione
// /GuessingGame

app.MapControllerRoute(
    name: "GeussingGame",
    pattern: "SetSession",
    defaults: new { controller = "Doctor", action = "SetSession" });

//app.MapGet("/", () => "Hello World!");

app.Run();





