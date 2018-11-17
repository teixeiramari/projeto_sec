using sec.Models;
using sec.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sec.Controllers
{
    public class AutenticacaoController : Controller
    {

        private SecContext db = new SecContext();
        // GET: Autenticacao

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(Usuario usu)
        {
            var usuario = db.Usuarios.Where(u => u.Nick == usu.Nick && u.Senha == usu.Senha).FirstOrDefault();
            if(usuario != null)
            {
                // redirecionado para a parte do painel
                return RedirectToAction("Index", "Inicio");
            }
            else
            {
                return View("Login");
            }
           
        }
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuario dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            Usuario u = new Usuario
            {
                Nome = dto.nome,
                Email = dto.email,
                Nick = dto.nick,
                Senha = dto.senha
            };
            db.Usuarios.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}