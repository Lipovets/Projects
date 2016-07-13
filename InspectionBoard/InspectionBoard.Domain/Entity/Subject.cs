using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace InspectionBoard.Domain.Entity
{
    public class Subject  
    {
        public int Id { get; set; }

        [Display(Name = "Назва предмету")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Name { get; set; } 

        public ICollection<Specialty> Specialties { get; set; }
        public Subject()
        {
            Specialties = new List<Specialty>();
        }
    }
}
