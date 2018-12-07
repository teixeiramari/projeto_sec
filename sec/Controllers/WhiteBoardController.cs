using sec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var identity = User.Identity as ClaimsIdentity;

            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            ViewBag.usuarios = new SelectList(db.Usuarios.Where(a => a.Id != id), "Id", "Nome");
            return View();
        }
    }
}