using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeAcesso.Entidades
{
    public class Usuario
    {
        public String Id { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String NovaSenha { get; set; }
        public String Nome{ get; set; }
        public String[] Perfis { get; set; }
        public String PerfisTexto
        {
            get { return Perfis == null ? String.Empty : String.Join(',', Perfis) ; }
        }
    }
}
