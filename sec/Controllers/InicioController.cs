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
    public class InicioController : Controller
    {
        private SecContext db = new SecContext();
        // GET: Inicio

        public ActionResult Index()
        {
            ViewBag.preferencias = db.Preferencias.ToList();
            return View(RetornaUsuario());
        }
        public ActionResult AdicionarReferencia(int [] preferencias)
        {
            var usu = RetornaUsuario();
            foreach(int pref in preferencias)
            {
                usu.Preferencias.Add(db.Preferencias.Find(pref));
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CadastrarPref(string desc)
        {
            var usu = RetornaUsuario();
            usu.Preferencias.Add(new Preferencia { Descricao = desc });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ExcluirPrefencia(int pref)
        {
            var usu = RetornaUsuario();
            usu.Preferencias.Remove(db.Preferencias.Find(pref));
            db.SaveChanges();
            return Json("foi");
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