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
    public class RAMsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RAMsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/RAMs
        public ActionResult Index()
        {
            var rams = _unitOfWork.Rams.GetAll();
            return View(rams.ToList());
        }

        // GET: Admin/RAMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RAM ram = _unitOfWork.Rams.GetById(id);

            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        // GET: Admin/RAMs/Create
        public ActionResult Create()
        {
            var viewmodel = new PcPartsViewModel()
            {
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
        }

        // POST: Admin/RAMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RAM ram, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if(ImageFile == null)
                {
                    ram.Thumbnail = "na_image.jpg";
                }
                else
                {
                    ram.Thumbnail = Path.GetFileName(ImageFile.FileName);
                    string filename = Path.Combine(Server.MapPath("~/img/"), ram.Thumbnail);
                    ImageFile.SaveAs(filename);
                }
                _unitOfWork.Rams.Create(ram);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewmodel = new PcPartsViewModel()
            {
                RAM= new RAM(),
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            return View(viewmodel);
        }

        // GET: Admin/RAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RAM ram = _unitOfWork.Rams.GetById(id);

            if (ram == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new PcPartsViewModel()
            {
                RAM = ram,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            return View(viewmodel);
        }

        // POST: Admin/RAMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RAM ram)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Rams.Update(ram);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewmodel = new PcPartsViewModel()
            {
                RAM = ram,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
        }

        // GET: Admin/RAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RAM ram = _unitOfWork.Rams.GetById(id);

            if (ram == null)
            {
                return HttpNotFound();
            }
            return View(ram);
        }

        // POST: Admin/RAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            RAM ram = _unitOfWork.Rams.GetById(id);

            if (ram == null)
                return HttpNotFound();

            _unitOfWork.Rams.Delete(id);
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
