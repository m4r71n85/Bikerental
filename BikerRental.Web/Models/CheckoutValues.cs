using BikerRental.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BikerRental.Web.Models
{
    public class CheckoutValues
    {
        public CheckoutValues(string amount, string description, string label)
        {
            this.amount = amount;
            this.description = description;
            this.label = label;
        }

        string loginID = "2rBH6x5n";
        string transactionKey = "776J47Be8kKA9Ccr";
        string amount;
        string description;
        string label;
        string testMode = "true";
        public string LoginID { get; }
        public string TransactionKey { get; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public string TestMode { get; set; }
        public string Sequence
        {
            get {
                Random random = new Random();
                return (random.Next(0, 1000)).ToString();
            }
        }
        public string Timestamp
        {
            get
            {
                return ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            }
        }
        public string FingerPrint
        {
            get
            {
                return CryptHelper.HMAC_MD5(transactionKey, loginID + "^" + this.Sequence + "^" + this.Timestamp + "^" + amount + "^");
            }
        }
        public string Invoice
        {
            get
            {
                return DateTime.Now.ToString("YmdHis");
            }
        }
    }
}