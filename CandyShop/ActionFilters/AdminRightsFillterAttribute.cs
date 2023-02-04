
using CandyShop.Entities;
using CandyShop.ExtentionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CandyShop.ActionFilters
{
    public class AdminRightsFillterAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            User loggedUser = context.HttpContext.Session.GetObject<User>("loggedUser");

            if (loggedUser != null && loggedUser.isAdmin)
            {
                return;
            }
            else
            {
                context.Result = new RedirectResult("/Home/Index");
            }
             
        }

    }
}
