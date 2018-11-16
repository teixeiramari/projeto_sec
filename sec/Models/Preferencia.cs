using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sec.Models
{
    [Table("Preferencia")]
    public class Preferencia
    {
        public Preferencia()
        {
            Usuarios = new List<Usuario>();
            Arquivos = new List<Arquivo>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(120, ErrorMessage = "A descrição não poderá ultrapassar 120 caracteres!")]
        public string Descricao { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }

        public virtual List<Arquivo> Arquivos { get; set; }
    }
}