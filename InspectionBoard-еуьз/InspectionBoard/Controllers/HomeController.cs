using InspectionBoard.Domain.BuisnessLogic.Admin;
using InspectionBoard.Domain.Context;
using InspectionBoard.Domain.Entity;
using InspectionBoard.Domain.BuisnessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.Owin.Security;
using InspectionBoard.Attributes;
using NLog;

namespace InspectionBoard.Controllers
{ 
    
    public class HomeController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        [CustomAuthorize(Roles = "admin, moderator, user")] 
        public ActionResult Index()
        {
            ApplicantUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicantUserManager>();
            
            var i = User.Identity;
            ApplicantRepository applicant = new ApplicantRepository();

            if (userManager.GetRoles(applicant.FindApplicantByEmail(i.Name).Id).Contains("moderator") || userManager.GetRoles(applicant.FindApplicantByEmail(i.Name).Id).Contains("admin"))
            {  
                logger.Info("Admin or moderator log in system.");
                return Redirect("/Admin/Admin/index#section2");
            }
            CityRepository city = new CityRepository();
            ViewBag.Cities = city.GetObjectList();
            if (applicant.FindApplicantByEmail(i.Name).isBlocked)
            {
                logger.Info("User " + i.Name + " was blocked by admin.");
                return Redirect("/Home/Blocked");
            }
            return View(applicant.FindApplicantByEmail(i.Name));
        }

        public ActionResult Index1(int page = 1)
        {
            InspectionBoardContext context = new InspectionBoardContext();
            int pageSize = 3; 
            IEnumerable<City> citiesPerPages = context.Cities.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = context.Cities.ToList().Count };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Cities = citiesPerPages };
            return View(ivm);
        }

        [CustomAuthorize(Roles = "user")]
        public ActionResult DisplayCity()
        {
            var i = User.Identity;
            ApplicantRepository applicant = new ApplicantRepository();
            if (applicant.FindApplicantByEmail(i.Name).isBlocked)
            {
                logger.Info("User " + i.Name + " was blocked by admin.");
                return Redirect("/Home/Blocked");
            }
            CityRepository city = new CityRepository();
            return View(city.GetObjectList());
        }

        [CustomAuthorize(Roles = "user")]
        public ActionResult DisplayUniversity(int id)
        {
            var i = User.Identity;
            ApplicantRepository applicant = new ApplicantRepository();
            if (applicant.FindApplicantByEmail(i.Name).isBlocked)
            {
                logger.Info("User " + i.Name + " was blocked by admin.");
                return Redirect("/Home/Blocked");
            }
            UniversityRepository university = new UniversityRepository();
            return View(university.GetObjectList(id));
        }

        [CustomAuthorize(Roles = "user")]
        public ActionResult DisplayFaculty(int id)
        {

            var i = User.Identity;
            ApplicantRepository applicant = new ApplicantRepository();
            if (applicant.FindApplicantByEmail(i.Name).isBlocked)
            {
                logger.Info("User " + i.Name + " was blocked by admin.");
                return Redirect("/Home/Blocked");
            }
            FacultyRepository faculty = new FacultyRepository();
            return View(faculty.GetObjectList(id));
        }

        [CustomAuthorize(Roles = "user")]
        [HttpGet]
        public ActionResult DisplaySpecialty(int id)//id faculteta
        {
          
            var i = User.Identity;
            ApplicantRepository applicant = new ApplicantRepository();
            if (applicant.FindApplicantByEmail(i.Name).isBlocked)
            {
                logger.Info("User " + i.Name + " was blocked by admin.");
                return Redirect("/Home/Blocked");
            }
            Session["facultet"] = id;
            SpecialtyRepository specialty = new SpecialtyRepository();
            //CrudSubject subject = new CrudSubject(); 
            //CrudStatement statement = new CrudStatement(); 
            ViewBag.Applicant = applicant.FindApplicantByEmail(User.Identity.Name);   
            return View(specialty.GetObjectList(id));
        }

        [CustomAuthorize(Roles = "user")]
        [HttpGet]
        public ActionResult Statements(int id)
        {
            
            var i = User.Identity;
            ApplicantRepository applicant = new ApplicantRepository();
            if (applicant.FindApplicantByEmail(i.Name).isBlocked)
            {
                logger.Info("User " + i.Name + " was blocked by admin.");
                return Redirect("/Home/Blocked");
            }
            SpecialtyRepository specialty = new SpecialtyRepository(); 
            
            Session["specialty"] = specialty.FindById(id);
            return View();
        }

        [CustomAuthorize(Roles = "user")]
        [HttpPost]
        public ActionResult Statements(Statement statement)
        {
            if (ModelState.IsValid)
            {
                ApplicantRepository appl = new ApplicantRepository();
                Applicant applicant = new Applicant();

                applicant = appl.FindApplicantByEmail(User.Identity.Name);
                StatementRepository state = new StatementRepository();
                state.Create(statement, applicant, Session["specialty"] as Specialty);
                logger.Info("User" + applicant.UserName + " sent statement to system.");
                return Redirect("/Home/DisplaySpecialty/" + Session["facultet"] + "#section2");
            }
            ModelState.AddModelError("", "Введіть цілі числа");
            return View(statement);
        }

        [CustomAuthorize(Roles = "user")]
        public ActionResult DisplayStatements(int id)
        { 
            var i = User.Identity;
            ApplicantRepository applicant = new ApplicantRepository();
            if (applicant.FindApplicantByEmail(i.Name).isBlocked)
            {
                logger.Info("User " + i.Name + " was blocked by admin.");
                return Redirect("/Home/Blocked");
            }
            List<int> listBudget = new List<int>();
            List<int> listTotal = new List<int>();
            CalculateResults calculate = new CalculateResults();
            calculate.Calculate(ref listTotal, ref listBudget);
            StatementRepository statements = new StatementRepository(); 
            ViewBag.Budget = listBudget;
            ViewBag.Total = listTotal;
            return View(statements.StatementsForSpecialty(id));
        }

        public ActionResult Error()
        {
            return View("Error");
        }

        public ActionResult Blocked()
        {
            return View("Blocked");
        }

    }
}