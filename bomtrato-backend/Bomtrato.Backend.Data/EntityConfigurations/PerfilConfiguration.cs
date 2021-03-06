using Bomtrato.Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Data.EntityConfigurations
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {            
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(20);                
            builder.HasData( new Perfil() {  Id =1 ,Nome = "Aprovador"}, new Perfil() { Id = 2, Nome = "Publico"}); ;
        }
    }
}
