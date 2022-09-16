using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;

});

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseSession(); 
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

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





