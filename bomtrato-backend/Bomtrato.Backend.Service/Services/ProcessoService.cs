using Bomtrato.Backend.Data.Interfaces;
using Bomtrato.Backend.Data.Entities;
using Bomtrato.Backend.Service.Interfaces;
using Bomtrato.Backend.Service.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Service.Services
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

        public int? VerificaSeExisteProcessoPorNumero(long numeroProcesso)
        {
            return Repository.VerificaSeExisteProcessoPorNumero(numeroProcesso);
        }
    }
}
