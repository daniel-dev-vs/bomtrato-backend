using System;
using System.Collections.Generic;
using System.Text;

namespace bomtrato.backend.models.entities
{
    public class UsuarioPerfil
    {
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int PerfilId { get; set; }

        public Perfil Perfil { get; set; }
    }
}
