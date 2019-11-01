using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeProcessosAutomotivos.Entidades
{
    public class NormasEControlesRelacionados
    {
        public Int32 NormasEControlesRelacionadosId { get; set; }
        public Int32 PecaId { get; set; }

        public Int32 IdentificadorDaNormaOuControle { get; set; }
    }
}
