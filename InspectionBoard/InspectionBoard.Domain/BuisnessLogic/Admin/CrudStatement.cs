//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using InspectionBoard.Domain.Entity;
//using InspectionBoard.Domain.Context;
//using System.Data.Entity;

//namespace InspectionBoard.Domain.BuisnessLogic.Admin
//{
//    public class CrudStatement
//    {
//        ////repository
//        //public List<Statement> Contest(int id)
//        //{
//        //    List<Statement> statements;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        statements = context.Statements.Where(x => x.SpecialtyId == id).ToList(); 
//        //    }
//        //    return statements;
//        //}

//        ////repository
//        //public void Create(Statement statement, Applicant applicant, Specialty specialty)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        //if()
//        //        specialty = context.Specialties.Find(specialty.Id);

//        //        specialty.Statements.Add(statement);

//        //        statement.Specialty = specialty;
//        //        statement.isConfirmed = false;
//        //        applicant = context.Applicants.Find(applicant.Id);
//        //        statement.Applicant = applicant;
//        //        statement.TotalMark = statement.Subject1 + statement.Subject2 + statement.Subject3 + statement.СreditСertificate;
//        //        context.Entry(specialty).State = EntityState.Modified;
//        //        context.Entry(statement).State = EntityState.Added;
//        //        context.SaveChanges();
                 
//        //    }
//        //}

//        ////repository
//        //public void AmountOfStatement(int id)
//        //{
//        //    int number = 0;
//        //    Specialty specialty;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        specialty = context.Specialties.Include(x => x.Statements).Where(x => x.Id == id).First();
//        //        number = specialty.Statements.ToList().Count();
//        //        specialty.NumberOfApplications = number;
//        //        context.Entry(specialty).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////repository
//        //public List<Statement> StatementsForSpecialty(int id)
//        //{
//        //    List<Statement> statements;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        Specialty specialty;
//        //        specialty = context.Specialties.Include(x => x.Statements).Where(x => x.Id == id).First();
//        //        statements = specialty.Statements.ToList(); 
//        //        statements.Sort((emp1, emp2) => emp1.TotalMark.CompareTo(emp2.TotalMark));
//        //        statements.Reverse();
//        //    }
//        //    return statements;
//        //}

//        ////repository
//        //public int NumberNotConfirmedStatements(int id)
//        //{
//        //    CrudStatement statement = new CrudStatement();
//        //    int count = 0;
//        //    foreach(var item in statement.StatementsForSpecialty(id))
//        //    {
//        //        if(!item.isConfirmed)
//        //        {
//        //            count++;
//        //        }
//        //    }
//        //    return count;
//        //}

//        //// repository
//        //public Applicant ApplicantToStatement(int id)
//        //{
//        //    Applicant applicant;
//        //    Statement statement;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        statement = context.Statements.Include(x => x.Applicant).Where(x => x.Id == id).First();
//        //        applicant = statement.Applicant;
//        //    }
//        //    return applicant;
//        //}

//        ////repository
//        //public void Edit(int id)
//        //{
//        //    Statement stat;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        stat = context.Statements.Include(x => x.Applicant).Where(x => x.Id == id).First();
//        //        stat.isConfirmed = true;
//        //        context.Entry(stat).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////repository
//        //public Statement FindById(int id)

//        //{
//        //    Statement statement;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        statement = context.Statements.Include(x => x.Specialty).Where(x => x.Id == id).First();
//        //    }
//        //    return statement;
//        //}

//        ////repository
//        //public void Delete(int id)
//        //{
//        //    Statement statement;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        statement = context.Statements.Find(id);
//        //        context.Entry(statement).State = EntityState.Deleted;
//        //        context.SaveChanges();
//        //    }
//        //}
        
//    }
//}
