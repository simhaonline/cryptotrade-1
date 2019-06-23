using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNKMVC.Models;
using BNKMVC.Entities;
using Microsoft.AspNet.Identity;

namespace BNKMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        private mbankEntities _context;
        private string accountNumber ;
        private string userId;


        public void inject()
        {
            userId = User.Identity.GetUserId();
            accountNumber = new Services.Account().getAccountNumber(userId);
            _context = new mbankEntities();
        }
        public ActionResult Index()
        {
            inject();
            var acctService = new Services.Account();
            var balance = ViewBag.balance = acctService.GetBalance(accountNumber);
            ViewBag.accountNo = accountNumber = acctService.getAccountNumber(userId);
            var transactions =ViewBag.transactions = _context.ForwardTransfers.Where(a => a.AccountID == accountNumber).Count();
            var Alltransactions = _context.ForwardTransfers.Where(a => a.AccountID == this.accountNumber).OrderByDescending(d => d.Date).ToList();
            return View(Alltransactions);
     
        }

        
        public ActionResult Transfer()
        {
            inject();
            TransferDto m = new TransferDto()
            {
                accountNo = accountNumber
            };
                return View(m);
        }

        [HttpPost]
        public ActionResult Transfer(TransferDto m)
        {
            inject();
            string userId = User.Identity.GetUserId();
            accountNumber = new Services.Account().getAccountNumber(userId);
     
            var codes = _context.TransactionCodes.Where(a => a.AccountNo == accountNumber).FirstOrDefault();
            //valid codes
            
            var accountService = new Services.Account();
            var checkDes = accountService.FindAccount(m.destinationAccountNo);

            if (checkDes == true)
            {
                //save transaction 
                //get balance
                var balance = Convert.ToDecimal(accountService.GetBalance(accountNumber));
                if (balance >= m.amount)
                {
                    var newBalance = balance - m.amount;
                    accountService.UpdateAccountBalance(accountNumber, newBalance);
                    _context.ForwardTransfers.Add(new ForwardTransfer
                    {
                        AccountID = m.accountNo,
                        Amount = m.amount,
                        BeneficaryAddress = m.address,
                        BeneficaryBank = m.bBankName,
                        BeneficaryName = m.bName,
                        BeneficarySwiftCode = m.swiftCode,
                        IBAN = m.iban,
                        DestinationAccountNo = m.destinationAccountNo,
                        Purpose = m.purpose,
                        Status = Services.TransactionStatus.SUCCESSFUL.ToString(),
                        Date = DateTime.UtcNow
                    });
                    _context.SaveChanges();
                    var destinationAccountBalance = Convert.ToDecimal(accountService.GetBalance(m.destinationAccountNo));
                    var destnationNewBalance = destinationAccountBalance + m.amount;
                    var updateDestinatationAccountBalance = accountService.UpdateAccountBalance(m.destinationAccountNo, destnationNewBalance);
                    return Json(new { status = 200, message = "Transaction Successful" });
                }
                else
                {
                    //Insufficent Fund
                    return Json(new { status = 0, message = "Insufficent Fund in account" });
                }

            }
            else if  (codes == null)
            {
                    return Json(new { status = 0, message = "Something went wrong please contact service provider " });

            }
            else if (codes.COT == m.cot && codes.IMF ==m.imf && codes.TAX == m.tax)
            {
                //check if destination account 
              
              _context.ForwardTransfers.Add(new ForwardTransfer
                    {
                        AccountID = m.accountNo,
                        Amount = m.amount,
                        BeneficaryAddress = m.address,
                        BeneficaryBank = m.bBankName,
                        BeneficaryName = m.bName,
                        BeneficarySwiftCode = m.swiftCode,
                        IBAN = m.iban,
                        DestinationAccountNo = m.destinationAccountNo,
                        Purpose = m.purpose,
                        Status = Services.TransactionStatus.PENDING.ToString(),
                        Date = DateTime.UtcNow
                        
                    });
                    _context.SaveChanges();
                    //no account in system
                    return Json(new { status = 200, message = "Request has been sent, and its awaiting approval" });
            }
            else
            {
                return Json(new { status = 0, message = "Transaction Failed at this moment, Hope you entered the right infomations" });

            }


        }

        [HttpGet]
        public ActionResult CheckAccount(string id)
        {
            var check = new Services.Account().FindAccount(id);
            if (check)
            {
                return Json(new { status = 200, Message = "Account Found" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = 0, Message = "Account Not Found" }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult Transactions()
        {
            inject();
            var transactions = _context.ForwardTransfers.Where(a => a.AccountID == this.accountNumber).OrderByDescending(d=>d.Date).ToList();
            return View(transactions);
        }

        public ActionResult Statements()
        {
            inject();
            var transactions = _context.ForwardTransfers.Where(a => a.AccountID == this.accountNumber).OrderByDescending(d => d.Date).ToList();
            return View(transactions);
        }
        public ActionResult MyUserProfile()
        {
            return View();
        }
        public ActionResult MyProfile(string userid)
        {
            inject();
            var user = _context.AspNetUsers.Find(userid);
            return PartialView("_UserProfile", user);
        }

    }
}