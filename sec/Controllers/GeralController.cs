using sec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sec.Controllers
{
    public class GeralController : Controller
    {
        private SecContext db = new SecContext();
        public JsonResult AddPreferencia(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;
            Preferencia p = new Preferencia
            {
                Descricao = nome
            };
            db.Preferencias.Add(p);
            db.SaveChanges();
            return Json(new { Id = p.Id, Descricao = p.Descricao });
        }
    }
}