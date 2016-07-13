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
//    public class CrudUniversity
//    {
//        ////Repository
//        //public List<University> DisplayForCity(int id) //city
//        //{
//        //    List<University> universities;
//        //    using (InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        universities = context.Universities.Where(x => x.CityId == id).ToList();
//        //    }
//        //    return universities;
//        //}

//        ////Repository
//        //public void Create(University university, int id)
//        //{
//        //    City city;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        city = context.Cities.Find(id);
//        //        university.City = city;
//        //        //university.CityId = id;
//        //        context.Entry(university).State = EntityState.Added;
//        //        //city = context.Cities.Find(id);
//        //        city.Universities.Add(university);
//        //        context.Entry(city).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////Repository
//        //public University Edit(int id)
//        //{
//        //    University university;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        university = context.Universities.Find(id);
//        //    }
//        //    return university;
//        //}

//        ////Repository
//        //public void Edit(University university)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        context.Entry(university).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        ////Repository
//        //public void Delete(int id)
//        //{
//        //    University university;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        university = context.Universities.Find(id);
//        //        context.Entry(university).State = EntityState.Deleted;
//        //        context.SaveChanges();
//        //    }
//        //}
//    }
//}
