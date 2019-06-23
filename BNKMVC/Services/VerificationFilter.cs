using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace BNKMVC.Services
{
    public class MustBeVerifiedFilter:  ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
             
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                  var userId= HttpContext.Current.User.Identity.GetUserId();
                  var acct = new CryptoAccount();
                  var user = acct.GetUser(userId);
                  if(user != null)
                  {
                    //  
                    string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToString();
                    string actionName = filterContext.ActionDescriptor.ActionName.ToString();
                    if (user.Status != AccountStatus.APPROVED.ToString())
                    {
                        var values = new RouteValueDictionary(new
                        {
                            action = "Verify",
                            controller = "Investor",
                            code = "0"
                        });
                        filterContext.Result = new RedirectToRouteResult(values);
                        base.OnActionExecuting(filterContext);
                    }
                }
                  
            }
        }

    }
}