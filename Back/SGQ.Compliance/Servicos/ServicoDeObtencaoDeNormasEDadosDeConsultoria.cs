using Newtonsoft.Json;
using SGQ.Compliance.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGQ.Compliance.Servicos
{
    public class ServicoDeObtencaoDeNormasEDadosDeConsultoria
    {
        private readonly ConfiguracoesDeServicosExternos configuracoes;

        public ServicoDeObtencaoDeNormasEDadosDeConsultoria(ConfiguracoesDeServicosExternos configuracoes)
        {
            this.configuracoes = configuracoes;
        }

        public async Task<IEnumerable<ReferenciaPadronizada>> Obter(String filtro)
        {
            var referencias = new List<ReferenciaPadronizada>();
            using (var httpClient = new HttpClient())
            {
                referencias.AddRange(await ObterNormas(httpClient, filtro));
                referencias.AddRange(await ObterConsultoria(httpClient, filtro));                
            }
            return referencias;
        }

        private async Task<IEnumerable<ReferenciaPadronizada>> ObterConsultoria(HttpClient httpClient, String filtro)
        {
            var referencias = new List<ReferenciaPadronizada>();
            var response = await httpClient.GetAsync(new Uri(String.Format(configuracoes.URLDoServicoDeConsultoria, filtro)));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudoDoRetorno = await response.Content.ReadAsStringAsync();
                var controles = JsonConvert.DeserializeObject<List<ControleDeGovernanca>>(conteudoDoRetorno);

                foreach (var controle in controles)
                {
                    var referencia = new ReferenciaPadronizada()
                    {
                        Identificador = controle.Identificador,
                        Tipo = Enumeradores.TipoDeReferencia.ControleDeGovernanca,
                        Grupo = " - ",
                        Nome = controle.Nome,
                        Descricao = controle.Descricao
                    };

                    controle.Procedimentos.ForEach(
                        p => referencia.Procedimentos.Add(
                            new ProcedimentoPadronizado()
                            {
                                Identificador = p.Identificador,
                                Descricao = p.Descricao
                            }
                        )
                    );


                    referencias.Add(referencia);
                }
            }

            return referencias;
        }

        private async Task<IEnumerable<ReferenciaPadronizada>> ObterNormas(HttpClient httpClient, String filtro)
        {
            var referencias = new List<ReferenciaPadronizada>();
            var response = await httpClient.GetAsync(new Uri(String.Format(configuracoes.URLDoServicoDeNormas, filtro)));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var conteudoDoRetorno = await response.Content.ReadAsStringAsync();
                var normas = JsonConvert.DeserializeObject<List<Norma>>(conteudoDoRetorno);

                foreach (var norma in normas)
                {
                    var referencia = new ReferenciaPadronizada()
                    {
                        Identificador = norma.Identificador,
                        Tipo = Enumeradores.TipoDeReferencia.Norma,
                        Grupo = norma.Grupo,
                        Nome = norma.Nome,
                        Descricao = norma.Descricao
                    };

                    norma.Procedimentos.ForEach(
                        p => referencia.Procedimentos.Add(
                            new ProcedimentoPadronizado()
                            {
                                Identificador = p.Identificador,
                                Descricao = p.Descricao
                            }
                        )
                    );


                    referencias.Add(referencia);
                }
            }

            return referencias;
        }

    }
}
