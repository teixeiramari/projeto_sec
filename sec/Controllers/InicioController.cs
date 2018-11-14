using sec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sec.Controllers
{
    public class InicioController : Controller
    {
        private SecContext db = new SecContext();
        // GET: Inicio
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.marilinda = "Mari linda!";
            return View();
        }

    }
}