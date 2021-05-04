using Bomtrato.Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Data.EntityConfigurations
{
    public class ProcessoConfiguration : IEntityTypeConfiguration<Processo>
    {
        public void Configure(EntityTypeBuilder<Processo> builder)
        {            
            builder.Property(p => p.Escritorio).IsRequired().HasMaxLength(50);
            builder.Property(p => p.NumeroProcesso).IsRequired().HasMaxLength(12);
            builder.Property(p => p.Valor).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Reclamante).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Aprovado);
            builder.Property(p => p.Ativo);
            builder.HasOne<Usuario>(p => p.Usuario).WithMany(p => p.Processos).HasForeignKey(p => p.UsuarioId).IsRequired(false);
           
            
        
        }
    }
}
