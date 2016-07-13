using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InspectionBoard.Domain.Context;
using InspectionBoard.Domain.Entity;

namespace InspectionBoard.Domain.BuisnessLogic
{
    public class UniversityRepository:IRepository<University>
    {
        private InspectionBoardContext context;

        public UniversityRepository()
        {
            this.context = new InspectionBoardContext();
        }

        public IEnumerable<University> GetObjectList(int id)
        {
            return context.Universities.Where(x => x.CityId == id).ToList();
        }

        public void Create(University university, int id)
        {
            City city = context.Cities.Find(id);
            university.City = city; 
            context.Entry(university).State = EntityState.Added; 
            city.Universities.Add(university);
            context.Entry(city).State = EntityState.Modified;
            Save(); 
        }

        public void Edit(University university)
        {
            context.Entry(university).State = EntityState.Modified;
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

        public University FindById(int id)
        {
            return context.Universities.Find(id);
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
