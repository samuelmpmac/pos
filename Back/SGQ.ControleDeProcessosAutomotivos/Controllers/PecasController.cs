using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SGQ.ControleDeProcessosAutomotivos.Entidades;
using SGQ.ControleDeProcessosAutomotivos.DatabaseContext;
using SGQ.ControleDeProcessosAutomotivos.Repositorios;
using SGQ.ControleDeProcessosAutomotivos.Servicos;

namespace SGQ.ControleDeProcessosAutomotivos.Controllers
{
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PecasController
        : ControllerBase
    {
        private IRepositorioDePecas repositorio;

        public PecasController(IRepositorioDePecas repositorio, PecaContext dbContext)
        {
            this.repositorio = repositorio;
            this.repositorio.ConfigurarDbContext(dbContext);
        }


        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] String filtro)
        {
            return Ok(repositorio.ObterTodos(filtro));
        }

        [HttpGet]
        [Route("{identificador}")]
        public async Task<IActionResult> Obter(Int32 identificador)
        {
            var peca = repositorio.ObterPeloIdentificador(identificador);
            if(peca == null)
            {
                return NotFound();
            }
            return Ok(peca);
        }

        [HttpPost]
        public async Task<IActionResult> Gravar(Peca peca)
        {
            var mensagensDeErro = ServicoDeValidacaoDeGravacaoDePeca.Validar(peca);
            if (mensagensDeErro.Any())
            {
                return BadRequest(mensagensDeErro);
            }

            var itemCriado = repositorio.Gravar(peca);            
            return CreatedAtAction(nameof(Obter), new { Identificador = itemCriado.Id }, itemCriado);
        }

        [HttpPut]
        [Route("{identificador}")]
        public async Task<IActionResult> Atualizar(Int32 identificador, Peca peca)
        {
            if (identificador != peca.Id)
            {
                return BadRequest();
            }

            var mensagensDeErro = ServicoDeValidacaoDeGravacaoDePeca.Validar(peca);
            if(mensagensDeErro.Any())
            {
                return BadRequest(mensagensDeErro);
            }

            var pecaExistente = repositorio.ObterPeloIdentificador(identificador);

            if (pecaExistente == null)
            {
                return NotFound();
            }

            repositorio.Atualizar(pecaExistente, peca);
            return NoContent();
        }

        [HttpDelete]
        [Route("{identificador}")]
        public async Task<IActionResult> Excluir(Int32 identificador)
        {
            var pecaExistente = repositorio.ObterPeloIdentificador(identificador);

            if (pecaExistente == null)
            {
                return NotFound();
            }

            repositorio.Excluir(pecaExistente);

            return NoContent();
        }
    }
}
