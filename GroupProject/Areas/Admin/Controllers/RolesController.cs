using DataAccess.Persistence;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        // Create: Admin/Roles
        public ActionResult Create()
        {
            return View();
        }

        // POST_CREATE: Admin/Roles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            _roleManager.Create(role);

            return RedirectToAction("Index", "Roles");
        }

        // DELETE: Admin/Roles
        public ActionResult Delete()
        {
            return View();
        }

        // POST_DELETE: Admin/Roles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(IdentityRole role)
        {
            var role1 = _roleManager.FindByName(role.Name);

            _roleManager.Delete(role1);

            return RedirectToAction("Index", "Roles");
        }

        // USERS list
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