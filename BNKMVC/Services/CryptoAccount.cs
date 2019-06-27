using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
using BNKMVC.Models;

namespace BNKMVC.Services
{
    public enum AccountStatus
    {
        PENDING, APPROVED, DENYED
    }
    public class CryptoAccount
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedAccountId;
        public CryptoAccount()
        {
            context = new mbankEntities();
        }

        public bool CreateAccount(CryptoAccountVm m)
        {
            try
            {
                var save = context.CR_Account.Add(new CR_Account()
                {
                    AccountTypeId = m.AccountTypeId,
                    UserId = m.UserId,
                    CurrencyId = m.CurrencyId,
                    CurrentCryptoBalance = (decimal?) 0.000000, 
                    Status = AccountStatus.PENDING.ToString(),
                    DateCreated = DateTime.UtcNow
                });
                context.SaveChanges();
                savedAccountId = save.Id;
                return true;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public bool Credit(int accountId, double amount)
        {
            try
            {
                var find = context.CR_Account.Find(accountId);
                if (find != null)
                {
                    find.CurrentCryptoBalance += Convert.ToDecimal(amount);
                    context.Entry(find).State = EntityState.Modified;
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
        public bool Debit(int accountId, double amount)
        {
            try
            {
                var find = context.CR_Account.Find(accountId);
                if (find != null)
                {
                    find.CurrentCryptoBalance -= Convert.ToDecimal(amount);
                    context.Entry(find).State = EntityState.Modified;
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

        public CR_Account Get(int accountId)
        {
            return context.CR_Account.Where(a => a.Id == accountId).
                Include(a => a.CR_Transactions)
                .Include(a => a.CR_Activity)
                .Include(a => a.CR_Verification)
                .Include(a => a.AspNetUser.Country)
                .Include(a=>a.CR_AccountType)
                .Include(a => a.AspNetUser).SingleOrDefault();
        }

        public CR_Account GetUser(int accountId)
        {
            var user = context.CR_Account.Where(a => a.Id == accountId)
                .Include(a=>a.CR_Transactions)
                .Include(a=>a.CR_Activity)
                .Include(a=>a.CR_Verification)
                .Include(a=>a.AspNetUser.Country)
                .Include(a => a.CR_AccountType)
                .Include(a=>a.AspNetUser).SingleOrDefault();
            return user;
        }
        public CR_Account GetUser(string userId)
        {
            var user = context.CR_Account.Where(a => a.UserId == userId)
                .Include(a => a.CR_Transactions)
                .Include(a => a.CR_Activity)
                .Include(a => a.CR_Verification)
                .Include(a => a.AspNetUser.Country)
                .Include(a => a.CR_AccountType)
                .Include(a=>a.AspNetUser).SingleOrDefault();
            return user;
        }

        public List<CR_Account> GetUsers()
        {
            var user = context.CR_Account
                .Include(a => a.CR_Transactions)
                .Include(a => a.CR_Activity)
                .Include(a => a.CR_Verification)
                .Include(a => a.AspNetUser.Country)
                .Include(a => a.CR_AccountType)
                .Include(a => a.AspNetUser).ToList();
            return user;
        }

        public bool DeleteUser(string userId)
        {
            try
            {
                var acc = context.AspNetUsers.Find(userId);
                if (acc != null)
                {
                    context.AspNetUsers.Remove(acc);
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

        public bool SetAccountStatus(int accountId, AccountStatus status)
        {
            try
            {
                var acc = context.CR_Account.Find(accountId);
                if (acc != null)
                {
                    acc.Status = status.ToString();
                    context.Entry(acc).State = EntityState.Modified;
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

        public IList<MaintainanceFee> GetMaintainanceFees()
        {
            var l = context.MaintainanceFees.ToList();
            return l;
        }
    }
}