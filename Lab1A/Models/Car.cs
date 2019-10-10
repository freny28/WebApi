using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1A.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "You must provide a Make")]
        public string Make { get; set; }

        [Required(ErrorMessage = "You must provide a Model")]
        public string Model { get; set; }

        [Range(2010, 2020)]
        public int Year { get; set; }

        [Required(ErrorMessage = "You must provide a VIN")]
        public int VIN { get; set; }

        public string Colour { get; set; }

        public int DealershipID { get; set; }
    }
}
