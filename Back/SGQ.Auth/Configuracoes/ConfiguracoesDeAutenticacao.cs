using System;
using System.Collections.Generic;
using System.Text;
//teste
namespace SGQ.Auth.Configuracoes
{    public class ConfiguracoesDeAutenticacao
    {
        public String Secret { get; set; }
        public Int32 ExpiracaoHoras { get; set; }
        public String Emissor { get; set; }
        public String ValidoEm { get; set; }
    }
}
