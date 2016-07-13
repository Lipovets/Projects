using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private GramContext db;
        private PhotoRepository photoRepository;
        private ProfileRepository profileRepository;

        public EFUnitOfWork(string connectionStr)
        {
            db = new GramContext(connectionStr);
        }

        public IRepository<Photo> Photos
        {
            get
            {
                if(photoRepository==null)
                {
                    photoRepository = new PhotoRepository(db);
                }
                return photoRepository;
            }
        }

        public IRepository<Profile> Profiles
        {
            get
            {
                if(profileRepository==null)
                {
                    profileRepository = new ProfileRepository(db);
                }
                return profileRepository;
            }
        }

        
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
