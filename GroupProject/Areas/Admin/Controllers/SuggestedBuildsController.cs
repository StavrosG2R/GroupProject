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
using GroupProject.ViewModels;

namespace GroupProject.Areas.Admin.Controllers
{
    public class SuggestedBuildsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SuggestedBuildsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/SuggestedBuilds
        public ActionResult Index()
        {
            var suggestedBuilds = _unitOfWork.SuggestedBuilds.GetAll();

            var viewmodel = new SuggestedBuildsViewModel()
            {
                SuggestedBuilds = suggestedBuilds,
            };
            return View("Index", viewmodel);
            //return View(suggestedBuilds.ToList());
        }

        // GET: Admin/SuggestedBuilds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestedBuild suggestedBuild = _unitOfWork.SuggestedBuilds.GetById(id);
            if (suggestedBuild == null)
            {
                return HttpNotFound();
            }
            return View(suggestedBuild);
        }

        // GET: Admin/SuggestedBuilds/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var viewmodel = new SuggestedBuildsViewModel()
            {
                Cases = _unitOfWork.Cases.GetAll(),
                CPUs = _unitOfWork.Cpus.GetAll(),
                GPUs = _unitOfWork.Gpus.GetAll(),
                Motherboards = _unitOfWork.Motherboards.GetAll(),
                PSUs = _unitOfWork.Psus.GetAll(),
                RAMs = _unitOfWork.Rams.GetAll(),
                Storages = _unitOfWork.Storages.GetAll(),
                Categories = _unitOfWork.Categories.GetAll()
            };
            return View(viewmodel);
        }

        // POST: Admin/SuggestedBuilds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(SuggestedBuildsViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Cases = _unitOfWork.Cases.GetAll();
                viewmodel.Categories = _unitOfWork.Categories.GetAll();
                viewmodel.CPUs = _unitOfWork.Cpus.GetAll();
                viewmodel.GPUs = _unitOfWork.Gpus.GetAll();
                viewmodel.Motherboards = _unitOfWork.Motherboards.GetAll();
                viewmodel.PSUs = _unitOfWork.Psus.GetAll();
                viewmodel.RAMs = _unitOfWork.Rams.GetAll();
                viewmodel.Storages = _unitOfWork.Storages.GetAll();
                return View(viewmodel);
            }

            var suggestedBuild = new SuggestedBuild()
            {
                CaseID = viewmodel.Case,
                CategoryID = viewmodel.Category,
                CPUID = viewmodel.CPU,
                GPUID = viewmodel.GPU,
                MotherboardID = viewmodel.Motherboard,
                PSUID = viewmodel.PSU,
                RAMID = viewmodel.RAM,
                StorageID = viewmodel.Storage,
                Price = viewmodel.Price,
                Name = viewmodel.Name
            };

            _unitOfWork.SuggestedBuilds.Add(suggestedBuild);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "SuggestedBuilds");
        }

        // GET: Admin/SuggestedBuilds/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            var suggestedBuild = _unitOfWork.SuggestedBuilds.GetById(id);

            if (suggestedBuild == null)
                return HttpNotFound();

           var viewmodel = new SuggestedBuildsViewModel()
            {
                Cases = _unitOfWork.Cases.GetAll(),
                Categories = _unitOfWork.Categories.GetAll(),
                CPUs = _unitOfWork.Cpus.GetAll(),
                GPUs = _unitOfWork.Gpus.GetAll(),
                Motherboards = _unitOfWork.Motherboards.GetAll(),
                PSUs = _unitOfWork.Psus.GetAll(),
                RAMs = _unitOfWork.Rams.GetAll(),
                Storages = _unitOfWork.Storages.GetAll(),
                Price = suggestedBuild.Price,
                Name = suggestedBuild.Name,
            };
            return View(viewmodel);
        }

        // POST: Admin/SuggestedBuilds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuggestedBuildsViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                viewmodel.Cases = _unitOfWork.Cases.GetAll();
                viewmodel.Categories = _unitOfWork.Categories.GetAll();
                viewmodel.CPUs = _unitOfWork.Cpus.GetAll();
                viewmodel.GPUs = _unitOfWork.Gpus.GetAll();
                viewmodel.Motherboards = _unitOfWork.Motherboards.GetAll();
                viewmodel.PSUs = _unitOfWork.Psus.GetAll();
                viewmodel.RAMs = _unitOfWork.Rams.GetAll();
                viewmodel.Storages = _unitOfWork.Storages.GetAll();
                return View(viewmodel);
            }

            var suggestedBuild = _unitOfWork.SuggestedBuilds.GetById(viewmodel.Id);

            if (suggestedBuild == null)
                return HttpNotFound();

            suggestedBuild.CaseID = viewmodel.Case;
            suggestedBuild.CategoryID = viewmodel.Category;
            suggestedBuild.CPUID = viewmodel.CPU;
            suggestedBuild.GPUID = viewmodel.GPU;
            suggestedBuild.MotherboardID = viewmodel.Motherboard;
            suggestedBuild.PSUID = viewmodel.PSU;
            suggestedBuild.RAMID = viewmodel.RAM;
            suggestedBuild.StorageID = viewmodel.Storage;
            suggestedBuild.Price = viewmodel.Price;
            suggestedBuild.Name = viewmodel.Name;

            _unitOfWork.Complete();

            return RedirectToAction("Index", "SuggestedBuilds");
        }

        // GET: Admin/SuggestedBuilds/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuggestedBuild suggestedBuild = _unitOfWork.SuggestedBuilds.GetById(id);
            if (suggestedBuild == null)
            {
                return HttpNotFound();
            }
            return View(suggestedBuild);
        }

        // POST: Admin/SuggestedBuilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuggestedBuild suggestedBuild = _unitOfWork.SuggestedBuilds.GetById(id);
            _unitOfWork.SuggestedBuilds.Delete(id);
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
