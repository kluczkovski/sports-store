using Microsoft.EntityFrameworkCore;
using SportsStore.WebApp.Models;
using SportsStore.WebApp.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddScoped<ISeeder, ProductSeed>();

builder.Services.AddScoped<ISeeder, LocationSeed>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    "catpage",
    "{category}/Page{productPage:int}",
    new { Controler = "Home", Action = "Index" });

app.MapControllerRoute(
    "page",
    "Page{productPage:int}",
    new { Controler = "Home", Action = "Index" });

app.MapControllerRoute(
    "category",
    "{category}",
    new { Controller = "Home", Action = "Index" });

app.MapControllerRoute(
    "pagination",
    "Products/Page{productPage:int}",
    new { Controller = "Home", Action = "Index" });



app.MapDefaultControllerRoute();

SeedData.EnsurePopulatedAsync(app);

app.Run();
