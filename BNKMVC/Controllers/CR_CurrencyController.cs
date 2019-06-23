using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BNKMVC.Entities;

namespace BNKMVC.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class CR_CurrencyController : Controller
    {
        private mbankEntities db = new mbankEntities();

        // GET: CR_Currency
        public ActionResult Index()
        {
            return View(db.CR_Currency.ToList());
        }

        // GET: CR_Currency/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_Currency cR_Currency = db.CR_Currency.Find(id);
            if (cR_Currency == null)
            {
                return HttpNotFound();
            }
            return View(cR_Currency);
        }

        // GET: CR_Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CR_Currency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortCode,CurrentValueToDollar")] CR_Currency cR_Currency)
        {
            if (ModelState.IsValid)
            {
                db.CR_Currency.Add(cR_Currency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cR_Currency);
        }

        // GET: CR_Currency/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_Currency cR_Currency = db.CR_Currency.Find(id);
            if (cR_Currency == null)
            {
                return HttpNotFound();
            }
            return View(cR_Currency);
        }

        // POST: CR_Currency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortCode,CurrentValueToDollar")] CR_Currency cR_Currency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cR_Currency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cR_Currency);
        }

        // GET: CR_Currency/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_Currency cR_Currency = db.CR_Currency.Find(id);
            if (cR_Currency == null)
            {
                return HttpNotFound();
            }
            return View(cR_Currency);
        }

        // POST: CR_Currency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CR_Currency cR_Currency = db.CR_Currency.Find(id);
            db.CR_Currency.Remove(cR_Currency);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
