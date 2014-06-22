using BikerRental.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BikerRental.Web.Models
{
    public static class CheckoutModel
    {

        private static string loginID = "2rBH6x5n";
        private static string transactionKey = "2Y34GkkCskQ387dP";
        private static string amount;
        private static string description = "Description...";
        private static string label = "Label..";
        private static string testMode = "true";
        private static string url = "https://test.authorize.net/gateway/transact.dll";
        public static string LoginID
        {
            get
            {
                return loginID;
            }
        }
        public static string TransactionKey { get { return TransactionKey; } }
        public static string Amount { get { return CartHelper.GetTotal().ToString(); } }
        public static string Description { get { return description; }}
        public static string Label { get { return label; } }
        public static string TestMode { get { return testMode; } }
        public static string Sequence
        {
            get {
                Random random = new Random();
                return (random.Next(0, 1000)).ToString();
            }
        }
        public static string Timestamp
        {
            get
            {
                return ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds).ToString();
            }
        }
        public static string FingerPrint
        {
            get
            {
                return CryptHelper.HMAC_MD5(transactionKey, loginID + "^" + Sequence + "^" + Timestamp + "^" + amount + "^");
            }
        }
        public static string Invoice
        {
            get
            {
                return DateTime.Now.ToString("YmdHis");
            }
        }

        public static string Url
        {
            get
            {
                return url;
            }
        }
        public static string Md5Verification { get { return "0A15465E73EA5BE380BF33EEAD00AAD7"; } private set { } }
        public static string CustomVerification {
            get {

                return CryptHelper.HMAC_MD5(transactionKey, Md5Verification + Amount + DateTime.Now.ToString("M/d/yyyy") + "salt this hash");
            }
            private set { }
        }
        public static string SecureId
        {
            get
            {
                return CartHelper.UserCart.SessionId;
            }
            private set { }
        }
    }
}