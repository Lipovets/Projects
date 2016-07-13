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
//    public class CrudCity
//    {
//        //REPOSITORy
//        //public List<City> DisplayAllCities()
//        //{
//        //    List<City> cities;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        cities = context.Cities.ToList();
//        //    }
//        //    return cities;
//        //}

//        //REPOSITORy
//        //public void Create(City city)
//        //{
//        //    using (InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        context.Entry(city).State = EntityState.Added;
//        //        context.SaveChanges();
//        //    }
//        //}

//        //REPOSITORy
//        //public City Edit(int id)
//        //{
//        //    City city;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        city = context.Cities.Find(id);
//        //    }
//        //    return city;
//        //}

//        //REPOSITORy
//        //public void Edit(City city)
//        //{
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        context.Entry(city).State = EntityState.Modified;
//        //        context.SaveChanges();
//        //    }
//        //}

//        //REPOSITORy
//        //public void Delete(int id)
//        //{   
//        //    City city;
//        //    using(InspectionBoardContext context = new InspectionBoardContext())
//        //    {
//        //        city = context.Cities.Find(id);
//        //        context.Entry(city).State = EntityState.Deleted;
//        //        context.SaveChanges();
//        //    }
//        //}
//    }
//}
