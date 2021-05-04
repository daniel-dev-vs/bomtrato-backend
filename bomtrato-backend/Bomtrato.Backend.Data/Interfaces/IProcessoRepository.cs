using Bomtrato.Backend.Data.Repositories;

using Bomtrato.Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Data.Interfaces
{
    public interface IProcessoRepository :  IRepository<Processo>
    {
        IEnumerable<Processo> GetProcessosAprovados();

        IEnumerable<Processo> GetProcessosNaoAprovados();

        IEnumerable<Processo> GetProcessosPorUsuario(int usuarioId);

        int? VerificaSeExisteProcessoPorNumero(long numeroProcesso);

        
    }
}
