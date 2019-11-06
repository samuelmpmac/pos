using Microsoft.AspNetCore.Mvc.ModelBinding;
using SGQ.ControleDeAcesso.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeAcesso.Servicos
{
    public class ServicoDeValidacaoDeGravacaoDeUsuario
    {
        public static ModelErrorCollection Validar(Usuario usuario, Boolean validarSenha = true)
        {
            var mensagens = new ModelErrorCollection();

            if (String.IsNullOrWhiteSpace(usuario.Email))
            {
                mensagens.Add("É obrigatório fornecer o e-mail do usuário");
            }

            if (validarSenha && String.IsNullOrWhiteSpace(usuario.Senha))
            {
                mensagens.Add("É obrigatório fornecer a senha do usuário");
            }


            if (validarSenha && !String.IsNullOrWhiteSpace(usuario.Senha) && usuario.Senha.Length < 6)
            {
                mensagens.Add("A senha deve ter no mínimo 6 caracteres");
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
