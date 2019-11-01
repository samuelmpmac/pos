using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Compliance.Entidades
{
    public class Norma
    {
        public Int32 Identificador { get; set; }

        public String Nome { get; set; }

        public String Grupo { get; set; }

        public String Descricao { get; set; }

        public List<ProcedimentoDeNorma> Procedimentos { get; set; }

    }
}
