using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNKMVC.Models;
using BNKMVC.Services;
using Microsoft.AspNet.Identity;

namespace BNKMVC.Controllers
{
    [Authorize]
    public class InvestorController : Controller
    {
        // GET: Investor 

        public ActionResult Index()
        {
            return RedirectToAction(nameof(Dashboard));
        }

     

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult WithDraw()
        {
            return View();
        }
        public ActionResult Earning()
        {
            return View();
        }
        public ActionResult Transactions()
        {
            return View();
        }
        public ActionResult Invest()
        {
            return View();
        }

        public ActionResult Verify()
        {

            var m = new VerificationVm
            {
                CryptoAccountId = AccountId()
            };

            return View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Verifv(VerificationVm m)
        {
            if (ModelState.IsValid)
            {
                var save = new AccountVerifications().Create(m);
                if (save)
                {
                    return Json(new { status = 200,  message = "Document Uploaded and Submited Successfull" }, JsonRequestBehavior.AllowGet);
                }
            }
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new { status = 400, errors = errors, message = "Check your entries" } , JsonRequestBehavior.AllowGet);
        }
        private string UserId() => User.Identity.GetUserId();

        private int AccountId()
        {
            return new CryptoAccount().GetUser(UserId()).Id;
        }
    }
}