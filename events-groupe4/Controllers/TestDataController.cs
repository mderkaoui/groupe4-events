using events_groupe4.Models;
using events_groupe4.Repositories;
using events_groupe4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events_groupe4.Controllers
{
    public class TestDataController : Controller
    {
        private MyContext db;
        private IUtilisateurService userService;

        public TestDataController()
        {
            db = new MyContext();
            userService = new UtilisateurService(new UtilisateurRepository(db));
        }

        // GET: /TestData
        public ActionResult Index()
        {
            

            userService.Save(new Models.Utilisateur
            {
                Role = UserRole.ADMIN,
                Email = "admin@dawan.fr",
                Password = "admin",
                City = "Paris",
                Birthday = DateTime.Now,
                FirstName = "PrenAdmin",
                LastName = "NomAdmin",
                Address = "Rue de la paix"
            });

            userService.Save(new Models.Utilisateur
            {
                Role = UserRole.ORGANISATEUR,
                Email = "organisateur@dawan.fr",
                Password = "organisateur",
                City = "Paris",
                Birthday = DateTime.Now,
                FirstName = "Prenorganisateur",
                LastName = "Nomorganisateur",
                Address = "Rue de la paix"
            });

            userService.Save(new Models.Utilisateur
            {
                Role = UserRole.ADHERENT,
                Email = "adherent@dawan.fr",
                Password = "adherent",
                City = "Paris",
                Birthday = DateTime.Now,
                FirstName = "Prenadherent",
                LastName = "Nomadherent",
                Address="Rue de la paix"
            });
            return View();
        }

        //La méthode Dispose sera appelée à la destruction de l'objet TestDataController
        //On en profites pour tuer le contexte de la base (db) afin de ne pas maintenir une connexion ouverte
        //(pour éviter une fuite mémoire)
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