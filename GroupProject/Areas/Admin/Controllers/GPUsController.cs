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
    public class GPUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/GPUs
        public ActionResult Index()
        {
            var gPUs = db.GPUs.Include(g => g.Company);
            return View(gPUs.ToList());
        }

        // GET: Admin/GPUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gPU = db.GPUs.Find(id);
            if (gPU == null)
            {
                return HttpNotFound();
            }
            return View(gPU);
        }

        // GET: Admin/GPUs/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Admin/GPUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Chipset,Model,Watt,Vram,Thumbnail,Price")] GPU gPU)
        {
            if (ModelState.IsValid)
            {
                db.GPUs.Add(gPU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", gPU.CompanyID);
            return View(gPU);
        }

        // GET: Admin/GPUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gPU = db.GPUs.Find(id);
            if (gPU == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", gPU.CompanyID);
            return View(gPU);
        }

        // POST: Admin/GPUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Chipset,Model,Watt,Vram,Thumbnail,Price")] GPU gPU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gPU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", gPU.CompanyID);
            return View(gPU);
        }

        // GET: Admin/GPUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gPU = db.GPUs.Find(id);
            if (gPU == null)
            {
                return HttpNotFound();
            }
            return View(gPU);
        }

        // POST: Admin/GPUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPU gPU = db.GPUs.Find(id);
            db.GPUs.Remove(gPU);
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
