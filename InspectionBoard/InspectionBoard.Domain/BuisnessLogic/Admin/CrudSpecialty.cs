//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using InspectionBoard.Domain.Context;
//using InspectionBoard.Domain.Entity;

//namespace InspectionBoard.Domain.BuisnessLogic.Admin
//{
//    public class CrudSpecialty
//    {
//        ////repository
//        //public List<Specialty> DisplaySpecialties(int id)
//        //{
//        //    List<Specialty> specialties;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        Faculty faculty = context.Faculties.Include(x => x.Specialties).Where(x => x.Id == id).First();
//        //        specialties = faculty.Specialties.ToList();
//        //    }
//        //    return specialties;
//        //}

//        ////Repository
//        //public void Create(Specialty specialty, int id)
//        //{
//        //    Faculty faculty;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        faculty = context.Faculties.Find(id);
//        //        faculty.Specialties.Add(specialty);
//        //        context.Entry(faculty).State = EntityState.Modified;
//        //        specialty.Faculties.Add(faculty);
//        //        context.Entry(specialty).State = EntityState.Added;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////repository
//        //public Specialty Edit(int id)
//        //{
//        //    Specialty specialty;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        specialty = context.Specialties.Find(id);
//        //    }
//        //    return specialty;
//        //}

//        ////Repository
//        //public void Edit(Specialty specialty)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        context.Entry(specialty).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////Repository
//        //public void Delete(int id)
//        //{
//        //    Specialty specialty;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        specialty = context.Specialties.Find(id);
//        //        context.Entry(specialty).State = EntityState.Deleted;
//        //        context.SaveChanges();
//        //    }
//        //}
//        ////repo
//        //public Specialty FindById(int id)
//        //{
//        //    Specialty specialty;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        specialty = context.Specialties.Include(x => x.Statements).Where(x => x.Id == id).First();
//        //    }
//        //    return specialty;
//        //}

//        ////repository
//        //public Statement LoadApplicant(Statement statement)
//        //{
//        //    Statement state;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        state = context.Statements.Include(x => x.Applicant).Where(x => x.Id == statement.Id).First();
//        //    }
//        //    return state;
//        //}
        
//    }
//}
