using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
using BNKMVC.Models;

namespace BNKMVC.Services
{
    public class CrptoVerification
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedAccountId;
        public CrptoVerification()
        {
            context = new mbankEntities();
        }

        public bool Create(VerificationVm m)
        {
            try
            {
                var save = context.CR_Verification.Add( new CR_Verification()
                {
                 DocumentUrl = m.DocumentUrl,
                 Status = VerificationStatus.  PENDING. ToString(),
                 VerificationType = m. VerificationType,
                 CR_AccountId = m. CryptoAccountId
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

        public bool UpdateStatus(int verificationId, VerificationStatus status)
        {
            try
            {
                var find = context.CR_Verification.Find(verificationId);
                if (find != null)
                {
                    find.Status = status.ToString();
                    context.Entry(find).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

    }
}