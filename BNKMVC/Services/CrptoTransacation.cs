using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
using BNKMVC.Models;

namespace BNKMVC.Services
{
    public class CrptoTransacation
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedId;
        public CrptoTransacation()
        {
            context = new mbankEntities();
        }
     
        public bool Create(TransactionVm m)
        {
            try
            {
                var save = context.CR_Transactions.Add(new CR_Transactions()
                {
                   
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

        public bool Delete(int verificationId)
        {
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


    }
}