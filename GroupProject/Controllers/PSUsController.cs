using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class PSUsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PSUsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/PSUs
        public ActionResult Index()
        {
            var pSUs = _unitOfWork.Psus.GetAll();
            return View(pSUs.ToList());
        }

        // GET: Admin/PSUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PSU psu = _unitOfWork.Psus.GetById(id);

            if (psu == null)
            {
                return HttpNotFound();
            }
            return View(psu);
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