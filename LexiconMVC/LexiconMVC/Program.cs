using LexiconMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(900);
});

var app = builder.Build();

app.UseSession(); 
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name:"default",
    pattern: "{controller=ViewContent}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "FeverCheck", 
    pattern: "FeverCheck", 
    defaults: new { controller = "Doctor", action = "FeverCheck" }); 

app.MapControllerRoute(
    name: "GuessingGame",
    pattern: "GuessingGame",
    defaults: new { controller = "GuessingGame", action = "Guessing" });

app.MapControllerRoute(
    name: "PeopleTable",
    pattern: "PeopleTable",
    defaults: new { controller = "People", action = "Index" });

app.MapControllerRoute(
    name: "Admin",
    pattern: "Admin",
    defaults: new { controller = "Country", action = "AddCityToCountry" });

app.Run();





