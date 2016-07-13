using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.EF;

namespace DAL.Repositories
{
    public class ProfileRepository:IRepository<Profile>
    {
        private GramContext db;

        public ProfileRepository(GramContext context)
        {
            this.db = context;
        }

        public IEnumerable<Profile> GetAll()
        {
            return db.Profiles.ToList();
        }

        public Profile Get(int id)
        {
            return db.Profiles.Include(c => c.ProfilePhotos).Include(v=>v.Avatars).First(c => c.Id == id); //there
        }

        public void Create(Profile item)
        {
            db.Profiles.Add(item);
        }

        public void Update(Profile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Profile profile = db.Profiles.Find(id);
            if (profile != null)
            {
                db.Entry(profile).State = EntityState.Modified;
            }
        }
    }
}
