using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace proje.webui.Filter
{
    public class UserFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userId = context.HttpContext.Session.GetString("session");
           
            if(userId!=null)
            {
                    context.Result=new RedirectToRouteResult(new RouteValueDictionary{
                       
                        {"controller","Giris"}
                    });
            }
            base.OnActionExecuting(context);
        }
    }
}