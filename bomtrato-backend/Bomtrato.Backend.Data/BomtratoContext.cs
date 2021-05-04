using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Bomtrato.Backend.Data.Entities;
using Bomtrato.Backend.Data.EntityConfigurations;
using Microsoft.Extensions.Options;

namespace Bomtrato.Backend.Data
{
    public class BomtratoContext : DbContext 
    {


       
        public BomtratoContext( ) :
            base() {  
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Password=1234;Persist Security Info=True;User ID=sa;Initial Catalog=DB_BOMTRATO;Data Source=.\\")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Perfil>(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
        
        }




        public virtual DbSet<Perfil> Perfis { get; set; }
        public virtual DbSet<Processo> Processos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


    }
}
