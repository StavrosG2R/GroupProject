using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class GPUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GPUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: GPUs
        public ActionResult Index()
        {
            var gpus = _unitOfWork.Gpus.GetAll();
            return View(gpus.ToList());
        }

        // GET: GPUs/Details/5
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