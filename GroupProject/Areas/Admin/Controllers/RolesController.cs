using DataAccess.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleStore<IdentityRole> _rolestore;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController()
        {
            _context = new ApplicationDbContext();
            _rolestore = new RoleStore<IdentityRole>(_context);
            _roleManager = new RoleManager<IdentityRole>(_rolestore);
        }
        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View(_context.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            _roleManager.Create(role);

            return RedirectToAction("Index", "Roles");
        }

        //delete
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(IdentityRole role)
        {
            var role1 = _roleManager.FindByName(role.Name);

            _roleManager.Delete(role1);

            return RedirectToAction("Index", "Roles");
        }

        public ActionResult IdentityUsers()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}