using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
using BNKMVC.Models;

namespace BNKMVC.Services
{
    public class CryptoActivities
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedAccountId;
     

        public CryptoActivities()
        {
            context = new mbankEntities();
        }

        public bool Create(ActivityVm m) 
        {
            try
            {
                var s = context.CR_Activity.Add(new CR_Activity()
                {
                    AccountId = m.AccountId,
                    Amount = m.Amount,
                    DateCreated = DateTime.UtcNow
                });
                context.SaveChanges();
                savedAccountId = s.Id;
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CR_Activity> Get(int accountId)
        {
            try
            {
              var list = context.CR_Activity.Where(a=>a.AccountId == accountId).ToList();
              return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}