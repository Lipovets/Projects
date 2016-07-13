using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class PhotoRepository:IRepository<Photo>
    {
        private GramContext db;

        public PhotoRepository(GramContext context)
        {
            this.db = context;
        }

        public IEnumerable<Photo> GetAll()
        {
            return db.Photos.ToList();
        }

        public Photo Get(int id)
        {
            return db.Photos.Find(id);
        }

        public void Create(Photo item)
        {
            db.Photos.Add(item);
        }

        public void Update(Photo item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Photo photo = db.Photos.Find(id);
            if (photo != null)
            {
                db.Entry(photo).State = EntityState.Deleted;
            }
        }
    }
}
