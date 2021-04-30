using bomtrato.backend.data.interfaces;
using bomtrato.backend.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bomtrato.backend.data.repositories
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

        public int Update(Processo entidade) 
        {
            BomtratoContexto.Processos.Update(entidade);
            return BomtratoContexto.SaveChanges();

        }

        public BomtratoContext BomtratoContexto
        {
            get { return Contexto as BomtratoContext; }
        }
    }
}
