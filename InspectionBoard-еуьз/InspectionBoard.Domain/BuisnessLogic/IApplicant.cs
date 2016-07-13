using InspectionBoard.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InspectionBoard.Domain.BuisnessLogic
{
    public interface IApplicant<T>
    {
        T FindApplicantByEmail(string email);
        List<T> Applicants();
        void Edit(FormCollection col);
    }
}
