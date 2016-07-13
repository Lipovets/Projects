using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class GramContext:DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public GramContext(string connectionString)
            : base(connectionString)
        {
            
        }

        static GramContext()
        {
            Database.SetInitializer<GramContext>(new DropCreateDatabaseIfModelChanges<GramContext>());
        }

        //public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<GramContext>
        //{
        //    protected override void Seed(GramContext db)
        //    {
        //        Profile profile = new Profile() { Name = "sashko_gear", ProfileStatus = ".Net Asp Mvc" };
        //        db.Profiles.Add(profile);
        //        db.SaveChanges();
        //    }
        //}
    }
}
