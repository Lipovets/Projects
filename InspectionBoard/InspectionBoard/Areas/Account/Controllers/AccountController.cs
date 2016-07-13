using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using InspectionBoard.Domain.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.Owin.Security;
using InspectionBoard.Domain.Context;
using System.IO;
using NLog;

namespace InspectionBoard.Areas.Account.Controllers
{
    public class AccountController : Controller
    {
        private ApplicantUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicantUserManager>();
            }
        }

        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model, HttpPostedFileBase uploadImage)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            if (ModelState.IsValid && uploadImage != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                model.Attestation = imageData;
                Applicant user = new Applicant
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Attestation = model.Attestation,
                    City = model.City,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    Region = model.Region,
                    SchoolName = model.SchoolName,
                    isBlocked = false
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "user");
                    logger.Info("Registration was successful " + user.UserName);
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            logger.Info("Registration was failed. Attestation didn't load.");
            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            if (ModelState.IsValid)
            {
                Applicant user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Не правильний логін чи пароль");
                    logger.Info("Wrong email or password");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    logger.Info("User "+user.UserName+" log in system.");
                    if (String.IsNullOrEmpty(returnUrl))
                        return Redirect("/Home/Index");

                    return Redirect(returnUrl);
                }

            }
            ViewBag.returnUrl = returnUrl;
            logger.Info("Login failed");
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            AuthenticationManager.SignOut();
            logger.Info("User logout");
            return RedirectToAction("Login");
        }

    }
}