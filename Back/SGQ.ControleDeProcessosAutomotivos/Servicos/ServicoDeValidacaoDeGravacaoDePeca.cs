using SGQ.ControleDeProcessosAutomotivos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeProcessosAutomotivos.Servicos
{
    public static class ServicoDeValidacaoDeGravacaoDePeca
    {
        public static List<String> Validar(Peca peca)
        {
            var mensagens = new List<String>();

            if(String.IsNullOrWhiteSpace(peca.Nome))
            {
                mensagens.Add("É obrigatório fornecer o nome da peça");
            }
            
            if (String.IsNullOrWhiteSpace(peca.Descricao))
            {
                mensagens.Add("É obrigatório fornecer a descrição da peça");
            }

            if (peca.NormasEControlesRelacionados == null || peca.NormasEControlesRelacionados.Count() == 0)
            {
                mensagens.Add("É obrigatório relacionar ao menos uma norma ou controle à peça");
            }

            return mensagens;
        }
    }
}
