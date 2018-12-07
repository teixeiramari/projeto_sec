using sec.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sec.ViewModels
{
    public class CadastroArquivo
    {
        [Required(ErrorMessage = "Adicione ao menos um arquivo!")]
        public HttpPostedFileBase[] Arqs { get; set; }

        [MaxLength(250, ErrorMessage = "A descrição não poderá ultrapassar 250 caracteres!")]
        public string Descricao { get; set; }

        public string NomeArquivo { get; set; }

        [Required(ErrorMessage = "Adicione ao menos uma preferência!")]
        public int[] Prefs { get; set; }
         
        public virtual Usuario Eu { get; set; }

        public virtual List<Preferencia> Preferencias { get; set; }
    }
}