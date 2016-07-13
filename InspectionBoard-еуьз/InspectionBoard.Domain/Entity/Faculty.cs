using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace InspectionBoard.Domain.Entity
{
    public class Faculty 
    {
        public int Id { get; set; }

        [Display(Name = "Факультет")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Name { get; set; }

        public int? UniversityId { get; set; }
        public University University { get; set; }

        public ICollection<Specialty> Specialties { get; set; }
        public Faculty()
        { 
            Specialties = new List<Specialty>();
        }
    }
}
