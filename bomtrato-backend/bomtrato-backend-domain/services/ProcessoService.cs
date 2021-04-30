using bomtrato.backend.data.interfaces;
using bomtrato.backend.models.entities;
using bomtrato.backend.service.Interfaces;
using bomtrato.backend.service.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace bomtrato.backend.service.services
{
    public class ProcessoService : Service<Processo>, IProcessoService
    {
        public IProcessoRepository Repository;
        public ProcessoService(IProcessoRepository repository) : base(repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Processo> GetAprovados()
        {
            return Repository.GetProcessosAprovados();
        }

        public IEnumerable<Processo> GetNaoAprovados()
        {
            return Repository.GetProcessosNaoAprovados();
        }

        public IEnumerable<Processo> GetPorUsuario(int usuarioId)
        {
            return Repository.GetProcessosPorUsuario(usuarioId);
        }

        public int Update(int id) 
        {
            return Repository.Update(id);
        }
    }
}
