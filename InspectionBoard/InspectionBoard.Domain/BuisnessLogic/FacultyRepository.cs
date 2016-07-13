using InspectionBoard.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InspectionBoard.Domain.Context; 

namespace InspectionBoard.Domain.BuisnessLogic
{
    public class FacultyRepository:IRepository<Faculty>
    {
        private InspectionBoardContext context;

        public FacultyRepository()
        {
            this.context = new InspectionBoardContext();
        }

        //not from interface
        public IEnumerable<Faculty> GetObjectList(int id)
        {
            return context.Faculties.Where(x => x.UniversityId == id).ToList();
        }

        //not from interface
        public void Create(Faculty faculty, int id)
        {
            University university = context.Universities.Find(id);
            university.Faculties.Add(faculty);
            faculty.University = university;
            context.Entry(university).State = EntityState.Modified;
            context.Entry(faculty).State = EntityState.Added;
            Save();
        }

        public void Edit(Faculty faculty)
        {
            context.Entry(faculty).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            University university = context.Universities.Find(id);
            if(university!=null)
            {
                context.Entry(university).State = EntityState.Deleted;
                Save();
            }
        }

        public Faculty FindById(int id)
        {
            return context.Faculties.Find(id);
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
