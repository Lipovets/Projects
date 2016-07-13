using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionBoard.Domain.Entity;
using System.Data.Entity;
using InspectionBoard.Domain.Context;
using System.Web.Mvc;

namespace InspectionBoard.Domain.BuisnessLogic
{
    public class ApplicantRepository:IApplicant<Applicant>
    {
        private InspectionBoardContext context;

        public ApplicantRepository()
        {
            this.context = new InspectionBoardContext();
        }

        public Applicant FindApplicantByEmail(string email)
        { 
            return context.Applicants.Where(x => x.UserName == email).First();
        }

        public List<Applicant> Applicants()
        { 
            return context.Applicants.ToList();
        }

        public void Edit(FormCollection col)
        {
            string email = col["Email"];
            int isBlocked = int.Parse(col["Block"]);
            Applicant applicant = FindApplicantByEmail(email);
                if (isBlocked == 0)
                {
                    applicant.isBlocked = false;
                }
                else if (isBlocked == 1)
                {
                    applicant.isBlocked = true;
                }

                context.Entry(applicant).State = System.Data.Entity.EntityState.Modified;
                Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
