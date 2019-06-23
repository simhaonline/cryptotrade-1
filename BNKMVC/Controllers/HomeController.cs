using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNKMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Learn About us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Get in touch with us";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Models.FeedBackDto m)
        {
            if (ModelState.IsValid)
            {
                var db = new Entities.mbankEntities();
                db.tblfeedbacks.Add(new Entities.tblfeedback
                {
                    Clientname = m.Clientname,
                    email = m.email,
                    Message = m.Message,
                    datesent = DateTime.UtcNow.ToString(),

                });
                db.SaveChanges();
                TempData["view"] = 1;
                TempData["Message"] = "We have received your message and we will get back to you";
                return View(m);
            }


            return View(m);
        }
        public ActionResult Services()
        {
            ViewBag.Message = "What We Offer";

            return View();
        }
    }
}