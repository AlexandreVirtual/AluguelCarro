using AluguelCarro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.Mapeamento
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);
            builder.Property(u => u.CPF).IsRequired();
            builder.Property(u => u.Telefone).IsRequired().HasMaxLength(30);

            builder.Ignore(i => i.EmailConfirmed);
            builder.Ignore(i => i.AccessFailedCount);
            builder.Ignore(i => i.LockoutEnabled);
            builder.Ignore(i => i.LockoutEnd);
            builder.Ignore(i => i.PhoneNumber);
            builder.Ignore(i => i.PhoneNumberConfirmed);
            builder.Ignore(i => i.TwoFactorEnabled);

            // Usuário tem vários Endereços (HasMany) e esse Endereço Possui à Um Usuário (WithOne)
            builder.HasMany(u => u.Enderecos).WithOne(u => u.Usuario);
            builder.HasMany(u => u.Alugueis).WithOne(u => u.Usuario);


            builder.HasOne(u => u.Conta).WithOne(u => u.Usuario);

            builder.ToTable("Usuarios");
        }
    }
}
