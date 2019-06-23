using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BNKMVC.Entities;
namespace BNKMVC.Services
{
    public enum TransactionStatus{
        PENDING, SUCCESSFUL, BLOCKED, DENYED, APPROVED
    }
    public class Account
    {
        public bool AddAccount(string userid)
        {
            try
            {
                using(var db = new Entities.mbankEntities())
                {
                    db.tblAccounts.Add(new tblAccount
                    {
                        userId = userid,
                        acctNo = Generator.RndAccountNo(),
                        ActiveAmount = Convert.ToDecimal(0.00),
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
              
            }
        }

        public string getAccountNumber(string userid)
        {
            try
            {
                using (var db = new Entities.mbankEntities())
                {
                    var accout = db.tblAccounts.Where(a => a.AspNetUser.Id == userid).Select(a => a.acctNo).SingleOrDefault();
                  
                    return accout;
                }
            }
            catch (Exception)
            {
                return null;

            }
        }

        public bool Find(string userid)
        {
            try
            {
                using (var db = new Entities.mbankEntities())
                {
                  var find =  db.AspNetUsers.Find(userid);

                    return true;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }
        public double GetBalance(string accountNo)
        {
            try
            {
                using (var db = new Entities.mbankEntities())
                {
                    var find = db.tblAccounts.Where(a => a.acctNo == accountNo).SingleOrDefault();

                    if (find != null)
                    {

                        return Convert.ToDouble(find.ActiveAmount);

                    }
                    return 0.00;
                }
            }
            catch (Exception)
            {
                return 0.00;

            }
        }
        public bool UpdateAccountBalance(string accountNo, decimal amount)
        {
            try
            {
                using (var db = new Entities.mbankEntities())
                {
                    var find = db.tblAccounts.Where(a => a.acctNo == accountNo).SingleOrDefault();

                    if (find != null)
                    {
                        find.ActiveAmount = amount;
                        db.Entry(find).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return true;

                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool FindAccount(string accountNo)
        {
            try
            {
                using (var db = new Entities.mbankEntities())
                {
                    var find = db.tblAccounts.Where(a => a.acctNo == accountNo).SingleOrDefault();
                    
                    if(find != null)
                    {
                        return true;

                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }

    }
}