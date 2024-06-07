using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    public class HistoricoAtividadeUsuarioMap : IEntityTypeConfiguration<HistoricoAtividadeUsuario>
    {
        public void Configure(EntityTypeBuilder<HistoricoAtividadeUsuario> builder)
        {
            builder.ToTable("HISTORICOATIVIDADEUSUARIO");

            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).HasColumnName("ID");
            builder.Property(h => h.DataHora).HasColumnName("DATAHORA").IsRequired();
            builder.Property(h => h.Tipo).HasColumnName("TIPO").IsRequired();
            builder.Property(h => h.Descricao).HasColumnName("DESCRICAO").HasMaxLength(250).IsRequired();
            builder.Property(h => h.UsuarioId).HasColumnName("USUARIO_ID").IsRequired();

            builder.HasOne(h => h.Usuario).WithMany(u => u.Historicos).HasForeignKey(h => h.UsuarioId);
        }
    }
}
