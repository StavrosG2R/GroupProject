using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class RAMsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RAMsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: RAMs
        public ActionResult Index()
        {
            var rams = _unitOfWork.Rams.GetAll();
            return View(rams.ToList());
        }

        // GET: RAMs/Details/5
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