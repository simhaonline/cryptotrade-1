using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using BNKMVC.Services;

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
        public decimal Amount { get; set; }
        public string CurrencyDomination { get; set; }
        public TransactionTypeStatus TransactionType { get; set; }
        public TransactionStatus Status { get; set; }
    }

    public class CurrencyVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public Nullable<decimal> CurrentValueToDollar { get; set; }
    }

    public class ActivityVm
    {
        public int Id { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }

    public class WithdrawVm
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "BitCoin Wallet Required")]
        public string WalletId { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Amount Required")]

        public double Amount { get; set; }
        public decimal MaintainceFee { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string MaintainceFeeStatus { get; set; }
        public int AccountId { get; set; }
    }
}