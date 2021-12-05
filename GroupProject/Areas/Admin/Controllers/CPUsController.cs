using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CpusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CpusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Cpus
        public ActionResult Index()
        {
            var Cpus = _unitOfWork.Cpus.GetAll();
            return View(Cpus.ToList());
        }

        // GET: Admin/Cpus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cPU = _unitOfWork.Cpus.GetById(id);
            if (cPU == null)
            {
                return HttpNotFound();
            }
            return View(cPU);
        }

        // GET: Admin/Cpus/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Admin/Cpus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CPU cPU)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cpus.Create(cPU);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", cPU.CompanyID);
            return View(cPU);
        }

        // GET: Admin/Cpus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cPU = _unitOfWork.Cpus.GetById(id);
            if (cPU == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", cPU.CompanyID);
            return View(cPU);
        }

        // POST: Admin/Cpus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CPU cPU)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cpus.Update(cPU);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", cPU.CompanyID);
            return View(cPU);
        }

        // GET: Admin/Cpus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CPU cPU = _unitOfWork.Cpus.GetById(id);
            if (cPU == null)
            {
                return HttpNotFound();
            }
            return View(cPU);
        }

        // POST: Admin/Cpus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CPU cPU = _unitOfWork.Cpus.GetById(id);
            _unitOfWork.Cpus.Delete(id);
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
