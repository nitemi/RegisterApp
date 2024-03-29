using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BGSchools.Models
{
    public class StudentRegistration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name e.g Ami Gold")]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("Email")]
        public string RetypeEmail { get; set; }

        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [Range(18, 30)]
        public string Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

    }
}