using sec.Models;
using sec.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace sec.Controllers
{
    [Authorize]
    public class FileUploadController : Controller
    {
        private SecContext db = new SecContext();
        // GET: /FileUpload/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            var identity = User.Identity as ClaimsIdentity;
            ViewBag.retorno = ViewData["Message"];
            ViewData["Message"] = null;
            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            var usuario = db.Usuarios.Find(id);
            CadastroArquivo visao = new CadastroArquivo {
                Eu = usuario,
                Preferencias = db.Preferencias.ToList()
         
            };
            return View(visao);
        }

        public ActionResult FileUpload(CadastroArquivo model)
        {
            var identity = User.Identity as ClaimsIdentity;

            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(c => c.Type == "Id").Value);

            var usuario = db.Usuarios.Find(id);
            if (model.Prefs == null)
            {

                CadastroArquivo visao = new CadastroArquivo
                {
                    Eu = usuario,
                    Preferencias = db.Preferencias.ToList()

                };
                ModelState.AddModelError("Prefs", "Selecione ao menos uma preferência");
                return View("Upload", visao);
            }
            foreach(var arq in model.Arqs)
            {
                var byteDoArq = ArqParaByte(arq);
                Arquivo a = new Arquivo
                {
                    Arq = byteDoArq,
                    Caminho = arq.FileName,
                    IdUsuario = id,
                     Descricao = model.Descricao,
                     extensao = arq.ContentType
                };
                foreach(var p in model.Prefs)
                {
                    a.Preferencias.Add(db.Preferencias.Find(p));
                }
                db.Arquivos.Add(a);
                db.SaveChanges();
            }
            ViewData["Message"] = "Arquivos salvos com sucesso!";
            return RedirectToAction("Upload");
        }
        public static byte[] ArqParaByte(HttpPostedFileBase arq)
        {
            if (arq != null)
            {
                byte[] novoArq = new byte[arq.ContentLength];
                arq.InputStream.Read(novoArq, 0, arq.ContentLength);
                return novoArq;
            }
            else
                return null;
        }

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
        public FileContentResult DownloadArquivo(int id)
        {

            var arq = db.Arquivos.Find(id);
            if (arq == null)
                return null;
            return File(arq.Arq, arq.extensao, arq.Caminho);

        }
    }
}