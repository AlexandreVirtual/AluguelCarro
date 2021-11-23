using AluguelCarro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.Mapeamento
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(c => c.ContaId);
            builder.Property(c => c.Saldo).IsRequired();

            builder.HasOne(c => c.Usuario).WithOne(c => c.Conta).HasForeignKey<Conta>(c=>c.UsuarioId);

            builder.ToTable("Contas");
        }
    }
}
