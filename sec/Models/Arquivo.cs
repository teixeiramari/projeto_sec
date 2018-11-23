using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sec.Models
{
    [Table("Arquivo")]
    public class Arquivo
    {
        public Arquivo()
        {
            Preferencias = new List<Preferencia>();
        }
        [Key]
        public int Id { get; set; }

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

        
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        public virtual List<Preferencia> Preferencias { get; set; }
    }
}