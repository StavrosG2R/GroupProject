using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;
using GroupProject.ViewModels;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoragesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoragesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Storages
        public ActionResult Index()
        {
            var storages = _unitOfWork.Storages.GetAll();
            return View(storages.ToList());
        }

        // GET: Admin/Storages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Storage storage = _unitOfWork.Storages.GetById(id);

            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // GET: Admin/Storages/Create
        public ActionResult Create()
        {
            var viewmodel = new PcPartsViewModel()
            {
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
        }

        // POST: Admin/Storages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Storage storage, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if(ImageFile == null)
                {
                    storage.Thumbnail = "na_image.jpg";
                }
                else
                {
                    storage.Thumbnail = Path.GetFileName(ImageFile.FileName);
                    string filename = Path.Combine(Server.MapPath("~/img/"), storage.Thumbnail);
                    ImageFile.SaveAs(filename);
                }
                _unitOfWork.Storages.Create(storage);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewmodel = new PcPartsViewModel()
            {
                Storage = new Storage(),
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            
            return View(viewmodel);
        }

        // GET: Admin/Storages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Storage storage = _unitOfWork.Storages.GetById(id);

            if (storage == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new PcPartsViewModel()
            {
                Storage = storage,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };
            
            return View(viewmodel);
        }

        // POST: Admin/Storages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Storage storage)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Storages.Update(storage);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            var viewmodel = new PcPartsViewModel()
            {
                Storage = storage,
                Companies = _unitOfWork.Companies.GetAll().ToList()
            };

            return View(viewmodel);
        }

        // GET: Admin/Storages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Storage storage = _unitOfWork.Storages.GetById(id);

            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: Admin/Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Storage storage = _unitOfWork.Storages.GetById(id);

            if (storage == null)
                return HttpNotFound();

            _unitOfWork.Storages.Delete(id);
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
