using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        // GET: Admin/Admins
        public ActionResult Index()
        {
            return View();
        }
    }
}