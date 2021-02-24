using events_groupe4.Filters;
using events_groupe4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events_groupe4.Controllers
{
    //[RoutePrefix("espace-admin")] //pour avoir un URL user friendly : /espace-admin/....
    //[Route("{action=index}")] //l'action appelée par défaut si on ne précise pas
    [LoginFilter]
    [RolesFilter(UserRole.ADMIN)]
    public class EspaceAdminController : Controller
    {
        // GET: EspaceAdmin/Index
        //[Route("accueil")] si vous souhaitez modifier l'url /accueil
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}