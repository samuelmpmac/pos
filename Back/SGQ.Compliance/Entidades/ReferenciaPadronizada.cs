using SGQ.Compliance.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Compliance.Entidades
{
    public class ReferenciaPadronizada
    {
        public Int32 Identificador { get; set; }

        public TipoDeReferencia Tipo { get; set; }

        public String Grupo { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public List<ProcedimentoPadronizado> Procedimentos { get; set; } = new List<ProcedimentoPadronizado>();
    }
}
