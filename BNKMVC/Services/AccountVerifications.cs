using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
using BNKMVC.Models;

namespace BNKMVC.Services
{
    public enum VerificationStatus
    {
        PENDING, APPROVED, DENYED
    }
    public class AccountVerifications
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedId;
     

        public AccountVerifications()
        {
            context = new mbankEntities();
        }

        public bool Create(VerificationVm m)
        {
            try
            {
                var save = context.CR_Verification.Add(new CR_Verification()
                {
                    DocumentUrl = m.DocumentUrl,
                    CR_AccountId = m.CryptoAccountId, 
                    VerificationType =  m.VerificationType,
                    Status = VerificationStatus.PENDING.ToString()
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

        public bool SetStatus(int verificationId, VerificationStatus status)
        {
            try
            {
                var find = context.CR_Verification.Find(verificationId);
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

        public bool Delete(int verificationId) { 
            try
            {
                var find = context.CR_Verification.Find(verificationId);
                if (find != null)
                {
                    context.CR_Verification.Remove(find);

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

        public IList<CR_Verification> GetAccountVerifications(int id)
        {
            return context.CR_Verification.Where(a => a.CR_AccountId == id).OrderBy(a => a.Status).ToList();
        }

        public IList<CR_Verification> GetVerifications()
        {
            return context.CR_Verification.OrderBy(a => a.Status).ToList();
        }
        public CR_Verification GetVerification(int verificationId)
        {
            return context.CR_Verification.Where(a=>a.Id == verificationId).Include(a=>a.CR_Account).Include(a=>a.CR_Account.AspNetUser).SingleOrDefault();
        }
    }

}