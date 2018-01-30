using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cargo4You.Models
{
    public class Package
    {
        [Display(Name = "Package ID")]
        public int id { get; set; }

        [Range(0, 100000, ErrorMessage = "Height must be more than 0")]
        [Display(Name = "Height")]
        public double height { get; set; }

        [Range(0, 100000, ErrorMessage = "Width must be more than 0")]
        [Display(Name = "Width")]
        public double width { get; set; }

        [Range(0, 100000, ErrorMessage = "Depth must be more than 0")]
        [Display(Name = "Depth")]
        public double depth { get; set; }
        
        [Display(Name = "Volume")]
        public double vol { get; set; }

        [Range(0, 100000, ErrorMessage = "Weight must be more than 0")]
        [Display(Name = "Weight")]
        public double weight { get; set; }

        [Display(Name = "Dimensions Price")]
        public double dprice { get; set; }

        [Display(Name = "Weight Price")]
        public double wprice { get; set; }

        [Display(Name = "Final Price")]
        public double price { get; set; }
    }
}