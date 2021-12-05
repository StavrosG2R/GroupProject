using DataAccess.Core.Entities;
using DataAccess.Persistence;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoragesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Storages
        public ActionResult Index()
        {
            var storages = db.Storages.Include(s => s.Company);
            return View(storages.ToList());
        }

        // GET: Admin/Storages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storages.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // GET: Admin/Storages/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Admin/Storages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Model,Capacity,StorageType,ReadSpeed,WriteSpeed,Thumbnail,Price")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                db.Storages.Add(storage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", storage.CompanyID);
            return View(storage);
        }

        // GET: Admin/Storages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storages.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", storage.CompanyID);
            return View(storage);
        }

        // POST: Admin/Storages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Model,Capacity,StorageType,ReadSpeed,WriteSpeed,Thumbnail,Price")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", storage.CompanyID);
            return View(storage);
        }

        // GET: Admin/Storages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storages.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: Admin/Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Storage storage = db.Storages.Find(id);
            db.Storages.Remove(storage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
