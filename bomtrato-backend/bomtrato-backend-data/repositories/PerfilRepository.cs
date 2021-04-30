using bomtrato.backend.data.interfaces;
using bomtrato.backend.models.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bomtrato.backend.data.repositories
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {

        public PerfilRepository(BomtratoContext contexto) : base( contexto)
        { 
        
        }

        public BomtratoContext BomtratoContexto
        {
            get { return Contexto as BomtratoContext; }
        }
    }
}
