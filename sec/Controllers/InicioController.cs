using sec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
  
            return View(RetornaUsuario());
        }

        public Usuario RetornaUsuario()
        {
            var identity = User.Identity as ClaimsIdentity;

            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            var usuario = db.Usuarios.Find(id);
            return usuario;
        }
    }
}