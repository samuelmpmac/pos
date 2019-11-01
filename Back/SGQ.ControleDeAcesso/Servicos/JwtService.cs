using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SGQ.Auth.Configuracoes;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SGQ.ControleDeAcesso.Servicos
{
    public class JwtService
    {        
        public static async Task<String> GerarJwt(String email, UserManager<IdentityUser> userManager, ConfiguracoesDeAutenticacao configuracoesDeAutenticacao)
        {
            var user = await userManager.FindByEmailAsync(email);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(await userManager.GetClaimsAsync(user));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuracoesDeAutenticacao.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = configuracoesDeAutenticacao.Emissor,
                Audience = configuracoesDeAutenticacao.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(configuracoesDeAutenticacao.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
