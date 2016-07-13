using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InspectionBoard.Attributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //public void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        filterContext.Result = new RedirectResult("/Account/Account/Login");
        //    }
        //}

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Account/Account/Login");
            }
        }
    }
}