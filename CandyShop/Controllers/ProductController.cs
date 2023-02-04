using CandyShop.ActionFilters;
using CandyShop.Entities;
using CandyShop.Repositories;
using CandyShop.ViewModels.Product;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CandyShop.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [AdminRightsFillter]
        public IActionResult Manage()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreateVM model) 
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            CandyShopDbContext context = new CandyShopDbContext();
            Product item = new Product();

            item.Name = model.Name;
            item.Description = model.Description;
            item.Price = model.Price;
            item.Category = model.Category;
            item.ImageUrl = model.ImageUrl;
            item.PieceCount = model.PieceCount;

            context.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }


        [HttpPut]
        public IActionResult Edit(EditVM model)
        { 
            return View(model);
        }


        [HttpDelete]
        public IActionResult Delete(int id) { return View(); }


    }
}
