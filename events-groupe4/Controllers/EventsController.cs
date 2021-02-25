using events_groupe4.Filters;
using events_groupe4.Models;
using events_groupe4.Repositories;
using events_groupe4.Services;
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

        private IEventService eventSce;

        // GET: Events

        public EventsController()
        {
            eventSce = new EventService(new EventRepository(db));
        }


       // [RolesFilter(UserRole.ADMIN)]
        public ActionResult Index()
        {
            //var events = db.Events.ToList(); // Include(@ => @.categorie);
            //return View(events);
            var lstEvent= eventSce.FindAll(1, 15, "");

            return View("Index", lstEvent);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = eventSce.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }


        [HttpGet]
        [Route("CreateEvent")]
        public ActionResult Create()
        {
            ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle");
            return View("Create", new Event());
        }



        // GET: Events/Create
        //public ActionResult Create()
        //{
        //    ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle");
        //    return View();
        //}

      
        [HttpPost]
        [Route("CreateEvent")]
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


        [HttpGet]
        [Route("EditEvent/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = eventSce.Find(id);

            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle", @event.categorieId);
            return View(@event);
        }


        [HttpPost]
        [Route("EditEvent/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titre,description,DateDebut,DateFin,publie,categorieId")] Event @event)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(@event).State = EntityState.Modified;
                eventSce.Update(@event);
              //  db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.categorieId = new SelectList(db.Categories, "Id", "Libelle", @event.categorieId);
            return View(@event);
        }



        // GET: Events/Delete/5
        [HttpGet]
        [Route("DeleteEvent/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = eventSce.Find(id);
            //Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("DeleteEventConf/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            eventSce.Remove(id);
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