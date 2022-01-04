using DataAccess.Core.Interfaces;
using GroupProject.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            SuggestedBuildsViewModel viewmodel = new SuggestedBuildsViewModel()
            {
                SuggestedBuilds = _unitOfWork.SuggestedBuilds.GetAll().Take(4)
            };

            return View(viewmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PCParts()
        {
            return View();
        }
    }
}