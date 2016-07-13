using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using InspectionBoard.Domain.Context;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using InspectionBoard.Domain.Entity;

[assembly: OwinStartup(typeof(InspectionBoard.App_Start.Startup))]

namespace InspectionBoard.App_Start
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            // настраиваем контекст и менеджер
            app.CreatePerOwinContext<InspectionBoardContext>(InspectionBoardContext.Create);
            app.CreatePerOwinContext<ApplicantUserManager>(ApplicantUserManager.Create);

            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                LoginPath = new PathString("/Account/Account/Login"),
            });
        }
    }
}