using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using GroupProject.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class BuildsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuildsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult MyBuilds()
        {
            var userId = User.Identity.GetUserId();

            var myBuilds = _unitOfWork.Builds.MyBuilds(userId);

            return View(myBuilds);
        }

        // GET: Builds
        public ActionResult Index(string query = null)
        {
            var searchBuilds = _unitOfWork.Builds.SearchBuilds(query);

            var userId = User.Identity.GetUserId();

            var viewmodel = new BuildsViewModel()
            {
                Builds = searchBuilds,
                Followings = _unitOfWork.Followings
                    .GetFollowings(userId)
                    .ToLookup(a => a.FollowerId)
            };

            return View("Index", viewmodel);
        }

        // GET: Builds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Build build = _unitOfWork.Builds.GetById(id);
            if (build == null)
            {
                return HttpNotFound();
            }
            return View(build);
        }

        // GET: Builds/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewmodel = new BuildsFormViewModel()
            {
                Cases = _unitOfWork.Cases.GetAll(),
                Categories = _unitOfWork.Categories.GetAll(),
                CPUs = _unitOfWork.Cpus.GetAll(),
                GPUs = _unitOfWork.Gpus.GetAll(),
                Motherboards = _unitOfWork.Motherboards.GetAll(),
                PSUs = _unitOfWork.Psus.GetAll(),
                RAMs = _unitOfWork.Rams.GetAll(),
                Storages = _unitOfWork.Storages.GetAll(),
                Header = "Create a build"
            };
            return View("BuildsForm", viewmodel);
        }

        // POST: Builds/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuildsFormViewModel viewmodel)
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
                return View("BuildsForm", viewmodel);
            }

            var build = new Build()
            {
                BuilderID = User.Identity.GetUserId(),
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

            _unitOfWork.Builds.Add(build);
            _unitOfWork.Complete();

            return RedirectToAction("MyBuilds", "Builds");
        }

        // GET: Bulds/Edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            var build = _unitOfWork.Builds.GetById(id);

            if (build == null)
                return HttpNotFound();

            if (build.BuilderID != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            var viewmodel = new BuildsFormViewModel()
            {
                Id = build.ID,
                Cases = _unitOfWork.Cases.GetAll(),
                Categories = _unitOfWork.Categories.GetAll(),
                CPUs = _unitOfWork.Cpus.GetAll(),
                GPUs = _unitOfWork.Gpus.GetAll(),
                Motherboards = _unitOfWork.Motherboards.GetAll(),
                PSUs = _unitOfWork.Psus.GetAll(),
                RAMs = _unitOfWork.Rams.GetAll(),
                Storages = _unitOfWork.Storages.GetAll(),
                Price = build.Price,
                Name = build.Name,
                Header = "Edit build"
            };
            return View("BuildsForm", viewmodel);
        }

        //POST: Builds/Edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BuildsFormViewModel viewmodel)
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
                return View("BuildsForm", viewmodel);
            }

            var build = _unitOfWork.Builds.GetById(viewmodel.Id);

            if (build == null)
                return HttpNotFound();

            if (build.BuilderID != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            build.CaseID = viewmodel.Case;
            build.CategoryID = viewmodel.Category;
            build.CPUID = viewmodel.CPU;
            build.GPUID = viewmodel.GPU;
            build.MotherboardID = viewmodel.Motherboard;
            build.PSUID = viewmodel.PSU;
            build.RAMID = viewmodel.RAM;
            build.StorageID = viewmodel.Storage;
            build.Price = viewmodel.Price;
            build.Name = viewmodel.Name;

            _unitOfWork.Complete();

            return RedirectToAction("MyBuilds");
        }

        // GET: Builds/Delete/5
        public ActionResult Delete(int? id)
        {
            var userId = User.Identity.GetUserId();

            var builds = _unitOfWork.Builds.GetById(id);

            if (userId != builds.BuilderID)
                return new HttpUnauthorizedResult();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Build build = _unitOfWork.Builds.GetById(id);
            if (build == null)
            {
                return HttpNotFound();
            }
            return View(build);
        }

        // POST: Builds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            var userId = User.Identity.GetUserId();

            var builds = _unitOfWork.Builds.GetById(id);

            if (userId != builds.BuilderID)
                return new HttpUnauthorizedResult();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Build build = _unitOfWork.Builds.GetById(id);

            if (build == null)
                return HttpNotFound();

            _unitOfWork.Builds.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("MyBuilds");
        }

        // Search bar
        [HttpPost]
        public ActionResult Search(BuildsViewModel viewModel)
        {
            return RedirectToAction("Index", "Builds", new { query = viewModel.SearchBar });
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