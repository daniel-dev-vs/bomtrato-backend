using Bomtrato.Backend.Data.Interfaces;
using Bomtrato.Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BomtratoContext contexto) : base(contexto)
        { 
            
        }

        public BomtratoContext BomtratoContexto
        {
            get { return Contexto as BomtratoContext; }
        }
    }
}
