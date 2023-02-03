using Microsoft.AspNetCore.Mvc.Filters;

namespace CandyShop.ActionFilters
{
    public class AdminRightsFillterAtribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
           //isAdmin
           //...
        }

    }
}
