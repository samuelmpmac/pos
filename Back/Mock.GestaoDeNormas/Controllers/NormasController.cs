using Microsoft.AspNetCore.Mvc;
using Mock.GestaoDeNormas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Mock.GestaoDeNormas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NormasController
        : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodos([FromQuery] String filtro)
        {
            var resultados = new RepositorioDeNormas().ObterTodos(filtro);
            return Ok(resultados);
        }

        [HttpGet]
        [Route("{identificador}")]
        public IActionResult Obter(Int32 identificador)
        {
            var resultados = new RepositorioDeNormas().ObterPeloIdentificador(identificador);
            return Ok(resultados);
        }
    }
}
