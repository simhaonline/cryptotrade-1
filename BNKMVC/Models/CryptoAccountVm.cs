using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BNKMVC.Models
{
    public class CryptoAccountVm
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> AccountTypeId { get; set; }
        public Nullable<int> CurrencyId { get; set; }

        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public Nullable<decimal> CurrentCryptoBalance { get; set; }
    }

    public class VerificationVm
    {
        public int Id { get; set; }
        public int CryptoAccountId { get; set; } 

        [Required(ErrorMessage = "Document Upload Required")]
        public string DocumentUrl { get; set; }
        [Required (ErrorMessage = "Document Type Required")]
        public string VerificationType { get; set; }
        public string Status { get; set; }

}

    public class TransactionVm
    {
        public int Id { get; set; }
        public int accountId { get; set; }
        public DateTime DateTime { get; set; }
        public string Amount { get; set; }
        public string CurrencyDomination { get; set; }
        public string TransactionType { get; set; }
        public string Status { get; set; }
    }

    public class CurrencyVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public Nullable<decimal> CurrentValueToDollar { get; set; }
    }
}