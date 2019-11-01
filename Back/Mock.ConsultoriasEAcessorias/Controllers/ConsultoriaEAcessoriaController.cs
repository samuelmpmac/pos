using Microsoft.AspNetCore.Mvc;
using Mock.ConsultoriasEAcessorias.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock.ConsultoriasEAcessorias.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConsultoriaEAcessoriaController
        : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodos([FromQuery] String filtro)
        {
            var resultados = new RepositorioDeControlesDeGovernanca().ObterTodos(filtro);
            return Ok(resultados);
        }

        [HttpGet]
        [Route("{identificador}")]
        public IActionResult Obter(Int32 identificador)
        {
            var resultados = new RepositorioDeControlesDeGovernanca().ObterPeloIdentificador(identificador);
            return Ok(resultados);
        }
    }
}
