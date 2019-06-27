using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BNKMVC.GoUrlCore;
using BNKMVC.Models;
using BNKMVC.Models.GoUrl;
using BNKMVC.Services;
using Microsoft.AspNet.Identity;

namespace BNKMVC.Controllers
{
    [Authorize] 
    [MustBeVerifiedFilter]
    public class InvestorController : Controller
    {
        // GET: Investor 

        public ActionResult Index()
        {
            return RedirectToAction(nameof(Dashboard));
        }

     

        public ActionResult Dashboard()
        {
            var account = new CryptoAccount().GetUser(AccountId());
            return View(account);
        }

        public ActionResult MyAccount()
        {
            var account = new CryptoAccount().GetUser(AccountId());
            return View(account);
        }
        public ActionResult WithDraw()
        {
            var m = new WithdrawVm()
            {
                AccountId = AccountId()
            };
            return View(m);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult WithDraw(WithdrawVm m)
        {
            if (ModelState.IsValid)
            {
                double miniAmount = 200;
                if (m.Amount < miniAmount)
                {
                    ModelState.AddModelError("", "Please Enter Amount above the minimum amount - " + miniAmount);
                }
                var acc = new CryptoAccount();
                var bal = Convert.ToDouble(acc.Get(AccountId()).CurrentCryptoBalance);
                var sym = acc.Get(AccountId()).CR_Currency.ShortCode;
                if (bal < m.Amount)
                {
                    ModelState.AddModelError("", "Sorry !, You dont Have enough balance to withdraw - Your Current Balance is "+ sym +" " + bal);

                }

                if (bal >= m.Amount)
                {
                    //process the payment   
                    // get maintaince fee

                    var fees = acc.GetMaintainanceFees();
                    foreach (var i in fees)
                    {
                        if (i.SmallestAmount <= (decimal?)m.Amount || i.LargestAmount <= (decimal?)m.Amount)
                        {
                            m.MaintainceFee = Convert.ToDecimal(i.Fee);
                            var w = new CryptoWithDrawRequest();
                            w.Create(new WithdrawVm()
                            {
                                AccountId = AccountId(),
                                Amount = m.Amount,
                                MaintainceFee = Convert.ToDecimal(i.Fee),
                                MaintainceFeeStatus = WithDrawRequestStatus.HasNotPaidMaintainceFee.ToString(),
                                WalletId = m.WalletId,

                            }); 

                            return RedirectToAction(nameof(MaintainceSecuredPayment), new {amount = m.MaintainceFee, withdrawrequestId = w.savedId});
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please contact customer support. ");

                        }
                    }

                }
            }
           
            //IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return View(m);
        
         
        }

      
        public ActionResult MaintainceSecuredPayment( double amount, int withdrawrequestId)
        {
            var transaction = new CryptoTransaction(); 
            var withdraw = new CryptoWithDrawRequest();
            var account = new CryptoAccount();
            var accountId = AccountId();
            ViewBag.amount = account.Get(AccountId()).CR_Currency.ShortCode +" "+ amount; 
           
            transaction.Create(new TransactionVm()
            {
                Status = TransactionStatus.PENDING,
                Amount = Convert.ToDecimal(amount),
                accountId = AccountId(),
                CurrencyDomination = "BTC",
                TransactionType = TransactionTypeStatus.Withdraw
            });
            OptionsModel options = new OptionsModel()
            {
                public_key = GoUrlKeys.PublicKey,
                private_key = GoUrlKeys.PrivateKey,
                webdev_key = "",
                orderID = transaction.savedId.ToString(),
                userID = UserId(),
                userFormat = "COOKIE",
                //amount = 0,
                amountUSD = Convert.ToDecimal(amount),
                period = "2 HOUR",
                language = "en"
            };
            ViewBag.transId = transaction.savedId.ToString();
            using (Cryptobox cryptobox = new Cryptobox(options))
            {
                ViewBag.JsonUrl = cryptobox.cryptobox_json_url();
                ViewBag.Message = "";
                DisplayCryptoboxModel model = cryptobox.GetDisplayCryptoboxModel();
                if (HttpContext.Request.Form["cryptobox_refresh_"] != null)
                {
                    ViewBag.Message = "<div class='gourl_msg'>";
                    if (cryptobox.is_paid())
                    {

                        ViewBag.Message +=
                            "<div style=\"margin:50px\" class=\"well\"><i class=\"fa fa-info-circle fa-3x fa-pull-left fa-border\" aria-hidden=\"true\"></i> " +
                            Controls.localisation[model.language].MsgNotReceived.Replace("%coinName%", model.coinName)
                                .Replace("%coinNames%",
                                    model.coinLabel == "BCH" || model.coinLabel == "DASH"
                                        ? model.coinName
                                        : model.coinName + "s")
                                .Replace("%coinLabel%", model.coinLabel) + "</div>";
                        transaction.SetStatus(transaction.savedId, TransactionStatus.INPROGESS);
                        withdraw.SetMaintanceFeeWithDrawStatus(withdrawrequestId, WithDrawRequestStatus.Inprogress);
                    }
                    else if (cryptobox.is_processed())
                    {
                        ViewBag.Message += "<div style=\"margin:70px\" class=\"alert alert-success\" role=\"alert\"> " +
                                           (model.boxType == "paymentbox"
                                               ? Controls.localisation[model.language].MsgReceived
                                               : Controls.localisation[model.language].MsgReceived2)
                                           .Replace("%coinName%", model.coinName)
                                           .Replace("%coinLabel%", model.coinLabel)
                                           .Replace("%amountPaid%", model.amoutnPaid.ToString()) + "</div>";
                        cryptobox.set_status_processed();
                        transaction.SetStatus(transaction.savedId, TransactionStatus.SUCCESSFUL);
                        withdraw.SetMaintanceFeeWithDrawStatus(withdrawrequestId, WithDrawRequestStatus.HasPaidMaintainceFee);


                    }

                    ViewBag.Message = "</div>";
                }



                return View(model);
            }
        }

        public ActionResult Earning()
        {
            var activity = new CryptoActivities().Get(AccountId());
            return View(activity);
        }
        public ActionResult Transactions()
        {
            var trans = new CryptoTransaction().Transactions(AccountId());
            return View(trans);
        }
        public ActionResult Invest()
        { 
            var list = new CryptoAccountType().AccountTypes();
            return View(list);
        }

        public ActionResult WithDraws()
        {
            var list = new CryptoWithDrawRequest().GetWithdeWithdrawRequests(AccountId());
            return PartialView(list);
        }
        [MustNotBeVerifiedFilter]
        public ActionResult Verify()
        {

            var m = new VerificationVm
            {
                CryptoAccountId = AccountId()
            };

         
            return View(m);
        }
        public ActionResult MakePayment(double cryptoamount)
        {
            var transaction = new CryptoTransaction(); 
            var account = new CryptoAccount();
            var accountId = AccountId();
            transaction.Create(new TransactionVm()
            {
                Status = TransactionStatus.PENDING,
                Amount = Convert.ToDecimal(cryptoamount),
                accountId = accountId,
                CurrencyDomination = "BTC",
                TransactionType = TransactionTypeStatus.Credit
            });
            OptionsModel options = new OptionsModel()
            {
                public_key = GoUrlKeys.PublicKey,
                private_key = GoUrlKeys.PrivateKey,
                webdev_key = "",
                orderID = transaction.savedId.ToString(),
                userID = UserId(),
                userFormat = "COOKIE",
                //amount = 0,
                amountUSD = Convert.ToDecimal(cryptoamount),
                period = "2 HOUR",
                language = "en"
            };
            using (Cryptobox cryptobox = new Cryptobox(options))
            {
                if (cryptobox.is_paid())
                {
                    //initiate a pendint transaction 
                   
                    if (!cryptobox.is_confirmed())
                    {
                        ViewBag.message = "Thank you for order (order #" + options.orderID + ", payment #" + cryptobox.payment_id() +
                                          "). Awaiting transaction/payment confirmation"; 
                    }
                    else
                    {
                        if (!cryptobox.is_processed())
                        {
                            ViewBag.message = "Thank you for order (order #" + options.orderID + ", payment #" + cryptobox.payment_id() + "). Payment Confirmed<br/> (User will see this message one time after payment has been made)";
                            cryptobox.set_status_processed();
                            transaction.SetStatus(transaction.savedId, TransactionStatus.SUCCESSFUL);
                       
                        }
                        else
                        {
                            ViewBag.message = "Thank you for order (order #" + options.orderID + ", payment #" + cryptobox.payment_id() + "). Payment Confirmed<br/> (User will see this message during " + options.period + " period after payment has been made)";
                            transaction.SetStatus(transaction.savedId, TransactionStatus.INPROGESS);
                        }
                    }
                }
                else
                {
                    ViewBag.message = "This invoice has not been paid yet";
                    transaction.SetStatus(transaction.savedId, TransactionStatus.PENDING);
                }
                
                DisplayCryptoboxModel model = cryptobox.GetDisplayCryptoboxModel();

                return View(model);
            }
        }

        
        public ActionResult SecuredPayment(double cryptoamount)
        {
            var transaction = new CryptoTransaction();
            var account = new CryptoAccount();
            var accountId = AccountId(); 

            transaction.Create(new TransactionVm()
            {
                Status = TransactionStatus.PENDING,
                Amount = Convert.ToDecimal(cryptoamount),
                accountId = AccountId(),
                CurrencyDomination = "BTC",
                TransactionType = TransactionTypeStatus.Credit
            });
            OptionsModel options = new OptionsModel()
            {
                public_key = GoUrlKeys.PublicKey,
                private_key = GoUrlKeys.PrivateKey,
                webdev_key = "",
                orderID = transaction.savedId.ToString(),
                userID = UserId(),
                userFormat = "COOKIE",
                //amount = 0,
                amountUSD = Convert.ToDecimal(cryptoamount),
                period = "2 HOUR",
                language = "en"
            };
            ViewBag.transId = transaction.savedId.ToString();
            using (Cryptobox cryptobox = new Cryptobox(options))
            {
                ViewBag.JsonUrl = cryptobox.cryptobox_json_url();
                ViewBag.Message = "";
                DisplayCryptoboxModel model = cryptobox.GetDisplayCryptoboxModel();
                if (HttpContext.Request.Form["cryptobox_refresh_"] != null)
                {
                    ViewBag.Message = "<div class='gourl_msg'>";
                    if (cryptobox.is_paid())
                    {

                        ViewBag.Message +=
                            "<div style=\"margin:50px\" class=\"well\"><i class=\"fa fa-info-circle fa-3x fa-pull-left fa-border\" aria-hidden=\"true\"></i> " +
                            Controls.localisation[model.language].MsgNotReceived.Replace("%coinName%", model.coinName)
                                .Replace("%coinNames%",
                                    model.coinLabel == "BCH" || model.coinLabel == "DASH"
                                        ? model.coinName
                                        : model.coinName + "s")
                                .Replace("%coinLabel%", model.coinLabel) + "</div>";
                        transaction.SetStatus(transaction.savedId, TransactionStatus.INPROGESS);

                    }
                    else if (cryptobox.is_processed())
                    {
                        ViewBag.Message += "<div style=\"margin:70px\" class=\"alert alert-success\" role=\"alert\"> " +
                                           (model.boxType == "paymentbox"
                                               ? Controls.localisation[model.language].MsgReceived
                                               : Controls.localisation[model.language].MsgReceived2)
                                           .Replace("%coinName%", model.coinName)
                                           .Replace("%coinLabel%", model.coinLabel)
                                           .Replace("%amountPaid%", model.amoutnPaid.ToString()) + "</div>";
                        cryptobox.set_status_processed();
                        transaction.SetStatus(transaction.savedId, TransactionStatus.SUCCESSFUL);
                    }

                    ViewBag.Message = "</div>";
                }



                return View(model);
            }
        }

        [MustNotBeVerifiedFilter]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Verify(VerificationVm m)
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