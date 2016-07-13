using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.ComponentModel.DataAnnotations;

namespace InspectionBoard.Domain.Entity
{
    public class University 
    {
        public int Id { get; set; }

        [Display(Name = "Університет")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Name { get; set; }

        [Display(Name = "Тип ВНЗ")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Type { get; set; }

        [Display(Name = "Поштовий індекс")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string PostIndex { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Phone { get; set; }

        [Display(Name = "Веб-сайт")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string WebSite { get; set; }
         
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Невірно встановлено")]
        public string Email { get; set; }

        [Display(Name = "Вулиця")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public string Street { get; set; }

        [Display(Name = "Номер будівлі")]
        [Range(1, 1000, ErrorMessage = "Невірний номер")]
        [Required(ErrorMessage = "Поле повинне бути встановленим")]
        public int NumberOfBuild { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public ICollection<Faculty> Faculties { get; set; } 
        public University()
        { 
            Faculties = new List<Faculty>();
        }
    }
}
