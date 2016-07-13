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
    public class StatementRepository// : IRepository<Statement>
    {
        private InspectionBoardContext context;

        public StatementRepository()
        {
            this.context = new InspectionBoardContext();
        }

        public IEnumerable<Statement> GetObjectList(int id) //Contest конкурс
        {
            return context.Statements.Where(x => x.SpecialtyId == id).ToList();
        }

        //not repository
        public void Create(Statement statement, Applicant applicant, Specialty specialty)
        {
            specialty = context.Specialties.Find(specialty.Id);
            specialty.Statements.Add(statement);
            statement.Specialty = specialty;
            statement.isConfirmed = false;
            applicant = context.Applicants.Find(applicant.Id);
            statement.Applicant = applicant;
            statement.TotalMark = statement.Subject1 + statement.Subject2 + statement.Subject3 + statement.СreditСertificate;
            context.Entry(specialty).State = EntityState.Modified;
            context.Entry(statement).State = EntityState.Added;
            Save();
        }

        public void AmountOfStatement(int id)
        {
            int number = 0;
            Specialty specialty = context.Specialties.Include(x => x.Statements).Where(x => x.Id == id).First();
            number = specialty.Statements.ToList().Count();
            specialty.NumberOfApplications = number;
            context.Entry(specialty).State = EntityState.Modified;
            Save();
        }

        public List<Statement> StatementsForSpecialty(int id)
        {
            Specialty specialty = context.Specialties.Include(x => x.Statements).Where(x => x.Id == id).First();
            List<Statement> statements = specialty.Statements.ToList();
            statements.Sort((emp1, emp2) => emp1.TotalMark.CompareTo(emp2.TotalMark));
            statements.Reverse();
            return statements;
        }

        public int NumberNotConfirmedStatements(int id)
        {
            int count = 0;
            foreach (var item in StatementsForSpecialty(id))
            {
                if (!item.isConfirmed)
                {
                    count++;
                }
            }
            return count;
        }

        public void Edit(int id)
        {
            Statement stat = context.Statements.Include(x => x.Applicant).Where(x => x.Id == id).First();
            stat.isConfirmed = true;
            context.Entry(stat).State = EntityState.Modified;
            Save();
        }

        public Statement FindById(int id)
        {
            return context.Statements.Include(x => x.Specialty).Where(x => x.Id == id).First();
        }

        public void Delete(int id)
        {
            Statement statement = context.Statements.Find(id);
            if(statement!=null)
            {
                context.Entry(statement).State = EntityState.Deleted;
                Save();
            }
        }

        public Applicant ApplicantToStatement(int id)
        {
            Statement statement = context.Statements.Include(x => x.Applicant).Where(x => x.Id == id).First();
            return  statement.Applicant;
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
