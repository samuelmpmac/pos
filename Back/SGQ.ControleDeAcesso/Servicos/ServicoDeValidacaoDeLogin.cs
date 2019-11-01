using Microsoft.AspNetCore.Mvc.ModelBinding;
using SGQ.ControleDeAcesso.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeAcesso.Servicos
{
    public class ServicoDeValidacaoDeLogin
    {
        public static ModelErrorCollection Validar(Usuario usuario)
        {
            var mensagens = new ModelErrorCollection();

            if (String.IsNullOrWhiteSpace(usuario.Email))
            {
                mensagens.Add("E-mail não informado");
            }

            if (String.IsNullOrWhiteSpace(usuario.Senha))
            {
                mensagens.Add("Senha não informada");
            }

            return mensagens;
        }
    }
}
