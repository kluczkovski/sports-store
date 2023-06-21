using System;
namespace SportsStore.WebApp.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

        public PagingInfoViewModel PagingInfo { get; set; } = new();
    }
}

