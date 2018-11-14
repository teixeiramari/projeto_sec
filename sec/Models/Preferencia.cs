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
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(120)]
        public string Descricao { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }
    }
}