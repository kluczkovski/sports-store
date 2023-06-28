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

        public ViewResult Index(string? category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                CurrentyCategory = category,
                Products = _repository.Products
                    .Where(c => category == null || c.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        _repository.Products.Count() :
                        _repository.Products.Where(x => x.Category == category).Count()
                        
                }
            });               
    }
}

