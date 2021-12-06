using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;
using GroupProject.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CPUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public CPUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Cpus
        public ActionResult Index()
        {
            var cpus = _unitOfWork.Cpus.GetAll();
            return View(cpus.ToList());
        }

        // GET: Admin/Cpus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CPU cpu = _unitOfWork.Cpus.GetById(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        // GET: Admin/Cpus/Create
        public ActionResult Create()
        {
            var viewmodel = new PcPartsViewModel()
            {
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
        }

        // POST: Admin/Cpus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(CPU cpu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cpus.Create(cpu);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewmodel = new PcPartsViewModel()
            {
                CPU = new CPU(),
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);

        }

        // GET: Admin/Cpus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CPU cpu = _unitOfWork.Cpus.GetById(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new PcPartsViewModel()
            {
                CPU = cpu,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);

        }

        // POST: Admin/Cpus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CPU cpu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cpus.Update(cpu);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var viewmodel = new PcPartsViewModel()
            {
                CPU = cpu,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            
            return View(viewmodel);


        }

        // GET: Admin/Cpus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CPU cpu = _unitOfWork.Cpus.GetById(id);
            if (cpu == null)
            {
                return HttpNotFound();
            }
            return View(cpu);
        }

        // POST: Admin/Cpus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            CPU cpu = _unitOfWork.Cpus.GetById(id);

            if (cpu == null)
                return HttpNotFound();

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
