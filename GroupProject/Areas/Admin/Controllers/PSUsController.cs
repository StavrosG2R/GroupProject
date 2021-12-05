using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Core.Entities;
using DataAccess.Persistence;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PSUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PSUs
        public ActionResult Index()
        {
            var pSUs = db.PSUs.Include(p => p.Company);
            return View(pSUs.ToList());
        }

        // GET: Admin/PSUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSU pSU = db.PSUs.Find(id);
            if (pSU == null)
            {
                return HttpNotFound();
            }
            return View(pSU);
        }

        // GET: Admin/PSUs/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Admin/PSUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Watt,Efficiency,Modularity,Thumbnail,Price")] PSU pSU)
        {
            if (ModelState.IsValid)
            {
                db.PSUs.Add(pSU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", pSU.CompanyID);
            return View(pSU);
        }

        // GET: Admin/PSUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSU pSU = db.PSUs.Find(id);
            if (pSU == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", pSU.CompanyID);
            return View(pSU);
        }

        // POST: Admin/PSUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Watt,Efficiency,Modularity,Thumbnail,Price")] PSU pSU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pSU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", pSU.CompanyID);
            return View(pSU);
        }

        // GET: Admin/PSUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PSU pSU = db.PSUs.Find(id);
            if (pSU == null)
            {
                return HttpNotFound();
            }
            return View(pSU);
        }

        // POST: Admin/PSUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PSU pSU = db.PSUs.Find(id);
            db.PSUs.Remove(pSU);
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
