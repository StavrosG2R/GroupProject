using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using GroupProject.ViewModels;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CasesController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public CasesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Cases
        public ActionResult Index()
        {
            var cases = _unitOfWork.Cases.GetAll(); 
            return View(cases.ToList());
        }

        // GET: Admin/Cases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = _unitOfWork.Cases.GetById(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Admin/Cases/Create
        public ActionResult Create()
        {
            var viewmodel = new PcPartsViewModel()
            {
                Case = new Case(),
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            return View(viewmodel);
        }

        // POST: Admin/Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Case @case, HttpPostedFileBase ImageFile)
        {

            if (ModelState.IsValid)
            {
                if (ImageFile == null)
                {
                    @case.Thumbnail = "na_image.jpg";
                }
                else
                {
                    @case.Thumbnail = Path.GetFileName(ImageFile.FileName);
                    string filename = Path.Combine(Server.MapPath("~/img/"), @case.Thumbnail);
                    ImageFile.SaveAs(filename);
                }
                _unitOfWork.Cases.Create(@case);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            var viewmodel = new PcPartsViewModel()
            {
                Case = new Case(),
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            return View(viewmodel);
        }

        // GET: Admin/Cases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = _unitOfWork.Cases.GetById(id);
            if (@case == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new PcPartsViewModel()
            {
                Case = @case,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
        }

        // POST: Admin/Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Case @case)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cases.Update(@case);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewmodel = new PcPartsViewModel()
            {
                Case = @case,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
           
            return View(viewmodel);
        }

        // GET: Admin/Cases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Case @case = _unitOfWork.Cases.GetById(id);

            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // POST: Admin/Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Case @case = _unitOfWork.Cases.GetById(id);

            if (@case == null)
                return HttpNotFound();

            _unitOfWork.Cases.Delete(id);
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
