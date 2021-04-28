using System;
using System.Collections.Generic;
using System.Text;

namespace bomtrato.backend.models.entities
{
    public class ProcessoEntity
    {
        public int ID { get; set; }

        public long NumeroProcesso { get; set; }

        public double Valor { get; set; }

        public String Escritorio { get; set; }

        public String Reclamante { get; set; }

        public bool Aprovado { get; set; }
    }
}
