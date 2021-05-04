using Bomtrato.Backend.Data.Interfaces;
using Bomtrato.Backend.Data.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomtrato.Backend.Data.Repositories
{
    public class ProcessoRepository : Repository<Processo>, IProcessoRepository
    {

       // private BomtratoContext BomtratoContexto;
        public ProcessoRepository(BomtratoContext contexto) 
            : base( contexto) 
        {
            
        }

        public IEnumerable<Processo> GetProcessosAprovados()
        {
            return BomtratoContexto.Processos.Where(x => x.Aprovado == true);
        }

        public IEnumerable<Processo> GetProcessosPorUsuario(int usuarioId)
        {
            return BomtratoContexto.Processos.Where(x => x.UsuarioId == usuarioId);
        }

        public IEnumerable<Processo> GetProcessosNaoAprovados()
        {
            return BomtratoContexto.Processos.Where(x => x.Aprovado == false);
        }

        public int? VerificaSeExisteProcessoPorNumero(long numeroProcesso)
        {
            int? retorno = BomtratoContexto.Processos.Where(x => x.NumeroProcesso == numeroProcesso)?.Count() ;

            return retorno;
        }

        public BomtratoContext BomtratoContexto
        {
            get { return Contexto as BomtratoContext; }
        }
    }
}
