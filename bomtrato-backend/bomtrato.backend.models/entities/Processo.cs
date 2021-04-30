using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bomtrato.backend.models.entities
{
    public class Processo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long NumeroProcesso { get; set; }

        public double Valor { get; set; }

        public String Escritorio { get; set; }

        public String Reclamante { get; set; }

        public bool Aprovado { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
