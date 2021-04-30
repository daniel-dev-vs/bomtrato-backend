using bomtrato.backend.data.repositories;

using bomtrato.backend.models.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bomtrato.backend.data.interfaces
{
    public interface IProcessoRepository :  IRepository<Processo>
    {
        IEnumerable<Processo> GetProcessosAprovados();

        IEnumerable<Processo> GetProcessosNaoAprovados();

        IEnumerable<Processo> GetProcessosPorUsuario(int usuarioId);

        int Update(int id);
    }
}
