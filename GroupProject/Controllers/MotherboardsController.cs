using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class MotherboardsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MotherboardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Motherboards
        public ActionResult Index()
        {
            var motherboards = _unitOfWork.Motherboards.GetAll();
            return View(motherboards.ToList());
        }

        // GET: Motherboards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Motherboard motherboard = _unitOfWork.Motherboards.GetById(id);

            if (motherboard == null)
            {
                return HttpNotFound();
            }
            return View(motherboard);
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