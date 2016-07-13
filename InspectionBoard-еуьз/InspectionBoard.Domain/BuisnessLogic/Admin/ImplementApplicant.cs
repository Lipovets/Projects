//using InspectionBoard.Domain.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using InspectionBoard.Domain.Context;
//using System.Web.Mvc;

//namespace InspectionBoard.Domain.BuisnessLogic.Admin
//{
//    public class ImplementApplicant
//    {
//        ////repo
//        //public Applicant FindApplicantById(string email)
//        //{
//        //    Applicant applicant;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        applicant = context.Applicants.Where(x => x.UserName == email).First();
//        //    }
//        //    return applicant;
//        //}

//        ////repo
//        //public List<Applicant> Applicants()
//        //{
//        //    List<Applicant> applicants;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        applicants = context.Applicants.ToList();
//        //    }
//        //    return applicants;
//        //}

//        ////repo
//        //public void Edit(FormCollection col)
//        //{
//        //    string email = col["Email"];
//        //    int isBlocked = int.Parse(col["Block"]);
//        //    Applicant applicant;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        applicant = FindApplicantById(email);
//        //        if(isBlocked==0)
//        //        {
//        //            applicant.isBlocked = false;
//        //        }
//        //        else if(isBlocked==1)
//        //        {
//        //            applicant.isBlocked = true;
//        //        }

//        //        context.Entry(applicant).State = System.Data.Entity.EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}
//    }
//}
