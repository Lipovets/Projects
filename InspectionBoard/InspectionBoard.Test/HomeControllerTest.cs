using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InspectionBoard.Domain.BuisnessLogic.Admin;
using InspectionBoard.Domain.BuisnessLogic;
using InspectionBoard.Domain.Entity;
using InspectionBoard.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using InspectionBoard.Areas.Admin.Controllers;
using System.Web.WebPages;
using Microsoft.AspNet.Identity.EntityFramework;


namespace InspectionBoard.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        
        //CreateCityGet
        [TestMethod]
        public void AdminCreateViewNotNull()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        
        //Admin Edit City Get
        [TestMethod]
        public void AdminEditModelViewIsNotNull()
        {
            var mock = new Mock<IRepository<City>>();
            mock.Setup<City>(c => c.FindById(1)).Returns(new City() { });
            AdminController con = new AdminController(mock.Object);

            ViewResult result = con.Edit(1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        //Admin Edit City Post
        [TestMethod]
        public void AdminEditCityPost()
        {
            var mock = new Mock<IRepository<City>>();
            City city = new City();
            AdminController controller = new AdminController(mock.Object);

            RedirectToRouteResult result = controller.Edit(city) as RedirectToRouteResult;

            mock.Verify(a=>a.Edit(city));
        }

        
        
        //Admin Delete City
        [TestMethod]
        public void AdminDeleteCity()
        {
            var mock = new Mock<IRepository<City>>();
            City city = new City();
            AdminController controller = new AdminController(mock.Object); 
            RedirectToRouteResult result = controller.Delete(1) as RedirectToRouteResult;
            mock.Verify(a => a.Delete(1));

        }

        //Admin Create university Get 
        [TestMethod]
        public void AdminCreateUniversityNotNullView()
        {
            AdminController controller = new AdminController();

            ViewResult result = controller.CreateUniversity() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AdminEditUniversityViewModelIsnotNull()
        {
            var mock = new Mock<IRepository<University>>();
            mock.Setup<University>(c => c.FindById(1)).Returns(new University() { });
            AdminController controller = new AdminController(mock.Object);
            ViewResult result = controller.EditUniversity(1) as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void AdminUniversityEditPost()
        {
            var mock = new Mock<IRepository<University>>();
            University university = new University();
            AdminController controller = new AdminController(mock.Object);

            RedirectToRouteResult result = controller.EditUniversity(university) as RedirectToRouteResult;

            mock.Verify(a => a.Edit(university));
        }

        [TestMethod]
        public void AdminDeleteUniversity()
        {
            var mock = new Mock<IRepository<University>>(); 
            AdminController controller = new AdminController(mock.Object);
            RedirectToRouteResult result = controller.DeleteUniversity(1) as RedirectToRouteResult;
            mock.Verify(a => a.Delete(1));
        }

        [TestMethod]
        public void AdminCreateFacultyNotNullView()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.CreateFaculty() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AdminEditFacultyNotNullViewModel()
        {
            var mock = new Mock<IRepository<Faculty>>();
            mock.Setup<Faculty>(c => c.FindById(1)).Returns(new Faculty() { });
            AdminController con = new AdminController(mock.Object);

            ViewResult result = con.EditFaculty(1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void AdminEditFacultyPost()
        {
            var mock = new Mock<IRepository<Faculty>>();
            Faculty faculty = new Faculty();
            AdminController controller = new AdminController(mock.Object);

            RedirectToRouteResult result = controller.EditFaculty(faculty) as RedirectToRouteResult;

            mock.Verify(a => a.Edit(faculty));
        }

        [TestMethod]
        public void AdminFacultyDelete()
        {
            var mock = new Mock<IRepository<University>>();
            AdminController controller = new AdminController(mock.Object);
            RedirectToRouteResult result = controller.DeleteUniversity(1) as RedirectToRouteResult;
            mock.Verify(a => a.Delete(1));
        }

        //Specialty

        [TestMethod]
        public void AdminCreateSpecialtyNotNullView()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.CreateSpecialty() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AdminEditSpecialtyNotNullViewModel()
        {
            var mock = new Mock<IRepository<Specialty>>();
            mock.Setup<Specialty>(c => c.FindById(1)).Returns(new Specialty() { });
            AdminController con = new AdminController(mock.Object);

            ViewResult result = con.EditSpecialty(1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        

        [TestMethod]
        public void AdminSpecialtyDelete()
        {
            var mock = new Mock<IRepository<Specialty>>();
            AdminController controller = new AdminController(mock.Object);
            RedirectToRouteResult result = controller.DeleteSpecialty(1) as RedirectToRouteResult;
            mock.Verify(a => a.Delete(1));
        }
        //Subject
        [TestMethod]
        public void AdminCreateSubjectNotNullView()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.CreateSubject() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AdminEditSubjectNotNullViewModel()
        {
            var mock = new Mock<IRepository<Subject>>();
            mock.Setup<Subject>(c => c.FindById(1)).Returns(new Subject() { });
            AdminController con = new AdminController(mock.Object);

            ViewResult result = con.EditSubject(1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void AdminEditSubjectPost()
        {
            var mock = new Mock<IRepository<Subject>>();
            Subject subject = new Subject();
            AdminController controller = new AdminController(mock.Object);

            RedirectToRouteResult result = controller.EditSubject(subject) as RedirectToRouteResult;

            mock.Verify(a => a.Edit(subject));
        }

        [TestMethod]
        public void AdminSubjectDelete()
        {
            var mock = new Mock<IRepository<Subject>>();
            AdminController controller = new AdminController(mock.Object);
            RedirectToRouteResult result = controller.DeleteSubject(1) as RedirectToRouteResult;
            mock.Verify(a => a.Delete(1));
        }

        
       

    }
}
