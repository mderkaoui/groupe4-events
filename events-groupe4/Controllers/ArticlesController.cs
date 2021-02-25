using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using events_groupe4.Models;
using events_groupe4.Repositories;

namespace events_groupe4.Controllers
{
    public class ArticleController : Controller
    {
        private MyContext db = new MyContext();
        private IArticlesService ArticSce;

        public ArticleController()
        {
            ArticSce = new ArticleService(new ArticleRepository(db));
        }




        // GET: Categorie
        public ActionResult Index()
        {
            var lstCateg = ArticSce.FindAll(1, 15, "");

            return View("Index", lstCateg);
        }



        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View("Create", new Article());
        }



        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle,Description,Type")] Article article)
        {
            if (ModelState.IsValid)
            {
                ArticSce.Save(article);
                return RedirectToAction("Index");
            }

            return View(article);
        }






        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = ArticSce.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticSce.Remove(id);
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
            Article article = ArticSce.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle,Description,Type")] Article article)
        {
            if (ModelState.IsValid)
            {

                ArticSce.Update(article);
                return RedirectToAction("Index");
            }
            return View(article);
        }





        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article user = ArticSce.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



    }
}