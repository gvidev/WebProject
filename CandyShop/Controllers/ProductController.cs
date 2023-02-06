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
        public IActionResult Index(IndexVM model)
        {
            CandyShopDbContext context = new CandyShopDbContext();

            model.Products = context.Products.ToList();

            return View(model);
        }


        [HttpGet]
        [AdminRightsFillter]
        public IActionResult Manage(IndexVM model)
        {

            CandyShopDbContext context = new CandyShopDbContext();

            model.Products = context.Products.ToList();
            return View(model);
        }

        [HttpGet]
        [AdminRightsFillter]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        [AdminRightsFillter]
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

            return RedirectToAction("Manage", "Product");
        }

        [HttpGet]
        [AdminRightsFillter]
        public IActionResult Edit(int id)
        {
            EditVM model = new EditVM();
            CandyShopDbContext context = new CandyShopDbContext();
            Product item = new Product();

            item = context.Products.Where(m => m.Id == id).FirstOrDefault();

            if(item == null)
            {
                return RedirectToAction("Manage", "Product");
            }

            model.Id = item.Id;
            model.ImageUrl = item.ImageUrl;
            model.Price = item.Price;
            model.PieceCount = item.PieceCount;

            return View(model);
        }

        [HttpPost]
        [AdminRightsFillter]
        public IActionResult Edit(EditVM model)
        {
            CandyShopDbContext context = new CandyShopDbContext();
            Product item = new Product();

            item = context.Products.Where(m => m.Id == model.Id).FirstOrDefault();

            item.ImageUrl = model.ImageUrl;
            item.Price = model.Price;
            item.PieceCount = model.PieceCount;

            context.Update(item);
            context.SaveChanges();
            
            return RedirectToAction("Manage", "Product"); ;
        }

        [HttpGet]
        [AdminRightsFillter]
        public IActionResult Delete(int id) 
        {
            CandyShopDbContext context = new CandyShopDbContext();
            Product product = new Product();

            product = context.Products.Where(m => m.Id == id).FirstOrDefault();

            if (product == null)
            {
                return RedirectToAction("Manage", "Product");
            }

            context.Remove(product);
            context.SaveChanges();
                
            return RedirectToAction("Manage","Product");
        
        }


    }
}
