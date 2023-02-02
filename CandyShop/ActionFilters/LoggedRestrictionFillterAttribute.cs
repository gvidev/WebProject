using CandyShop.Entities;
using CandyShop.ExtentionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CandyShop.ActionFilters
{
    public class LoggedRestrictionFillterAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetObject<User>("loggedUser") != null)
               context.Result = new RedirectResult("/Home/Index");
        }

    }
}
