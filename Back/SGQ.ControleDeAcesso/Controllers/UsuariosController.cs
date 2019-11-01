using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SGQ.Auth.Configuracoes;
using SGQ.ControleDeAcesso.Entidades;
using SGQ.ControleDeAcesso.Servicos;
using SGQ.Auth.Autorizacoes;
using SGQ.Auth.Constantes;

namespace SGQ.ControleDeAcesso.Controllers
{
   // [Authorize]
    //[AutorizacaoPorPerfil(PerfilDeUsuario.AdministradorDoSistema)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ConfiguracoesDeAutenticacao configuracoesDeAutenticacao;

        public UsuariosController(SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager,
                      IOptions<ConfiguracoesDeAutenticacao> appSettings)
        {
            this.userManager = userManager;
            configuracoesDeAutenticacao = appSettings.Value;
        }

        [HttpGet]                
        public async Task<ActionResult> teste()
        {
            return Ok(
                new List<object>
                {
                  new  { Codigo = 1, Descricao = "aaaaaa" },
                  new  { Codigo = 2, Descricao = "bbbb" },
                }
                );
        }

        [HttpGet("{email}")]
        public async Task<ActionResult> Obter(String email)
        {
            return Ok(await userManager.FindByEmailAsync(email));
        }

        
        [HttpPost]        
        public async Task<ActionResult> Registrar(Usuario usuario)
        {
            var mensagensDeErro = ServicoDeValidacaoDeGravacaoDeUsuario.Validar(usuario);
            if (mensagensDeErro.Any())
            {
                return BadRequest(mensagensDeErro);
            }

            var identityUser = new IdentityUser
            {
                UserName = usuario.Email,
                Email = usuario.Email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(identityUser, usuario.Senha);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var claims = new List<Claim>
            {
                new Claim("Nome", usuario.Nome),
                new Claim("Email", usuario.Email),
                new Claim("Perfis", usuario.PerfisTexto)
            };

            await userManager.AddClaimsAsync(identityUser, claims);

            return CreatedAtAction(nameof(Obter), new { email = identityUser.Email }, userManager.FindByEmailAsync(identityUser.Email));
        }


        [HttpPut("{identificador}")]
        public async Task<IActionResult> Atualizar(String identificador, Usuario usuario)
        {
            if (identificador != usuario.Id)
            {
                return BadRequest();
            }

            var mensagensDeErro = ServicoDeValidacaoDeGravacaoDeUsuario.Validar(usuario);
            if (mensagensDeErro.Any())
            {
                return BadRequest(mensagensDeErro);
            }

            var usuarioExistente = await userManager.FindByIdAsync(usuario.Id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }


            usuarioExistente.UserName = usuario.Email;
            usuarioExistente.Email = usuario.Email;
       

            var claims = new List<Claim>
            {
                new Claim("Nome", usuario.Nome),
                new Claim("Email", usuario.Email),
                new Claim("Perfis", usuario.PerfisTexto)
            };

            await userManager.UpdateAsync(usuarioExistente);
            await userManager.RemoveClaimsAsync(usuarioExistente, await userManager.GetClaimsAsync(usuarioExistente));
            await userManager.AddClaimsAsync(usuarioExistente, claims);

            //falta senha

            return NoContent();
        }
    }
}
