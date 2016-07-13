using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Domain.Entity
{
    public class Statement
    {
        public int Id { get; set; }

        [Display(Name = "Предмет 1")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        [Range(100, 200, ErrorMessage = "Невірний бал.")]
        public double Subject1 { get; set; }

        [Display(Name = "Предмет 2")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        [Range(100, 200, ErrorMessage = "Невірний бал.")]
        public double Subject2 { get; set; }

        [Display(Name = "Предмет 3")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        [Range(100, 200, ErrorMessage = "Невірний бал.")]
        public double Subject3 { get; set; }

        [Display(Name = "Сума балів")]
        public double TotalMark { get; set; }

        [Display(Name = "Бал атетату")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        [Range(100, 200, ErrorMessage = "Невірний бал.")]
        public double СreditСertificate { get; set; }

        public bool isConfirmed { get; set; }

        public Applicant Applicant { get; set; }
        public int? ApplicantId { get; set; }

        public Specialty Specialty { get; set; }
        public int? SpecialtyId { get; set; }
    }
}
