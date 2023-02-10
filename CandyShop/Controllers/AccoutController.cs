using CandyShop.ActionFilters;
using CandyShop.Entities;
using CandyShop.ExtentionMethods;
using CandyShop.Repositories;
using CandyShop.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mail;

namespace CandyShop.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        [AutheticationFilter]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [LoggedRestrictionFillter]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            CandyShopDbContext context = new CandyShopDbContext();
            User loggedUser = context.Users.Where(u =>
                                    u.Email == model.Email &&
                                    u.Password == model.Password)
                                     .FirstOrDefault();

            if (loggedUser == null)
            {
                this.ModelState.AddModelError("authError", "Invalid username or password!");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", loggedUser);

            return RedirectToAction("Index", "Home");

        }

        //method that find out if the entered email is correct 
        private static bool IsValid(string email)
        {
            bool valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }
            return valid;
        }


        [HttpGet]
        [LoggedRestrictionFillter]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationVM model)
        {
            if (!IsValid(model.Email))
            {
                ModelState.AddModelError("emailValidation", "Please enter a valid email!");
            }

            if (model.Password.Length < 7)
            {
                ModelState.AddModelError("weakPassword", "Please insert stronger password!");
            }



            if (!ModelState.IsValid)
                return View(model);



            User item = new User();
            item.Username = model.Username;
            item.Email = model.Email;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;


            CandyShopDbContext context = new CandyShopDbContext();

            context.Users.Add(item);
            context.SaveChanges();

            HttpContext.Session.SetObject("loggedUser", item);


            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [AutheticationFilter]
        public IActionResult Edit(int id)
        {

            CandyShopDbContext context = new CandyShopDbContext();

            User loggedUser = new User();

            loggedUser = context.Users.Where(x => x.Id == id).FirstOrDefault();

            if (loggedUser == null)
            {
                return View(nameof(Login));
            }


            return View();
        }

        [AutheticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Login","Account");
        }

        



    }
}
