using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeRental.Models
{
    public class Feedback
    {
        private DateTime createdAt;
        public Feedback()
        {
            this.createdAt = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { 
            get { return this.createdAt; }
            set 
            { 
                this.createdAt = value; 
            }
        }

        [Required]
        public int Rating { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
    }
}