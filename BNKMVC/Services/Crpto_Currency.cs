using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BNKMVC.Entities;

namespace BNKMVC.Services
{
    public class Crpto_Currency
    {
        private mbankEntities context;
        public string errorMessage;
        public int savedId;


       
        public Crpto_Currency()
        {
            context = new mbankEntities();
        }

        public List<CR_Currency> GetCurrencies()
        {
            return context.CR_Currency.ToList();
        } 
    }

    
}