using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
using BNKMVC.Models;

namespace BNKMVC.Services
{
    public enum WithDrawRequestStatus
    {
        Pending, Success, Canceled, Failed, Paid, HasPaidMaintainceFee, HasNotPaidMaintainceFee, Inprogress
    }
    public class CryptoWithDrawRequest
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedId;

        public CryptoWithDrawRequest()
        {
            context = new mbankEntities();

        }

        public bool Create(WithdrawVm m)
        {
            try
            {
                var s = context.WithdrawRequests.Add(new WithdrawRequest()
                {
                    AccountId = m.AccountId,
                    Status = WithDrawRequestStatus.Pending.ToString(),
                    DateCreated = DateTime.UtcNow,
                    Amount = Convert.ToDecimal(m.Amount),
                    WalletId = m.WalletId, 
                    MaintainceFee = m.MaintainceFee,
                    MaintainceFeeStatus = WithDrawRequestStatus.HasNotPaidMaintainceFee.ToString()

                });
                context.SaveChanges();
                savedId = s.Id;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool SetWithDrawStatus( int id, WithDrawRequestStatus status)
        {
            try
            {
                var find = context.WithdrawRequests.Find(id);
                if (find != null)
                {
                    find.Status = status.ToString();
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
        public bool SetMaintanceFeeWithDrawStatus(int id, WithDrawRequestStatus status)
        {
            try
            {
                var find = context.WithdrawRequests.Find(id);
                if (find != null)
                {
                    find.MaintainceFeeStatus = status.ToString();
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

        public bool Delete(int id)
        {
            try
            {
                var find = context.WithdrawRequests.Find(id);
                if (find != null)
                {

                    context.WithdrawRequests.Remove(find);
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
        public List<WithdrawRequest> GetWithdeWithdrawRequests()
        {
            var list = context.WithdrawRequests
                .Include(a=>a.CR_Account)
                .Include(a => a.CR_Account.AspNetUser)
                .Include(a=>a.CR_Account.CR_Currency)
                .ToList();
            return list;
        }
        public List<WithdrawRequest> GetWithdeWithdrawRequests(int accountId)
        {
            var list = context.WithdrawRequests.Where(a => a.AccountId == accountId)
                .Include(a => a.CR_Account)
                .Include(a => a.CR_Account.AspNetUser)
                .Include(a => a.CR_Account.CR_Currency).ToList();
            return list;
        } 

        
    }
}