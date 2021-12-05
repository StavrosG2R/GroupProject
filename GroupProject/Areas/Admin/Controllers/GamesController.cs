using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess.Core.Entities;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;

namespace GroupProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GamesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Games
        public ActionResult Index()
        {
            var games = _unitOfWork.Games.GetAll();
            return View(games.ToList());
        }

        // GET: Admin/Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _unitOfWork.Games.GetById(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Admin/Games/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name");
            return View();
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Games.Create(game);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", game.CompanyID);
            return View(game);
        }

        // GET: Admin/Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _unitOfWork.Games.GetById(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", game.CompanyID);
            return View(game);
        }

        // POST: Admin/Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Games.Update(game);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(_unitOfWork.Companies.GetAll(), "ID", "Name", game.CompanyID);
            return View(game);
        }

        // GET: Admin/Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _unitOfWork.Games.GetById(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Admin/Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = _unitOfWork.Games.GetById(id);
            _unitOfWork.Games.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
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
