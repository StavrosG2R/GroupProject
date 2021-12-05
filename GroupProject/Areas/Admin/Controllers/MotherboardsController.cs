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
    public class MotherboardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Motherboards
        public ActionResult Index()
        {
            var motherboards = db.Motherboards.Include(m => m.Company);
            return View(motherboards.ToList());
        }

        // GET: Admin/Motherboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // GET: Admin/Motherboards/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Admin/Motherboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Socket,Chipset,Model,DdrType,Size,Watt,Thumbnail,Price")] Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                db.Motherboards.Add(motherboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", motherboard.CompanyID);
            return View(motherboard);
        }

        // GET: Admin/Motherboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", motherboard.CompanyID);
            return View(motherboard);
        }

        // POST: Admin/Motherboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Socket,Chipset,Model,DdrType,Size,Watt,Thumbnail,Price")] Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motherboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", motherboard.CompanyID);
            return View(motherboard);
        }

        // GET: Admin/Motherboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = db.Motherboards.Find(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // POST: Admin/Motherboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Motherboard motherboard = db.Motherboards.Find(id);
            db.Motherboards.Remove(motherboard);
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
