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


app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}",
    new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page", "Page{productPage:int}",
    new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("category", "{category}",
    new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index", productPage = 1 });


app.MapDefaultControllerRoute();

SeedData.EnsurePopulatedAsync(app);

app.Run();
