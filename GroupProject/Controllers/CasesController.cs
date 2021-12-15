using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class CasesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CasesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Cases
        public ActionResult Index()
        {
            var cases = _unitOfWork.Cases.GetAll();
            return View(cases.ToList());
        }

        // GET: Cases/Details/5
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