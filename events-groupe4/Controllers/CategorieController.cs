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
    public class CategorieController : Controller
    {
        private MyContext db = new MyContext();
        private ICategorieService categSce;

        public CategorieController()
        {
            categSce = new CategorieService(new CategorieRepository(db));
        }




        // GET: Categorie
        public ActionResult Index()
        {
            var lstCateg = categSce.FindAll(1, 15, "");

            return View("Index", lstCateg);
        }



        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View("Create", new Categorie());
        }



        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle,Description,Type")] Categorie ctg)
        {
            if (ModelState.IsValid)
            {
                categSce.Save(ctg);
                return RedirectToAction("Index");
            }

            return View(ctg);
        }






        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categ = categSce.Find(id);
            if (categ == null)
            {
                return HttpNotFound();
            }
            return View(categ);
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            categSce.Remove(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categ = categSce.Find(id);
            if (categ == null)
            {
                return HttpNotFound();
            }
            return View(categ);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle,Description,Type")] Categorie categ)
        {
            if (ModelState.IsValid)
            {

                categSce.Update(categ);
                return RedirectToAction("Index");
            }
            return View(categ);
        }





        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie user = categSce.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



    }
}