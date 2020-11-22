using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auto_Dealership_Management_System.Models
{
    public class CarModels
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Models { get; set; }
        [Required]
        public string Variants { get; set; }
        [Required]
        public float Price { get; set; }

    }
}