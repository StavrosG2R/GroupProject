using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;
using GroupProject.ViewModels;

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
            var viewmodel = new PcPartsViewModel()
            {
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
        }

        // POST: Admin/GPUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GPU gpu, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile == null)
                {
                    gpu.Thumbnail = "na_image.jpg";
                }
                else
                {
                    gpu.Thumbnail = Path.GetFileName(ImageFile.FileName);
                    string filename = Path.Combine(Server.MapPath("~/img/"), gpu.Thumbnail);
                    ImageFile.SaveAs(filename);
                }
                _unitOfWork.Gpus.Create(gpu);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var viewmodel = new PcPartsViewModel()
            {
                GPU = new GPU(),
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            
            return View(viewmodel);
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

            var viewmodel = new PcPartsViewModel()
            {
                GPU = gpu,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
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

            var viewmodel = new PcPartsViewModel()
            {
                GPU = gpu,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
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
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            GPU gpu = _unitOfWork.Gpus.GetById(id);

            if (gpu == null)
                return HttpNotFound();

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
