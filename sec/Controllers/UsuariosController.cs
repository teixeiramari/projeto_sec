using sec.Models;
using sec.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace sec.Controllers
{
    public class UsuariosController : Controller
    {
        private SecContext db = new SecContext();
        // GET: Usuarios
        public ActionResult Index()
        {
            var identity = User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var usuario = db.Usuarios.Find(id);

            List<int> zotro = new List<int>();
            zotro.Add(id);
            zotro.AddRange(usuario.Amigos.Select(u => u.Id));
            MeuTodosUsuarios retorno = new MeuTodosUsuarios();
            retorno.Amigos = usuario.Amigos;


            retorno.Outros = db.Usuarios.Where(u => !zotro.Contains(u.Id)).ToList();
            return View(retorno);

        }
    }
}