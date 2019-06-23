using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BNKMVC.Models
{
    public class TransferDto
    {
        public string accountNo { get; set; }
        public string bName { get; set; }
        public string destinationAccountNo { get; set; }
        public string bBankName { get; set; }
        public int swiftCode { get; set; }
        public string address { get; set; }
        public string iban { get; set; }
        public string purpose { get; set; }
        public decimal amount { get; set; }
        public string cot { get; set; }
        public string tax { get; set; }
        public string imf { get; set; }
    }
}