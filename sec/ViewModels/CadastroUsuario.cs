using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sec.ViewModels
{
    public class CadastroUsuario
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [MaxLength(120, ErrorMessage = "O Nome não poderá ultrapassar 120 caracteres!")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Nick é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O nick não poderá ultrapassar 50 caracteres!")]
        public string nick { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        [MaxLength(120, ErrorMessage = "O e-mail não poderá ultrapassar 120 caracteres!")]
        public string email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6" + "caracteres")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6" + "caracteres")]
        [Compare(nameof(senha), ErrorMessage = "A senha e a" + "confirmação não estão iguais")]
        public string confirmasenha { get; set; }
    }
}