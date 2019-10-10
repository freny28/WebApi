using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1A.Models
{
    public class Member
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "You must provide a Fisrt Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must provide a Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must provide a Email")]
        public string Email { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        [DataType(DataType.Date)]
        public string BirthDate { get; set; }
    }
}
