using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
using BNKMVC.Models;

namespace BNKMVC.Services
{
    public enum TransactionTypeStatus
    {
        Withdraw, Credit
    }
    public class CryptoTransaction
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedId;
        public CryptoTransaction()
        {
            context = new mbankEntities();
        }
     
        public bool Create(TransactionVm m)
        {
            try
            {
                var save = context.CR_Transactions.Add(new CR_Transactions()
                {
                   Status = m.Status.ToString(),
                   AccountId = m.accountId,
                   Amount = m.Amount,
                   TransactionType = m.TransactionType.ToString(),
                   DateCreated = DateTime.UtcNow,
                  
                   
                });
                context.SaveChanges();
                savedId = save.Id;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool SetStatus(int transactionId, TransactionStatus status)
        {
            try
            {
                var find = context.CR_Transactions.Find(transactionId);
                if (find != null)
                {
                    find.Status = status.ToString();
                    context.Entry(find).State = EntityState.Modified;

                    context.SaveChanges();

                }


                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(int transactionId)
        {
            try
            {
                var find = context.CR_Transactions.Find(transactionId);
                if (find != null)
                {
                    context.CR_Transactions.Remove(find);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<CR_Transactions> Transactions()
        {
            var t = context.CR_Transactions.ToList();
            return t;
        }

        public List<CR_Transactions> Transactions(int accountId)
        {
            var t = context.CR_Transactions.Where(a=>a.AccountId == accountId)
                .Include(a=>a.CR_Account)
                .Include(a=>a.CR_Account.AspNetUser)
                .ToList();
            return t;
        }

    }
}