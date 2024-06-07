using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;
using UsuariosApp.Infra.Data.Mappings;

namespace UsuariosApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBUsuariosApp;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistoricoAtividadeUsuarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        public DbSet<HistoricoAtividadeUsuario> HistoricoAtividadeUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
