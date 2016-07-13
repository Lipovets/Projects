using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Domain.Entity
{
    public class IndexViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
