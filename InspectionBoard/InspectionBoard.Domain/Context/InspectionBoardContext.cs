using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InspectionBoard.Domain.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InspectionBoard.Domain.Context
{
    public class InspectionBoardContext:IdentityDbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Statement> Statements { get; set; }

        public InspectionBoardContext() : base("InspectionBoardContext") { }

        public static InspectionBoardContext Create()
        {
            return new InspectionBoardContext();
        }
    }
}
