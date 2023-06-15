using System;

namespace SportsStore.WebApp.Models
{
	public class EFStoreRepository : IStoreRepository
	{
		private readonly StoreDbContext _dbContext;

		public EFStoreRepository(StoreDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        public IQueryable<Product> Products => _dbContext.Products;

    }
}

