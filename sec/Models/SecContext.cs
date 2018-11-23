using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sec.Models
{
    public class SecContext : DbContext
    {
        public SecContext() : base("name=SecContext")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Preferencia> Preferencias { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasMany(m => m.Amigos).WithMany();
        }
    }
}