//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using InspectionBoard.Domain.Entity;
//using InspectionBoard.Domain.Context;
//namespace InspectionBoard.Domain.BuisnessLogic.Admin
//{
//    public class CrudFaculty
//    {
//        ////REpository
//        //public List<Faculty> DisplayForUniversity(int id )
//        //{
//        //    List<Faculty> faculties;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        faculties = context.Faculties.Where(x => x.UniversityId == id).ToList();
//        //    }
//        //    return faculties;
//        //}

//        ////REpository
//        //public void Create(Faculty faculty, int id)
//        //{
//        //    University university;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        university = context.Universities.Find(id);
//        //        university.Faculties.Add(faculty);
//        //        faculty.University = university;
//        //        //faculty.UniversityId = university.Id;
//        //        context.Entry(university).State = EntityState.Modified;
//        //        context.Entry(faculty).State = EntityState.Added;
//        //        context.SaveChanges();
//        //    }

//        //}

//        ////REpository
//        //public Faculty Edit(int id)
//        //{
//        //    Faculty faculty;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        faculty = context.Faculties.Find(id);
//        //    }
//        //    return faculty;
//        //}

//        ////REpository
//        //public void Edit(Faculty faculty)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        context.Entry(faculty).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////REpository
//        //public void Delete(int id)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        Faculty faculty = context.Faculties.Find(id);
//        //        context.Entry(faculty).State = EntityState.Deleted;
//        //        context.SaveChanges();
//        //    }
//        //}
//    }
//}
