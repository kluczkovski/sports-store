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
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

builder.Services.AddScoped<ISeeder, ProductSeed>();

builder.Services.AddScoped<ISeeder, LocationSeed>();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseStaticFiles();

<<<<<<< HEAD
app.UseSession();

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

=======

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


>>>>>>> main
app.MapDefaultControllerRoute();

app.MapRazorPages();

SeedData.EnsurePopulatedAsync(app);

app.Run();
