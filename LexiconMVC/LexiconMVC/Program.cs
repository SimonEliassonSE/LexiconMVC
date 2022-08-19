
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); // Vi vill ha med v�ran service MVC
// M�ste inte finnas f�r att anv�nda session(standard lifsl�ngd �r 30 min, men ger oss mer kontroll �ver session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(900);
});

var app = builder.Build();

app.UseSession(); // M�ste finnas f�r att anv�nda session
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern: "{controller=ViewContent}/{action=Index}/{id?}");
// Pattern �r hur det ska se ut 

app.MapControllerRoute(
    name: "FeverCheck", // Namnet p� routen
    pattern: "FeverCheck", // Ger oss m�jligheten att komma �t actionen gemom att p� startsidan skriva /FeverCheck
    defaults: new { controller = "Doctor", action = "FeverCheck" }); // S�ger villken controller som ska anv�ndas och villken action present i controllen som ska k�ras

// Beh�ver yterligare 1 app.MapControllerRoute som genom att skriva /GeussingGame tar oss till den actione
// /GuessingGame

app.MapControllerRoute(
    name: "GeussingGame",
    pattern: "SetSession",
    defaults: new { controller = "Doctor", action = "SetSession" });

//app.MapGet("/", () => "Hello World!");

app.Run();





