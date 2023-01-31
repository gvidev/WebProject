using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CandyShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}