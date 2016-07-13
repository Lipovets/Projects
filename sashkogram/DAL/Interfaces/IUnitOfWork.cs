using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Photo> Photos { get; }
        IRepository<Profile> Profiles { get; }
        void Save();
    }
}
