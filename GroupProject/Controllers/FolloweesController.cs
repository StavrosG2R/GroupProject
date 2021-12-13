using DataAccess.Core.Interfaces;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GroupProject.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Followees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var builders = _unitOfWork.Users.GetBuildersFollowedBy(userId);

            return View(builders);
        }
    }
}