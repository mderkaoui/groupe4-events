using events_groupe4.Filters;
using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events_groupe4.Controllers
{
    [LoginFilter]
    [RolesFilter(UserRole.ORGANISATEUR)]
    public class EspaceOrgController : Controller
    {
        // GET: EspaceOrg
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}