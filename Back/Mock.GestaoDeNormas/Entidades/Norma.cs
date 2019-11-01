using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock.GestaoDeNormas.Entidades
{
    public class Norma
    {
        public Int32 Identificador { get; set; }

        public String Nome { get; set; }

        public String Grupo { get; set; }

        public String Descricao { get; set; }

        public List<Procedimento> Procedimentos { get; set; }

    }
}
