using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNKMVC.Entities;
using BNKMVC.Models;
using BNKMVC.Services;

namespace BNKMVC.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class CryptoAdminController : Controller
    {
        // GET: CryptoAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Verifications()
        {
            var list = new AccountVerifications().GetVerifications();
            return View(list);
        }

        public ActionResult ApproveVerification(int id)
        {
            var account = new AccountVerifications();
            var approve = account.SetStatus(id, VerificationStatus.APPROVED);
            if (approve)
            {
                var accId = account.GetVerification(id).CR_Account.Id;
                var acc = new CryptoAccount().SetAccountStatus(accId, AccountStatus.APPROVED);
            }
            return RedirectToAction(nameof(Verifications));
        }

        public ActionResult DeclineVerification(int id)
        {
            var approve = new AccountVerifications().SetStatus(id, VerificationStatus.DENYED);
            return RedirectToAction(nameof(Verifications));
        }

        public ActionResult DeleteVerification(int id)
        {
            var approve = new AccountVerifications().Delete(id);
            return RedirectToAction(nameof(Verifications));
        }

        public ActionResult Transactions()
        {
            var trans = new CryptoTransaction().Transactions().OrderBy(a => a.DateCreated).ToList();

            return View(trans);
        }
        public ActionResult SuccessTransactions()
        {
            var trans = new CryptoTransaction().Transactions().Where(a=>a.Status == TransactionStatus.SUCCESSFUL.ToString()).OrderBy(a=>a.DateCreated).ToList();
            return PartialView("_SuccessTransaction",trans);
        }

        public ActionResult ApproveTransaction(int id)
        {
          var app = new CryptoTransaction().SetStatus(id, TransactionStatus.APPROVED);
          return RedirectToAction(nameof(Transactions));
        }

        public ActionResult ViewUser(string id)
        { 
            var account = new CryptoAccount();
            var details = account.GetUser(id);
            return View(details);
        }
        public ActionResult ViewUsers()
        {
            //var account = new CryptoAccount();
            //var details = account.;
            return View(/*details*/);
        }

        public ActionResult DeleteUser(string Id)
        {

        }
        public ActionResult DeleteTransaction(int id)
        {
          var del = new CryptoTransaction().Delete(id);
          if (del)
          {
              return Json(new {status = 200, message = "Delete Successful"}, JsonRequestBehavior.AllowGet);
          }
          return Json(new { status = 400, message = "Something went wrong" }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CreditAccount(int id, double amount)
        {
            var c = new CryptoAccount().Credit(id, amount);
            if (c)
            {
                new CryptoActivities().Create(new ActivityVm()
                {
                    AccountId = id,
                    Amount = Convert.ToDecimal(amount)
                });
                return Json(new { status = 200, message = "Operation Successful" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 400, message = "Operation Failed." }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult DeductAccount(int id, double amount)
        {
            var c = new CryptoAccount().Debit(id, amount);
            if (c)
            {
                return Json(new { status = 200, message = "Operation Successful" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 400, message = "Operation Failed." }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult WithDrawRequest()
        {
            var withdraw = new CryptoWithDrawRequest().GetWithdeWithdrawRequests();
            return View(withdraw);
        }

        public ActionResult DeleteWithDrawRequest( int id)
        {
            new CryptoWithDrawRequest().Delete(id);
            return RedirectToAction(nameof(WithDrawRequest));
        }

        public ActionResult SetWithDrawRequestStatus(int id, WithDrawRequestStatus status)
        {
            new CryptoWithDrawRequest().SetWithDrawStatus(id, status);
            return RedirectToAction(nameof(WithDrawRequest));

        } 

        
    }
}