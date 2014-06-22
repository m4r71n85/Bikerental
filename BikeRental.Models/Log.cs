namespace BikeRental.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Log
    {
        private DateTime createdDate = DateTime.Now;
        public int Id { get; set; }
        public DateTime CreatedDate {
            get { return createdDate; }
            private set { createdDate = DateTime.Now; } 
        }
        public int Code { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}