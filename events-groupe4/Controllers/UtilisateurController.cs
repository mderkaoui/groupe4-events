using events_groupe4.Filters;
using events_groupe4.Models;
using events_groupe4.Repositories;
using events_groupe4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace events_groupe4.Controllers
{
    [RoutePrefix("Utilisateurs")]
    [Route("{action=index}")]
    public class UtilisateurController : Controller
    {
        private MyContext db = new MyContext();
        private IUtilisateurService userService;

        public UtilisateurController()
        {
            userService = new UtilisateurService(new UtilisateurRepository(db));
        }

        [LoginFilter]
        [RolesFilter(UserRole.ADMIN)]
        [HttpGet]
        [Route("{page?}/{maxByPage?}/{searchField?}")]
        public ActionResult Index(int page = 1, int maxByPage = MyConstants.MAX_BY_PAGE, string searchField = "")
        {
            List<Utilisateur> usersLst = userService.FindAll(page, maxByPage, searchField);
            ViewBag.Page = page;
            ViewBag.maxByPage = maxByPage;
            ViewBag.searchField = searchField;
            ViewBag.NextExist = userService.NextExist(page, maxByPage, searchField);
            return View("Index", usersLst);
        }


        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View("Create", new Utilisateur());
        }



        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Email,Password,Address,City,Birthday,Role")] Utilisateur user)
        {
            if (ModelState.IsValid)
            {
                userService.Save(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }


        [LoginFilter]
        [RolesFilter(UserRole.ADMIN)]
        [HttpGet]
        [Route("Search")]
        public ActionResult Search([Bind(Include = "searchField")] string searchField)
        {
            return Index(searchField: searchField);
        }


        [LoginFilter]
        [RolesFilter(UserRole.ADMIN)]
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



        [LoginFilter]
        [RolesFilter(UserRole.ADMIN)]
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [LoginFilter]
        [RolesFilter(UserRole.ADMIN)]
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Email,Password,Address,City,Birthday,Role")] Utilisateur user)
        {
            if (ModelState.IsValid)
            {

                userService.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        [LoginFilter]
        [RolesFilter(UserRole.ADMIN)]
        [Route("Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur user = userService.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [LoginFilter]
        [RolesFilter(UserRole.ADMIN)]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            userService.Remove(id);
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}