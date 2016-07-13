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
    public class CityRepository:IRepository<City>
    {
        private InspectionBoardContext context;

        public CityRepository()
        {
            this.context = new InspectionBoardContext();
        }

        public IEnumerable<City> GetObjectList()
        {
            return context.Cities.ToList();
        }

        public void Create(City city)
        {
            context.Entry(city).State = EntityState.Added;
           
            Save();
        }

        public void Edit(City city)
        {
            context.Entry(city).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            City city = context.Cities.Find(id);
            if(city!=null)
            {
                context.Entry(city).State = EntityState.Deleted;
                Save();
            }
        }

        public City FindById(int id)
        {
            return context.Cities.Find(id);
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
