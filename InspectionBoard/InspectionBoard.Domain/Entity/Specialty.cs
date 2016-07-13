using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace InspectionBoard.Domain.Entity
{
    public class Specialty
    {
        public int Id { get; set; }

        [Display(Name = "Спеціальність")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Name { get; set; }

        [Display(Name = "Держ.Зам.")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        [Range(1, 500, ErrorMessage = "Невірна кількість")]
        public int BudgetAmount { get; set; }

        [Display(Name = "Ліц.Обсяг.")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        [Range(1, 10000, ErrorMessage = "Невірна кількість.")]
        public int TotalAmount { get; set; }

        [Display(Name = "кількість заяв")]
        public int NumberOfApplications { get; set; }

        public ICollection<Faculty> Faculties { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Statement> Statements { get; set; }

        public Specialty()
        {
            Statements = new List<Statement>();
            Faculties = new List<Faculty>();
            Subjects = new List<Subject>();
        }
    }
}
