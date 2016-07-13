using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InspectionBoard.Domain.Entity
{
    public class RegisterModel
    {
        [Display(Name = "Ім'я")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Прізвище")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "По-батькові")]
        [Required]
        public string MiddleName { get; set; }

        [Display(Name = "Місто")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Область")]
        [Required]
        public string Region { get; set; }

        [Display(Name = "Школа")]
        [Required]
        public string SchoolName { get; set; }

        [Display(Name = "Знімок атестату")]
        public byte[] Attestation { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Підтвердіть пароль")]
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
