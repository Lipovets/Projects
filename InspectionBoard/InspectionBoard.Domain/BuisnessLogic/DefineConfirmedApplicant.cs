using InspectionBoard.Domain.Context;
using InspectionBoard.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Domain.BuisnessLogic
{
    public class DefineConfirmedApplicant
    {
        private InspectionBoardContext context;

        public DefineConfirmedApplicant()
        {
            this.context = new InspectionBoardContext();
        }

        public void Calculate(List<int> ConfirmedUserList, List<int> UnConfirmedUserList) // adding some applicants to lists which define who where come in
        {
            StatementRepository state = new StatementRepository();
            List<Specialty> specialties;
            specialties = context.Specialties.ToList();

            foreach (Specialty item in specialties)
            {
                int i = 0;
                foreach (Statement index in state.StatementsForSpecialty(item.Id))
                {

                    if (i < item.TotalAmount)
                    {
                        ConfirmedUserList.Add(index.Id);
                        i++;
                    }
                    else
                    {
                        UnConfirmedUserList.Add(index.Id);
                    }
                }
            }
        }

        //public void F()
        //{
        //    List<City> cities;
        //    using(InspectionBoardContext context = new InspectionBoardContext())
        //    {
        //        cities = context.Cities.ToList();
        //        foreach(var item in cities)
        //        {

        //        }
        //    }
        //}
    }
}
