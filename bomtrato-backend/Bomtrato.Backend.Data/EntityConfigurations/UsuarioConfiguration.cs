using Bomtrato.Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.ValueGeneration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Data.EntityConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {


            
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(15);
            builder.Property(u => u.Senha).IsRequired();


        }
    }
}
