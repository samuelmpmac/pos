using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock.ConsultoriasEAcessorias.Entidades
{
    public class ControleDeGovernanca
    {
        public Int32 Identificador { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public List<Procedimento> Procedimentos { get; set; }
    }
}
