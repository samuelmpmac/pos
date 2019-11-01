using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeProcessosAutomotivos.Entidades
{
    public class Peca
    {
        [Key]
        public Int32 Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public virtual ICollection<NormasEControlesRelacionados> NormasEControlesRelacionados { get; set; }
    }
}
