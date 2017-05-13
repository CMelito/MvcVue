using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5GulpWebpackVue.Controllers
{
    public class SpaController : Controller
    {
        // GET: Spa
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}