using System;
using Microsoft.EntityFrameworkCore;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Seeds
{
	public class ProductSeed : ISeeder
	{
        private readonly StoreDbContext _context;

        public ProductSeed(StoreDbContext context)
        {
            _context = context;
        }

        public bool IsRequired { get; set; } = true;

        public int Priority { get; set; } = 10;

        public async Task SeedAsync()
        {
            foreach (var product in ProductData.Get())
            {
                var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);

                if (existingProduct == null)
                {
                    await _context.AddAsync(product);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}

