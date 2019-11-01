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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SGQ.Auth.Configuracoes;
using SGQ.ControleDeAcesso.Entidades;
using SGQ.ControleDeAcesso.Servicos;

namespace SGQ.ControleDeAcesso.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ConfiguracoesDeAutenticacao configuracoesDeAutenticacao;

        public AuthController(SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager,
                      IOptions<ConfiguracoesDeAutenticacao> appSettings)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            configuracoesDeAutenticacao = appSettings.Value;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(Usuario usuario)
        {
            var mensagensDeErro = ServicoDeValidacaoDeLogin.Validar(usuario);
            if (mensagensDeErro.Any())
            {
                return BadRequest(mensagensDeErro);
            }

            var result = await signInManager.PasswordSignInAsync(usuario.Email, usuario.Senha, false, true);

            if (result.Succeeded)
            {
                return Ok(new { token = await JwtService.GerarJwt(usuario.Email, userManager, configuracoesDeAutenticacao) });
            }

            return BadRequest(new ModelErrorCollection { "Usuário ou senha inválidos" });
        }
    }
}
