using sec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sec.Controllers
{
    [Authorize]
    public class WhiteBoardController : Controller
    {
        private SecContext db = new SecContext();
        // GET: WhiteBoard
        public ActionResult Index()
        {
            ViewBag.usuarios = new SelectList(db.Usuarios, "Id", "Nome");
            return View();
        }
    }
}