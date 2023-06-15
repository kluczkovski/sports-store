using System;
using Microsoft.EntityFrameworkCore;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Seeds
{
	public class LocationSeed : ISeeder
	{
        private readonly StoreDbContext _context;

        public LocationSeed(StoreDbContext context)
		{
            _context = context;
		}

        public bool IsRequired { get; set; } = true;

        public int Priority { get; set; } = 20;

        public async Task SeedAsync()
        {
            foreach (var location in GetLoctions())
            {
                var existingLocation = await _context.Locations.FirstOrDefaultAsync(x => x.Name == location.Name);

                if (existingLocation == null)
                {
                    await _context.AddAsync(location);
                }
            }

            await _context.SaveChangesAsync();
        }

        private List<Location> GetLoctions()
        {
            return new List<Location>()
            {
                new Location { Name = "Manchester" },
                new Location { Name = "Selby" },
                new Location { Name = "York" },
                new Location { Name = "London" },
            };
        }
    }
}

