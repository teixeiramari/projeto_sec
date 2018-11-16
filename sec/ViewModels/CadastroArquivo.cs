using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sec.ViewModels
{
    public class CadastroArquivo
    {
        [Required(ErrorMessage = "O campo Arquivo é obrigatório!")]
        public byte[] Arq { get; set; }

        [MaxLength(250, ErrorMessage = "A descrição não poderá ultrapassar 250 caracteres!")]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(50)]
        public string Extensao { get; set; }

        [Required]
        public int Tamanho { get; set; }

        [Required]
        public string Caminho { get; set; }
    }
}