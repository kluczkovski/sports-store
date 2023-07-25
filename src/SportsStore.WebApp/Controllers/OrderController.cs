using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.WebApp.Controllers
{

    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(
            IOrderRepository orderRepository,
            Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }
        // GET: /<controller>/
        public IActionResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Sorry, your car is empty!");
            }

            if (ModelState.IsValid) {
                order.Lines = _cart.Lines.ToArray();
                _orderRepository.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderId });
            }

            return View();
        }

    }
}

