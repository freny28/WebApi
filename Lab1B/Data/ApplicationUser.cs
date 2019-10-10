using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1B.Data
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "You must provide a Fisrt Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must provide a Last Name")]
        public string LastName { get; set; }
        public string Company { get; set; }

        public string Position { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }

    }
}
