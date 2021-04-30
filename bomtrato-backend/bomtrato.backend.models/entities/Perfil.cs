using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bomtrato.backend.models.entities
{
    public class Perfil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Nome { get; set; }

        public virtual ICollection<UsuarioPerfil> UsuariosPerfis { get; set; }

    }
}
