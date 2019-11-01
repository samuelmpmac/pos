using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Compliance.Entidades
{
    public class ControleDeGovernanca
    {
        public Int32 Identificador { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public List<ProcedimentoDeControleDeGovernanca> Procedimentos { get; set; }
    }
}
