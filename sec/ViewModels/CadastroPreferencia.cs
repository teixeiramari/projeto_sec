using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sec.ViewModels
{
    public class CadastroPreferencia
    {
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(120, ErrorMessage = "A descrição não poderá ultrapassar 120 caracteres!")]
        public string Descricao { get; set; }
    }
}