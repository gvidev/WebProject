using CandyShop.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace CandyShop.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        [AutheticationFilter]
        public IActionResult Index()
        {
            return View();
        }

        [AutheticationFilter]
        public IActionResult AddProduct()
        {
            return View();
        }

        [AutheticationFilter]
        public IActionResult MakeOrder()
        {
            return View();
        }
    }
}
