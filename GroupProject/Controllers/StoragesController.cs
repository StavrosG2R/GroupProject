using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class StoragesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoragesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Storages
        public ActionResult Index()
        {
            var storages = _unitOfWork.Storages.GetAll();
            return View(storages.ToList());
        }

        // GET: Storages/Details/5
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
    }
}