using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace InspectionBoard.Domain.Entity
{
    public class City  
    {
        public int Id { get; set; }

        [Display(Name = "Місто")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Name { get; set; }

        public ICollection<University> Universities { get; set; }
        public City()
        {
            Universities= new List<University>();
        }
    }
}
