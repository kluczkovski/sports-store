using System;
namespace SportsStore.WebApp.Models
{
	public interface IStoreRepository
	{
		IQueryable<Product> Products { get; }
	}
}

