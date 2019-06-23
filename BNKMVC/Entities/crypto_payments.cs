//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BNKMVC.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class crypto_payments
    {
        public int paymentID { get; set; }
        public int boxID { get; set; }
        public string boxType { get; set; }
        public string orderID { get; set; }
        public string userID { get; set; }
        public string countryID { get; set; }
        public string coinLabel { get; set; }
        public decimal amount { get; set; }
        public decimal amountUSD { get; set; }
        public byte unrecognised { get; set; }
        public string addr { get; set; }
        public string txID { get; set; }
        public Nullable<System.DateTime> txDate { get; set; }
        public byte txConfirmed { get; set; }
        public Nullable<System.DateTime> txCheckDate { get; set; }
        public byte processed { get; set; }
        public Nullable<System.DateTime> processedDate { get; set; }
        public Nullable<System.DateTime> recordCreated { get; set; }
    }
}
