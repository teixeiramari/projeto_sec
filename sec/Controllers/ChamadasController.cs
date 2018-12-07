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
    public class ChamadasController : Controller
    {
        private SecContext db = new SecContext();

        public ActionResult Index()
        {
            
            var identity = User.Identity as ClaimsIdentity;

            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            var usuario = db.Usuarios.Find(id);
            ViewBag.usuarios = new SelectList( db.Usuarios.Where(a => a.Id != id).ToList(), "Id", "Nome");
            return View(usuario);
        }
    }
}