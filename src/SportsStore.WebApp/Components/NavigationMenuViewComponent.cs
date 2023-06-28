using System;
using Microsoft.AspNetCore.Mvc;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IStoreRepository _storeRespository;

        public NavigationMenuViewComponent(IStoreRepository storeRespository)
        {
            _storeRespository = storeRespository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_storeRespository.Products
                .Select(x => x.Category)
                .Distinct()
                .ToList()
                .OrderBy(x => x));
        }
        
    }
}
