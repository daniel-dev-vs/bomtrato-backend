using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bomtrato.Backend.Data.Entities
{
    public class Processo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public long NumeroProcesso { get; set; }

        [Required]
        [Range(30000, double.MaxValue)]
       
        public double Valor { get; set; }

        [Required]
        [RegularExpression("^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$")]
        [MaxLength(50)]
        public String Escritorio { get; set; }

        [Required]
        [RegularExpression("^[a-zA-ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$")]
        [MaxLength(100)]
        public String Reclamante { get; set; }
        
        public bool Aprovado { get; set; }

        public bool Ativo { get; set; }

        public int? UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}

