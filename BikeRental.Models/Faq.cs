using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Faq
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }
        
        [Required]
        public string Answer { get; set; }
        public bool Enabled { get; set; }

    }
}