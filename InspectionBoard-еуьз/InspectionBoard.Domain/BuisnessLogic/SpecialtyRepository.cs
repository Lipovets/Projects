using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionBoard.Domain.Entity;
using System.Data.Entity;
using InspectionBoard.Domain.Context;

namespace InspectionBoard.Domain.BuisnessLogic
{
    public class SpecialtyRepository:IRepository<Specialty>
    {
        private InspectionBoardContext context;

        public SpecialtyRepository()
        {
            this.context = new InspectionBoardContext();
        }

        //not repository
        public IEnumerable<Specialty> GetObjectList(int id)
        {
            Faculty faculty = context.Faculties.Include(x => x.Specialties).Where(x => x.Id == id).First();
            return faculty.Specialties.ToList();
        }

        public void Create(Specialty specialty, int id)
        {
            Faculty faculty = context.Faculties.Find(id);
            faculty.Specialties.Add(specialty);
            context.Entry(faculty).State = EntityState.Modified;
            specialty.Faculties.Add(faculty);
            context.Entry(specialty).State = EntityState.Added;
            Save();
        }

        public void Edit(Specialty specialty)
        {
            context.Entry(specialty).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Specialty specialty = context.Specialties.Find(id);
            if (specialty != null)
            {
                context.Entry(specialty).State = EntityState.Deleted;
                Save();
            }
        }

        public Specialty FindById(int id)
        {
            return context.Specialties.Include(x => x.Statements).Where(x => x.Id == id).First();
        }

        public Statement LoadApplicant(Statement statement)
        {
            return context.Statements.Include(x => x.Applicant).Where(x => x.Id == statement.Id).First();
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
