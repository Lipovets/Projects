using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InspectionBoard.Domain.BuisnessLogic.Admin;
using InspectionBoard.Domain.BuisnessLogic; 

using InspectionBoard.Domain.Entity;
using Microsoft.AspNet.Identity.Owin; 
using Microsoft.AspNet.Identity;
using NLog;
using InspectionBoard.Attributes;


namespace InspectionBoard.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<City> cityRepository;
        private IRepository<University> universityRepository;
        private IRepository<Faculty> facultyRepository;
        private IRepository<Specialty> specialtyRepository; 
        private IRepository<Subject> subjectRepository;

        public AdminController()
        {
            this.cityRepository = new CityRepository();
            this.universityRepository = new UniversityRepository();
            this.facultyRepository = new FacultyRepository();
            this.specialtyRepository = new SpecialtyRepository();
            this.subjectRepository = new SubjectRepository();
        }

        public AdminController(IRepository<City> rep)
        {
            cityRepository = rep;
        }

        public AdminController(IRepository<University> rep)
        {
            universityRepository = rep;
        }
        public AdminController(IRepository<Faculty> rep)
        {
            facultyRepository = rep;
        }
        public AdminController(IRepository<Specialty> rep)
        {
            specialtyRepository = rep;
        }
        public AdminController(IRepository<Subject> rep)
        {
            subjectRepository = rep;
        }

        static int idTemp=0;
        static int idSubject = 0;
        Logger logger = LogManager.GetCurrentClassLogger();

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                ApplicantUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicantUserManager>();
                var i = User.Identity;
                if(i==null) throw new Exception(); 
                ApplicantRepository applicant = new ApplicantRepository();
                ViewBag.Roles = userManager.GetRoles(applicant.FindApplicantByEmail(i.Name).Id);
            }
            catch(Exception ex)
            {
                logger.Info("User not found" + ex.Message);
                return Redirect("/Account/Account/Login");
            } 
            CityRepository city = new CityRepository();

            return View(city.GetObjectList());
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpPost]
        public ActionResult Index(String know)
        { 
            List<int> listBudget = new List<int>();
            List<int> listTotal = new List<int>();
            CalculateResults calculate = new CalculateResults();
            calculate.Calculate(ref listTotal, ref listBudget);
            logger.Info("List of applicants was defined. There are " + listBudget.Count() + " applicants on budget, and " + listTotal.Count() + " applicants on contract." );
            MailSend mail = new MailSend();
            mail.Sending(listBudget, "Вітаємо! Ви зараховані на бюджетній основі на спеціальність");
            mail.Sending(listTotal, "Вітаємо! Ви зараховані на контракт на спеціальність");
            logger.Info("Messages about accepted to university was sent (" + (listBudget.Count()+listTotal.Count())+ ").");
            CalculateResults.isReckoned = true; 
            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Create()
        { 
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(City city)
        { 
            CityRepository repositoryCity = new CityRepository();
            repositoryCity.Create(city); 
            logger.Info("Admin added city " + city.Name);
            return Redirect("/Admin/Admin/Index#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {  
            return View(cityRepository.FindById(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(City city)
        {
            cityRepository.Edit(city);
            logger.Info("Admin changed the city name on " + city.Name);
            return Redirect("/Admin/Admin/Index#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            cityRepository.Delete(id);
            logger.Info("Admin deleted the city.");
            return Redirect("/Admin/Admin/Index#section2"); 
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        public ActionResult DisplayUniversities(int id)
        {
            ApplicantUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicantUserManager>();
            var i = User.Identity; 
            ApplicantRepository applicant = new ApplicantRepository();
            ViewBag.Roles = userManager.GetRoles(applicant.FindApplicantByEmail(i.Name).Id);
            idTemp = id; 
            UniversityRepository university = new UniversityRepository();
            return View(university.GetObjectList(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateUniversity()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateUniversity(University university)
        { 
            UniversityRepository univer = new UniversityRepository();
            univer.Create(university, idTemp);
            logger.Info("University "+ university.Name +" was added by admin");
            return Redirect("/Admin/Admin/DisplayUniversities/" + idTemp+"#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditUniversity(int id)
        { 
            return View(universityRepository.FindById(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditUniversity(University univer)
        {
            universityRepository.Edit(univer);
            logger.Info("University was edited by admin.");
            return Redirect("/Admin/Admin/DisplayUniversities/" + idTemp + "#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult DeleteUniversity(int id)
        {  
            universityRepository.Delete(id);
            logger.Info("University was deleted by admin");
            return Redirect("/Admin/Admin/DisplayUniversities/" + idTemp + "#section2");
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        public ActionResult DisplayFaculty(int id)
        {  
            ApplicantUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicantUserManager>();
            var i = User.Identity; 
            ApplicantRepository applicant = new ApplicantRepository();
            ViewBag.Roles = userManager.GetRoles(applicant.FindApplicantByEmail(i.Name).Id);
            idTemp = id;
            FacultyRepository faculty = new FacultyRepository();
            return View(faculty.GetObjectList(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateFaculty()
        { 
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateFaculty(Faculty faculty)
        { 
            FacultyRepository fac = new FacultyRepository();
            fac.Create(faculty, idTemp);
            logger.Info("Faculty " + faculty.Name + "was added.");
            return Redirect("/Admin/Admin/DisplayFaculty/" + idTemp + "#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditFaculty(int id)
        {
            return View(facultyRepository.FindById(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditFaculty(Faculty fac)
        { 

            facultyRepository.Edit(fac);
            logger.Info("Faculty " + fac.Name + "was edited.");
            return Redirect("/Admin/Admin/DisplayFaculty/" + idTemp + "#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult DeleteFaculty(int id)
        { 
            facultyRepository.Delete(id);
            return Redirect("/Admin/Admin/DisplayFaculty/" + idTemp + "#section2");
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        public ActionResult DisplaySpecialty(int id)
        {
            
            ApplicantUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicantUserManager>();
            var i = User.Identity; 
            ApplicantRepository applicant = new ApplicantRepository();
            ViewBag.Roles = userManager.GetRoles(applicant.FindApplicantByEmail(i.Name).Id);
            idTemp = id;
            SpecialtyRepository specialty = new SpecialtyRepository();
            return View(specialty.GetObjectList(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateSpecialty()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateSpecialty(Specialty specialty)
        {
            if((specialty.TotalAmount==0) || (specialty.BudgetAmount==0))
            {
                ModelState.AddModelError("BudgetAmount", "Введіть цілі числа.");
                return View(specialty);
            }
            if (specialty.BudgetAmount < specialty.TotalAmount)
            { 
                SpecialtyRepository spec = new SpecialtyRepository();
                spec.Create(specialty, idTemp);
                logger.Info("Specialty " + specialty.Name + "was created.");
                return Redirect("/Admin/Admin/ChangeSubject/" + specialty.Id + "#section2");
                //return Redirect("/Admin/Admin/DisplaySpecialty/" + idTemp + "#section2");
            }
            ModelState.AddModelError("BudgetAmount", "Кількість бюджетних місць повинно бути менше ніж набір.");
            
            return View(specialty);
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditSpecialty(int id)
        {
            return View(specialtyRepository.FindById(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditSpecialty(Specialty spec)
        {
            if ((spec.TotalAmount == 0) || (spec.BudgetAmount == 0))
            {
                ModelState.AddModelError("BudgetAmount", "Введіть цілі числа.");
                return View(spec);
            }
            if (spec.BudgetAmount < spec.TotalAmount)
            {
                specialtyRepository.Edit(spec);
                logger.Info("Specialty " + spec.Name + "was edited.");
                return Redirect("/Admin/Admin/DisplaySpecialty/" + idTemp + "#section2");
            }
            ModelState.AddModelError("BudgetAmount", "Кількість бюджетних місць повинно бути менше ніж набір.");
            return View(spec);
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult DeleteSpecialty(int id)
        { 
            specialtyRepository.Delete(id);
            logger.Info("Specialty was deleted.");
            return Redirect("/Admin/Admin/DisplaySpecialty/" + idTemp + "#section2");
        }

        [CustomAuthorize(Roles = "admin")] 
        public ActionResult DisplaySubjects()
        {
            SubjectRepository subject = new SubjectRepository();
            return View(subject.SubjectFor());
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult CreateSubject()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult CreateSubject(Subject subj)
        {
            SubjectRepository subject = new SubjectRepository();
            subject.Create(subj);
            logger.Info("Subject " + subj.Name + "was created.");
            return Redirect("/Admin/Admin/DisplaySubjects#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditSubject(int id)
        { 
            return View(subjectRepository.FindById(id));
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditSubject(Subject subj)
        { 
            subjectRepository.Edit(subj);
            logger.Info("Subject was edited on " + subj.Name);
            return Redirect("/Admin/Admin/DisplaySubjects#section2");
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult DeleteSubject(int id)
        { 
            subjectRepository.Delete(id);
            logger.Info("Subject was deleted.");
            return Redirect("/Admin/Admin/DisplaySubjects#section2");
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpGet]
        public ActionResult ChangeSubject(int id)
        { 
            idSubject = id;
            SubjectRepository subject = new SubjectRepository(); 
            ViewBag.SubjectForSpecialty = subject.GetNameFromSubject(subject.SubjectForSpecialty(id));
            return View(subject.SubjectFor());
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpPost]
        public ActionResult ChangeSubject(int[] SelectedSubject)
        {
            if(SelectedSubject.Count()!=3)
            {
                ModelState.AddModelError("", "Виберіть 3 предмети");
                return RedirectToAction("/ChangeSubject/" + idSubject);
            }
            SubjectRepository subject = new SubjectRepository();
            subject.ChangeSubject(idSubject, SelectedSubject);
            logger.Info("Subject was edited.");
            return Redirect("/Admin/Admin/DisplaySpecialty/"+ idTemp +"#section2");
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpGet]
        public ActionResult Statements(int id)
        {
             
            Session["specialtyId"] = id;
            StatementRepository statements = new StatementRepository();
            return View(statements.StatementsForSpecialty(id));
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpPost]
        public ActionResult Statements(FormCollection col)
        {
            StatementRepository stat = new StatementRepository();
            stat.Edit((int.Parse(col["StateId"])));
            stat.AmountOfStatement((int)Session["specialtyId"]);
            logger.Info("Calculate amount of statements.");
            return Redirect("/Admin/Admin/Statements/" + Session["specialtyId"] + "#section2");
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpGet]
        public ActionResult DisplayUsers()
        {
            ApplicantUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicantUserManager>();
            var i = User.Identity; 
            ViewBag.ApplicantName = i.Name;
            ApplicantRepository appl = new ApplicantRepository();
            return View(appl.Applicants());
        }

        [CustomAuthorize(Roles = "moderator, admin")] 
        [HttpPost]
        public ActionResult DisplayUsers(FormCollection col)
        {
            ApplicantRepository applicant = new ApplicantRepository();
            applicant.Edit(col);
            return View(applicant.Applicants());
        }

        [CustomAuthorize(Roles = "admin")] 
        public ActionResult DeleteStatement(int id)
        {
            StatementRepository statement = new StatementRepository();
            statement.Delete(id);
            return Redirect("/Admin/Admin/Statements/" + (Session["specialtyId"])+"#section2");
        }

        public ActionResult Dispusers()
        {
            List<int> ConfirmedApplicantList = new List<int>();
            List<int> UnconfirmedApplicantList = new List<int>();
            DefineConfirmedApplicant confirmedApplicant = new DefineConfirmedApplicant();
            confirmedApplicant.Calculate(ConfirmedApplicantList, UnconfirmedApplicantList);
            ViewBag.ConfirmedApplicantList = ConfirmedApplicantList;
            ViewBag.UnconfirmedApplicantList = UnconfirmedApplicantList;
            return View("DisplayUserIs");
        }

        protected override void Dispose(bool disposing)
        {
            this.cityRepository.Dispose();
            this.universityRepository.Dispose(); 
            this.facultyRepository.Dispose();
            this.specialtyRepository.Dispose();
            this.subjectRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}