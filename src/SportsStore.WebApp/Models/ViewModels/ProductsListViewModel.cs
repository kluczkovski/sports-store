using System;
namespace SportsStore.WebApp.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public string? CurrentyCategory { get; set; }

        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

        public PagingInfoViewModel PagingInfo { get; set; } = new();
    }
}

