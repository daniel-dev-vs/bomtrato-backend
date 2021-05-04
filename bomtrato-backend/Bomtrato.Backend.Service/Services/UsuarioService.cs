using Bomtrato.Backend.Data.Interfaces;
using Bomtrato.Backend.Data.Entities;
using Bomtrato.Backend.Service.Interfaces;
using Bomtrato.Backend.Service.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Service.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {

        private IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository) : base(repository) {
            this._repository = repository;
        }

  
    }
}
