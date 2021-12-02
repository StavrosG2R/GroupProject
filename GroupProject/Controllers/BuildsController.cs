using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;

namespace GroupProject.Controllers
{
    public class BuildsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuildsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Builds
        public ActionResult Index()
        {
            //var builds = db.Builds.Include(b => b.Builder).Include(b => b.Case).Include(b => b.Category).Include(b => b.CPU).Include(b => b.GPU).Include(b => b.Motherboard).Include(b => b.PSU).Include(b => b.RAM).Include(b => b.Storage);
            var builds = _unitOfWork.Builds.GetAll();
            return View(builds.ToList());
        }

        //// GET: Builds/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Build build = db.Builds.Find(id);
        //    if (build == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(build);
        //}

        //// GET: Builds/Create
        //public ActionResult Create()
        //{
        //    ViewBag.BuilderID = new SelectList(db.Users, "Id", "Name");
        //    ViewBag.CaseID = new SelectList(db.Cases, "ID", "Model");
        //    ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
        //    ViewBag.CPUID = new SelectList(db.CPUs, "ID", "Socket");
        //    ViewBag.GPUID = new SelectList(db.GPUs, "ID", "Chipset");
        //    ViewBag.MotherboardID = new SelectList(db.Motherboards, "ID", "Socket");
        //    ViewBag.PSUID = new SelectList(db.PSUs, "ID", "Efficiency");
        //    ViewBag.RAMID = new SelectList(db.RAMs, "ID", "Model");
        //    ViewBag.StorageID = new SelectList(db.Storages, "ID", "Model");
        //    return View();
        //}

        //// POST: Builds/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Name,BuilderID,CaseID,CPUID,MotherboardID,RAMID,GPUID,PSUID,StorageID,Price,CategoryID,IsAdminBuild")] Build build)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Builds.Add(build);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.BuilderID = new SelectList(db.Users, "Id", "Name", build.BuilderID);
        //    ViewBag.CaseID = new SelectList(db.Cases, "ID", "Model", build.CaseID);
        //    ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", build.CategoryID);
        //    ViewBag.CPUID = new SelectList(db.CPUs, "ID", "Socket", build.CPUID);
        //    ViewBag.GPUID = new SelectList(db.GPUs, "ID", "Chipset", build.GPUID);
        //    ViewBag.MotherboardID = new SelectList(db.Motherboards, "ID", "Socket", build.MotherboardID);
        //    ViewBag.PSUID = new SelectList(db.PSUs, "ID", "Efficiency", build.PSUID);
        //    ViewBag.RAMID = new SelectList(db.RAMs, "ID", "Model", build.RAMID);
        //    ViewBag.StorageID = new SelectList(db.Storages, "ID", "Model", build.StorageID);
        //    return View(build);
        //}

        //// GET: Builds/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Build build = db.Builds.Find(id);
        //    if (build == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.BuilderID = new SelectList(db.Users, "Id", "Name", build.BuilderID);
        //    ViewBag.CaseID = new SelectList(db.Cases, "ID", "Model", build.CaseID);
        //    ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", build.CategoryID);
        //    ViewBag.CPUID = new SelectList(db.CPUs, "ID", "Socket", build.CPUID);
        //    ViewBag.GPUID = new SelectList(db.GPUs, "ID", "Chipset", build.GPUID);
        //    ViewBag.MotherboardID = new SelectList(db.Motherboards, "ID", "Socket", build.MotherboardID);
        //    ViewBag.PSUID = new SelectList(db.PSUs, "ID", "Efficiency", build.PSUID);
        //    ViewBag.RAMID = new SelectList(db.RAMs, "ID", "Model", build.RAMID);
        //    ViewBag.StorageID = new SelectList(db.Storages, "ID", "Model", build.StorageID);
        //    return View(build);
        //}

        //// POST: Builds/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name,BuilderID,CaseID,CPUID,MotherboardID,RAMID,GPUID,PSUID,StorageID,Price,CategoryID,IsAdminBuild")] Build build)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(build).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.BuilderID = new SelectList(db.Users, "Id", "Name", build.BuilderID);
        //    ViewBag.CaseID = new SelectList(db.Cases, "ID", "Model", build.CaseID);
        //    ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", build.CategoryID);
        //    ViewBag.CPUID = new SelectList(db.CPUs, "ID", "Socket", build.CPUID);
        //    ViewBag.GPUID = new SelectList(db.GPUs, "ID", "Chipset", build.GPUID);
        //    ViewBag.MotherboardID = new SelectList(db.Motherboards, "ID", "Socket", build.MotherboardID);
        //    ViewBag.PSUID = new SelectList(db.PSUs, "ID", "Efficiency", build.PSUID);
        //    ViewBag.RAMID = new SelectList(db.RAMs, "ID", "Model", build.RAMID);
        //    ViewBag.StorageID = new SelectList(db.Storages, "ID", "Model", build.StorageID);
        //    return View(build);
        //}

        //// GET: Builds/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Build build = db.Builds.Find(id);
        //    if (build == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(build);
        //}

        //// POST: Builds/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Build build = db.Builds.Find(id);
        //    db.Builds.Remove(build);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
