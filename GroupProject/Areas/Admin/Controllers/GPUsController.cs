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

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GPUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GPUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/GPUs
        public ActionResult Index()
        {
            var gpus = _unitOfWork.Gpus.GetAll();
            return View(gpus.ToList());
        }

        // GET: Admin/GPUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gpu = _unitOfWork.Gpus.GetById(id);
            if (gpu == null)
            {
                return HttpNotFound();
            }
            return View(gpu);
        }

        // GET: Admin/GPUs/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Admin/GPUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GPU gpu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Gpus.Create(gpu);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", gpu.CompanyID);
            return View(gpu);
        }

        // GET: Admin/GPUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gpu = _unitOfWork.Gpus.GetById(id);
            if (gpu == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", gpu.CompanyID);
            return View(gpu);
        }

        // POST: Admin/GPUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GPU gpu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Gpus.Update(gpu);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", gpu.CompanyID);
            return View(gpu);
        }

        // GET: Admin/GPUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GPU gpu = _unitOfWork.Gpus.GetById(id);
            if (gpu == null)
            {
                return HttpNotFound();
            }
            return View(gpu);
        }

        // POST: Admin/GPUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GPU gpu = _unitOfWork.Gpus.GetById(id);
            _unitOfWork.Gpus.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
