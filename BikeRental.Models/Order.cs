//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace BikeRental.Models
//{
//    public class Order
//    {
//        //Payment Details
//        public int Id { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public PaymentType PaymentType { get; set; }
//        public int CardNumber { get; set; }
//        public int CvvNumber { get; set; }
//        public decimal OrderTotal { get; set; }
//        public string CardType { get; set; }
//        public Decimal ExpiryDate { get; set; }

//        //Customer Information
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string CompanyName { get; set; }
//        public string Address { get; set; }
//        public string City { get; set; }
//        public string State { get; set; }
//        public int Zip { get; set; }
//        public string Country { get; set; }
//        public string Email { get; set; }
//        public string PhoneNumber { get; set; }
//        public string FaxNumber { get; set; }

//        //Shipping Information
//        public string Name { get; set; }
//        public string CompanyName { get; set; }
//        public string MyProperty { get; set; }

//    }
//}