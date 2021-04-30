using bomtrato.backend.models.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bomtrato.backend.service.Interfaces
{
    public interface IProcessoService : IService<Processo>
    {
        IEnumerable<Processo> GetAprovados();

        IEnumerable<Processo> GetNaoAprovados();

        IEnumerable<Processo> GetPorUsuario(int usuarioId);
    }
}
