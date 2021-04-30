using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using bomtrato.backend.models.entities;
using bomtrato.backend.data.EntityConfigurations;

namespace bomtrato.backend.data
{
    public class BomtratoContext : DbContext 
    {
      
        public BomtratoContext() :
            base() { 

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();
          
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("connection"));          
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Perfil>(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration<UsuarioPerfil>(new UsuarioPerfilConfiguration());
        }




        public virtual DbSet<Perfil> Perfis { get; set; }
        public virtual DbSet<Processo> Processos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


    }
}
