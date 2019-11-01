using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SGQ.Compliance.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.Compliance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ComplianceController
                : ControllerBase
    {
        private readonly IOptions<ConfiguracoesDeServicosExternos> config;

        public ComplianceController(IOptions<ConfiguracoesDeServicosExternos> config)
        {
            this.config = config;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] String filtro)
        {
            return Ok(await new ServicoDeObtencaoDeNormasEDadosDeConsultoria(config.Value).Obter(filtro));
        }
    }
}
