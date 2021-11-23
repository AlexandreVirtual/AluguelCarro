using AluguelCarro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AluguelCarro.Mapeamento
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(a => a.AluguelId);

            builder.Property(a => a.Inicio).IsRequired();
            builder.Property(a => a.Fim).IsRequired();
            builder.Property(a => a.PrecoTotal).IsRequired();

            builder.HasOne(a => a.Usuario).WithMany(a => a.Alugueis).HasForeignKey(a => a.UsuarioId);
            builder.HasOne(a => a.Carro).WithMany(a => a.Alugueis).HasForeignKey(a => a.CarroId);

            builder.ToTable("Alugueis");
        }
    }
}
