using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BNKMVC.Entities;

namespace BNKMVC.Services
{
    public class CryptoAccountType
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedId;

        public CryptoAccountType()
        {
            context = new mbankEntities();

        }



        public List<CR_AccountType> AccountTypes()
        {
            return context.CR_AccountType.ToList();
        }
    }
}