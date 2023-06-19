using Microsoft.AspNetCore.Mvc;
using SportsStore.WebApp.Models;

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
        // GET: /<controller>/
        public IActionResult Index(int productPage = 1)
            => View(_repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize));
    }
}

