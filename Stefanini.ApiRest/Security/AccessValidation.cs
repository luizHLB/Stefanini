using Microsoft.AspNetCore.Mvc.Filters;

namespace Stefanini.ApiRest.Security
{
    public class AccessValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            UserManager.Validate(context.HttpContext.Request);
            base.OnActionExecuting(context);
        }
    }
}
