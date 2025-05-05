using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PhotoWebApp
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(user))
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }
    }
}