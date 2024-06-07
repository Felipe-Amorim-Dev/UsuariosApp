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
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("ID");
            builder.Property(u => u.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(u => u.Sobrenome).HasColumnName("SOBRENOME").HasMaxLength(200).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(u => u.Senha).HasColumnName("SENHA").HasMaxLength(100).IsRequired();
            builder.Property(u => u.DataNascimento).HasColumnName("DATANASCIMENTO").IsRequired();
            builder.Property(u => u.Sexo).HasColumnName("SEXO").IsRequired();
            builder.Property(u => u.Endereco).HasColumnName("ENDERECO").HasMaxLength(300).IsRequired();
            builder.Property(u => u.Telefone).HasColumnName("TELEFONE").IsRequired();
            builder.Property(u => u.FotoPerfil).HasColumnName("FOTOPERFIL");
            builder.Property(u => u.DataHoraCriacao).HasColumnName("DATAHORACRIACAO").IsRequired();
            builder.Property(u => u.DataHoraAlteracao).HasColumnName("DATAHORAALTERACAO").IsRequired();

            builder.Ignore(u => u.AccessToken);
        }
    }
}
