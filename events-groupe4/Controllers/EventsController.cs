using events_groupe4.Models;
using events_groupe4.Repositories;
using events_groupe4.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace events_groupe4.Controllers
{
    public class EventsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.ToList(); // Include(@ => @.categorie);
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle");
            return View();
        }

        // POST: Events/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] //[Bind(Include = "Id,Titre,description,DateDebut,DateFin,publie,categorieId")]
        public ActionResult Create([Bind(Exclude = "Photo")] Event @event, HttpPostedFileBase photo)
        {
            string extension = Path.GetExtension(photo.FileName);
            if (extension.Equals(".png") || extension.Equals(".jpg") || extension.Equals(".jpeg"))
            {
                if (ModelState.IsValid)
                {
                    string fileName = @event.Titre + Path.GetExtension(photo.FileName);
                    @event.Photo = fileName;
                    string path = Server.MapPath("~/Photos/" + fileName);
                    photo.SaveAs(path);
                    db.Events.Add(@event);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return Content("l'extension de la photo doit etre  : .png , .jpg ou .jpeg");
            }


            ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle", @event.categorieId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle", @event.categorieId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre,description,DateDebut,DateFin,publie,categorieId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle", @event.categorieId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
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

        public new ActionResult View()
        {
            List<Event> events;

            events = db.Events.ToList();

            EventListViewModel viewModel = new EventListViewModel();
            viewModel.Events = events;
            //  viewModel.ProductsCategory = Categories;
            return View(viewModel);

        }
    }
}