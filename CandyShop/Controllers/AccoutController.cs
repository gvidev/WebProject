using CandyShop.ActionFilters;
using CandyShop.Entities;
using CandyShop.ExtentionMethods;
using CandyShop.Repositories;
using CandyShop.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
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
            item.CreatedDate = DateTime.Now;


            CandyShopDbContext context = new CandyShopDbContext();

            context.Users.Add(item);
            context.SaveChanges();

            HttpContext.Session.SetObject("loggedUser", item);


            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [AutheticationFilter]
        public IActionResult Edit()
        {

            CandyShopDbContext context = new CandyShopDbContext();
            User currentUser = new User();

            currentUser = HttpContext.Session.GetObject<User>("loggedUser");

            EditVM model = new EditVM();

            model.FirstName = currentUser.FirstName;
            model.LastName = currentUser.LastName;
            model.Email = currentUser.Email;
            model.Username = currentUser.Username;
            model.Id = currentUser.Id;



            return View(model);
        }

        [HttpPost]
        [AutheticationFilter]
        public IActionResult Edit(EditVM model)
        {

            CandyShopDbContext context = new CandyShopDbContext();
            User currentUser = new User();

            currentUser = context.Users.Where(m => m.Id == model.Id).FirstOrDefault();


            if (!IsValid(model.Email))
            {
                ModelState.AddModelError("emailValidation", "Please enter a valid email!");
            }


            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.Username = model.Username;
            currentUser.Email = model.Email;

            context.Update(currentUser);
            context.SaveChanges();

            HttpContext.Session.SetObject<User>("loggedUser", currentUser);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        [AutheticationFilter]
        public IActionResult ChangePassword()
        {
            CandyShopDbContext context = new CandyShopDbContext();
            User currentUser = new User();

            currentUser = HttpContext.Session.GetObject<User>("loggedUser");

            EditPasswordVM model = new EditPasswordVM();

            model.Id = currentUser.Id;
            model.Password = currentUser.Password;

            return View(model);
        }

        [HttpPost]
        [AutheticationFilter]
        public IActionResult ChangePassword(EditPasswordVM model)
        {

            CandyShopDbContext context = new CandyShopDbContext();
            User currentUser = new User();

            currentUser = context.Users.Where(m => m.Id == model.Id).FirstOrDefault();


            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model.NewPassword.Length < 7)
            {
                ModelState.AddModelError("weakPassword", "Please insert stronger password!");
                return View(model);
            }


            if (currentUser.Password != model.Password)
            {
                ModelState.AddModelError("wrongPassword", "Wrong Password. Please try again!");
                return View(model);
            }





            currentUser.Password = model.NewPassword;
            context.Update(currentUser);
            context.SaveChanges();

            return View(nameof(Index));
        }


        [AutheticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Login", "Account");
        }





    }
}
