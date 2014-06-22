using BikerRental.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BikerRental.Web.Models
{
    public class CheckoutModel
    {
        public CheckoutModel(string description, string label)
        {
            this.description = description;
            this.label = label;
        }

        string loginID = "2rBH6x5n";
        string transactionKey = "2Y34GkkCskQ387dP";
        string amount;
        string description;
        string label;
        string testMode = "true";
        string url = "https://test.authorize.net/gateway/transact.dll";
        public string LoginID
        {
            get
            {
                return loginID;
            }
        }
        public string TransactionKey { get { return TransactionKey; } }
        public string Amount { get { return amount; } set { amount = value; } }
        public string Description { get { return description; }}
        public string Label { get { return label; } }
        public string TestMode { get { return testMode; } }
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

        public string Url
        {
            get
            {
                return url;
            }
        }
        public string Md5Verification { get { return "0A15465E73EA5BE380BF33EEAD00AAD7"; } private set { } }
        public string CustomVerification {
            get {

                return CryptHelper.HMAC_MD5(transactionKey, this.Md5Verification + this.Amount + DateTime.Now.ToString("M/d/yyyy") + "salt this hash");
            }
            private set { }
        }
        public string SecureId
        {
            get
            {
                return CartHelper.UserCart.SessionId;
            }
            private set { }
        }
    }
}