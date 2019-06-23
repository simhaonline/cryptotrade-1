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
    public class CR_AccountTypeController : Controller
    {
        private mbankEntities db = new mbankEntities();

        // GET: CR_AccountType
        public ActionResult Index()
        {
            return View(db.CR_AccountType.ToList());
        }

        // GET: CR_AccountType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_AccountType cR_AccountType = db.CR_AccountType.Find(id);
            if (cR_AccountType == null)
            {
                return HttpNotFound();
            }
            return View(cR_AccountType);
        }

        // GET: CR_AccountType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CR_AccountType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Title,Description,Value")] CR_AccountType cR_AccountType)
        {
            if (ModelState.IsValid)
            {
                db.CR_AccountType.Add(cR_AccountType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cR_AccountType);
        }

        // GET: CR_AccountType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_AccountType cR_AccountType = db.CR_AccountType.Find(id);
            if (cR_AccountType == null)
            {
                return HttpNotFound();
            }
            return View(cR_AccountType);
        }

        // POST: CR_AccountType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Title,Description,Value")] CR_AccountType cR_AccountType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cR_AccountType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cR_AccountType);
        }

        // GET: CR_AccountType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CR_AccountType cR_AccountType = db.CR_AccountType.Find(id);
            if (cR_AccountType == null)
            {
                return HttpNotFound();
            }
            return View(cR_AccountType);
        }

        // POST: CR_AccountType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CR_AccountType cR_AccountType = db.CR_AccountType.Find(id);
            db.CR_AccountType.Remove(cR_AccountType);
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
