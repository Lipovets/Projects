using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionBoard.Domain.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace InspectionBoard.Domain.Entity
{
    public class AdminRoleInit : DropCreateDatabaseIfModelChanges<InspectionBoardContext>
    {
        protected override void Seed(InspectionBoardContext context)
        {
            var userManager = new ApplicantUserManager(new UserStore<Applicant>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "moderator" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);

            // создаем пользователей
            var admin = new Applicant
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                isBlocked = false
                //Attestation = new byte[] { 1, 0, 1 },
                //City = "kharkiv",
                //FirstName = "admin",
                //LastName = "admin",
                //MiddleName = "admin",
                //Region = "kharkiv",
                //SchoolName = "kharkiv"
            };
            string password = "eputob37";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
            }

            var moderator = new Applicant { 
                Email = "moderator@gmail.com", 
                UserName = "moderator@gmail.com", 
                isBlocked = false
                //Attestation = new byte[] { 1, 0, 1 },
                //City = "kharkiv",
                //FirstName = "moderator",
                //LastName = "moderator",
                //MiddleName = "moderator",
                //Region = "kharkiv",
                //SchoolName = "kharkiv"
            };

            result = userManager.Create(moderator, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(moderator.Id, role3.Name);
            }


            base.Seed(context);
        }
    }
}
