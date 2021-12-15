using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class CPUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CPUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Cpus
        public ActionResult Index()
        {
            var cpus = _unitOfWork.Cpus.GetAll();
            return View(cpus.ToList());
        }

        // GET: Cpus/Details/5
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