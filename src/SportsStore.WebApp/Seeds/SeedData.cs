using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Seeds
{
	public static class SeedData
	{
		public static async void EnsurePopulatedAsync(IApplicationBuilder app)
		{
		
			var scope =  app.ApplicationServices.CreateScope();
		
            var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();

            var serviceProvider = scope.ServiceProvider;

            var seeders = serviceProvider.GetServices<ISeeder>();

			if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }
         
			foreach (var seeder in seeders.OrderBy(x => x.Priority))
            {
                await seeder.SeedAsync();
            }
			
        }
    }
}

