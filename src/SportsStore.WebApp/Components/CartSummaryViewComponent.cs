using System;
using Microsoft.AspNetCore.Mvc;
using SportsStore.WebApp.Models;

namespace SportsStore.WebApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}

