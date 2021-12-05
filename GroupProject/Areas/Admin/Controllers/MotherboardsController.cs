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
    public class MotherboardsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MotherboardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Motherboards
        public ActionResult Index()
        {
            var motherboards = _unitOfWork.Motherboards.GetAll();
            return View(motherboards.ToList());
        }

        // GET: Admin/Motherboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = _unitOfWork.Motherboards.GetById(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
        }

        // GET: Admin/Motherboards/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Admin/Motherboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Motherboards.Create(motherboard);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", motherboard.CompanyID);
            return View(motherboard);
        }

        // GET: Admin/Motherboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = _unitOfWork.Motherboards.GetById(id);
            if (motherboard == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", motherboard.CompanyID);
            return View(motherboard);
        }

        // POST: Admin/Motherboards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Motherboards.Update(motherboard);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", motherboard.CompanyID);
            return View(motherboard);
        }

        // GET: Admin/Motherboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motherboard motherboard = _unitOfWork.Motherboards.GetById(id);
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
            Motherboard motherboard = _unitOfWork.Motherboards.GetById(id);
            _unitOfWork.Motherboards.Delete(id);
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
