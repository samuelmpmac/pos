using SGQ.ControleDeAcesso.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeAcesso.Servicos
{
    public class ServicoDeValidacaoDeGravacaoDeUsuario
    {
        public static List<String> Validar(Usuario usuario, Boolean validarSenha = true)
        {
            var mensagens = new List<String>();

            if (String.IsNullOrWhiteSpace(usuario.Email))
            {
                mensagens.Add("É obrigatório fornecer o e-mail do usuário");
            }

            if (validarSenha && String.IsNullOrWhiteSpace(usuario.Senha))
            {
                mensagens.Add("É obrigatório fornecer a senha do usuário");
            }

            if (String.IsNullOrWhiteSpace(usuario.Nome))
            {
                mensagens.Add("É obrigatório fornecer o nome do usuário");
            }

            if(usuario.Perfis == null || usuario.Perfis.Count() == 0)
            {
                mensagens.Add("É obrigatório relacionar ao menos um perfil ao usuário");
            }

            return mensagens;
        }
    }
}
