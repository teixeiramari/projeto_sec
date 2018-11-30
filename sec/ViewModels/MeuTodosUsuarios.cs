using sec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sec.ViewModels
{
    public class MeuTodosUsuarios
    {
        public MeuTodosUsuarios()
        {
            Amigos = new List<Usuario>();
            Outros = new List<Usuario>();
        }
        public List<Usuario> Amigos { get; set; }
        public List<Usuario> Outros { get; set; }
    }
}