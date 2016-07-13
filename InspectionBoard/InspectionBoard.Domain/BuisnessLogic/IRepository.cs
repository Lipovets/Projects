using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Domain.BuisnessLogic
{
    public interface IRepository<T>:IDisposable
        where T : class
    {  
        void Edit(T item);
        void Delete(int id);
        void Save();
        T FindById(int id);
    }
}
