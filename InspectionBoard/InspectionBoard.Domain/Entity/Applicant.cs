using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace InspectionBoard.Domain.Entity
{
    public class Applicant:IdentityUser
    {  
        [Display(Name="Ім'я")]
        public string FirstName { get; set; }
                                  
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Display(Name = "Місто")]
        public string City { get; set; }

        [Display(Name = "Область")]
        public string Region { get; set; }

        [Display(Name = "Школа")]
        public string SchoolName { get; set; }

        [Display(Name = "Знімок атестату")]
        public byte[] Attestation { get; set; }
        public bool isBlocked { get; set; }

        public ICollection<Statement> Statements { get; set; }
        
        public Applicant()
        {
            Statements = new List<Statement>();
        }

    }
}
