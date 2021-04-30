using bomtrato.backend.models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace bomtrato.backend.data.EntityConfigurations
{
    public class UsuarioPerfilConfiguration : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.HasKey(up => new {up.UsuarioId, up.PerfilId });
            builder.HasOne(up => up.Usuario).WithMany(u => u.UsuariosPerfis).HasForeignKey(up => up.UsuarioId);
            builder.HasOne(up => up.Perfil).WithMany(p => p.UsuariosPerfis).HasForeignKey(up => up.PerfilId);
            
        }
    }
}
