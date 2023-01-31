using CandyShop.ActionFilters;
using CandyShop.Entities;
using CandyShop.ExtentionMethods;
using CandyShop.Repositories;
using CandyShop.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CandyShop.Controllers
{
    public class AccountController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            CandyShop_DbContext context = new CandyShop_DbContext();
            User loggedUser = context.Users.Where(u =>
                                    u.Email == model.Email &&
                                    u.Password == model.Password)
                                     .FirstOrDefault() ;

            if(loggedUser == null)
            {
                this.ModelState.AddModelError("authError", "Invalid username or password!");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", loggedUser);

            return RedirectToAction("Index","Home");

        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationVM model)
        {

            if (!ModelState.IsValid)
                return View(model);

            

            User item = new User();
            item.Username = model.Username;
            item.Email = model.Email;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;


            CandyShop_DbContext context = new CandyShop_DbContext();

            context.Users.Add(item);
            context.SaveChanges();


            return RedirectToAction("Index", "Home");        }

        [AutheticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Login","Home");
        }

        



    }
}
