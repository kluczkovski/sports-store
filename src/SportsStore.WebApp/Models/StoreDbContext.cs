using System;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.WebApp.Models
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base (options)
		{
		}

		public DbSet<Product> Products => Set<Product>();

		public DbSet<Location> Locations => Set<Location>();

		public DbSet<Order> Orders => Set<Order>();
	}
}

