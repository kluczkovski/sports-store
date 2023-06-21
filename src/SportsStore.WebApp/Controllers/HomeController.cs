using Microsoft.AspNetCore.Mvc;
using SportsStore.WebApp.Models;
using SportsStore.WebApp.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _repository;
        private const int PageSize = 3;

        public HomeController(IStoreRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = _repository.Products
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }
            });                
    }
}

