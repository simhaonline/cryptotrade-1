using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BNKMVC.Services
{
    public static class Generator
    {
        public static string RndAccountNo()
        {
            Random rand = new Random();
            int rnd_number = rand.Next(99999);
            return "50943" + Convert.ToString(rnd_number);
        }
    }
}