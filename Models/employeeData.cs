using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MIS4200_Team2.Models
{
    public class employeeData
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Primary Phone Number")]
        [Phone]
        public string phoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }


        [Display(Name = "Office Location")]
        public string officeLocation { get; set; }

        [Display(Name = "Current Position")]
        public string position { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime hireDate { get; set; }

        public string fullName 
            { get
            { return firstName + " " + lastName; }  
                }
    }
}