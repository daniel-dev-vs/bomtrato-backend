using Bomtrato.Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bomtrato.Backend.Service.Interfaces
{
    public interface IProcessoService : IService<Processo>
    {
        IEnumerable<Processo> GetAprovados();

        IEnumerable<Processo> GetNaoAprovados();

        IEnumerable<Processo> GetPorUsuario(int usuarioId);

        int? VerificaSeExisteProcessoPorNumero(long numeroProcesso);
    }
}
