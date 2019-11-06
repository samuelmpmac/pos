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
        public async Task<ActionResult> Listar()
        {
            var usuariosRetorno = new List<Usuario>();
            var usuarios = userManager.Users;
            foreach (var usuario in usuarios)
            {
                var clains = userManager.GetClaimsAsync(usuario).Result;
                var usuarioRetorno = new Usuario();
                usuarioRetorno.Id = usuario.Id;
                usuarioRetorno.Email = clains.Single(c => c.Type == "Email").Value;
                usuarioRetorno.Nome = clains.Single(c => c.Type == "Nome").Value;
                var perfis = clains.Single(c => c.Type == "Perfis").Value.Split(',');
                var perfisDoUsuario = new List<String>();
                foreach (var perfil in perfis)
                {
                    perfisDoUsuario.Add(perfil);
                }
                usuarioRetorno.Perfis = perfisDoUsuario.ToArray();
                usuariosRetorno.Add(usuarioRetorno);
            }
            return Ok(usuariosRetorno);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Obter(String id)
        {
            var usuario = await userManager.FindByIdAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }

            var clains = userManager.GetClaimsAsync(usuario).Result;
            var usuarioRetorno = new Usuario();
            usuarioRetorno.Id = usuario.Id;
            usuarioRetorno.Email = clains.Single(c => c.Type == "Email").Value;
            usuarioRetorno.Nome = clains.Single(c => c.Type == "Nome").Value;
            var perfis = clains.Single(c => c.Type == "Perfis").Value.Split(',');
            var perfisDoUsuario = new List<String>();
            foreach (var perfil in perfis)
            {
                perfisDoUsuario.Add(perfil);
            }
            usuarioRetorno.Perfis = perfisDoUsuario.ToArray();

            return Ok(usuarioRetorno);
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

            return CreatedAtAction(nameof(Obter), new { Id = identityUser.Id }, userManager.FindByIdAsync(identityUser.Id));
        }


        [HttpPut("{identificador}")]
        public async Task<IActionResult> Atualizar(String identificador, Usuario usuario)
        {
            if (identificador != usuario.Id)
            {
                return BadRequest();
            }

            var mensagensDeErro = ServicoDeValidacaoDeGravacaoDeUsuario.Validar(usuario, false);
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

        [HttpDelete("{identificador}")]
        public async Task<IActionResult> Atualizar(String identificador)
        {
            var usuario = userManager.FindByIdAsync(identificador).Result;
            if(usuario == null)
            {
                return NotFound();
            }

            await userManager.DeleteAsync(usuario);

            return NoContent();
        }
    }
}
