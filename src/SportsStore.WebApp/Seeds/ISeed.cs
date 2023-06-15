using System;
namespace SportsStore.WebApp.Seeds
{
	public interface ISeeder
	{
		bool IsRequired { get; }

		int Priority { get; }

		Task SeedAsync();
	}
}

