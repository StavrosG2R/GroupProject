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
    public class RAMsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/RAMs
        public ActionResult Index()
        {
            var rAMs = db.RAMs.Include(r => r.Company);
            return View(rAMs.ToList());
        }

        // GET: Admin/RAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            return View(rAM);
        }

        // GET: Admin/RAMs/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Admin/RAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Model,Frequency,DdrType,Storage,Thumbnail,Price")] RAM rAM)
        {
            if (ModelState.IsValid)
            {
                db.RAMs.Add(rAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", rAM.CompanyID);
            return View(rAM);
        }

        // GET: Admin/RAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", rAM.CompanyID);
            return View(rAM);
        }

        // POST: Admin/RAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Model,Frequency,DdrType,Storage,Thumbnail,Price")] RAM rAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", rAM.CompanyID);
            return View(rAM);
        }

        // GET: Admin/RAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAM rAM = db.RAMs.Find(id);
            if (rAM == null)
            {
                return HttpNotFound();
            }
            return View(rAM);
        }

        // POST: Admin/RAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAM rAM = db.RAMs.Find(id);
            db.RAMs.Remove(rAM);
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
