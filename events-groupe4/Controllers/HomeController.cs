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
    public class HomeController : Controller
    {


        private MyContext db = new MyContext();
        private IUtilisateurService _userService;

        public HomeController()
        {
            _userService = new UtilisateurService(new UtilisateurRepository(db));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Utilisateur u)
        {

            try
            {
                Utilisateur userInDb = _userService.CheckLogin(u.Email, u.Password);
                if (userInDb != null)
                {
                    Session["user_id"] = userInDb.Id;
                    Session["user_connected"] = true;
                    Session["user_role"] = userInDb.Role.ToString();
                    Session["user_name"] = userInDb.FirstName;

                    switch (userInDb.Role)
                    {
                        case UserRole.ADMIN:
                            return RedirectToAction("Index", "EspaceAdmin");
                        case UserRole.ORGANISATEUR:
                            return RedirectToAction("Index", "EspaceOrg");
                        case UserRole.ADHERENT:
                            return RedirectToAction("Index", "EspaceAdherent");
                    }


                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.Message;
                return View("Index", u);
            }
            return View();
        }

        //**************************************************************  logout ***************
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
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