using InspectionBoard.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionBoard.Domain.Context;

namespace InspectionBoard.Domain.BuisnessLogic.Admin
{
    public class CalculateResults
    {
        private InspectionBoardContext context;

        public CalculateResults()
        {
            this.context = new InspectionBoardContext();
        }

        public static bool isReckoned { get; set; }

        public void Calculate(ref List<int> totalList, ref List<int> budgetList) // adding some applicants to lists which define who where come in
        {
            StatementRepository state = new StatementRepository();
            List<Specialty> specialties; 
            specialties = context.Specialties.ToList();
            foreach(Specialty item in specialties)
            { 
                int i = 0;
                foreach(Statement index in state.StatementsForSpecialty(item.Id))
                {
                    if (i < item.BudgetAmount)
                    {
                        budgetList.Add(index.Id);
                        i++;
                    }
                    else
                    {
                        if (i < item.TotalAmount)
                        {
                            totalList.Add(index.Id);
                            i++;
                        }
                    }
                } 
            }
        }
    }
}
