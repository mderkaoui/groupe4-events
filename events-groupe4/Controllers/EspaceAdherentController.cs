using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events_groupe4.Controllers
{
    public class EspaceAdherentController : Controller
    {
        // GET: EspaceAdherent
        public ActionResult Index()
        {
            return View("Index"); //index.cshtml
        }

    }
}