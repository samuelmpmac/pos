using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SGQ.Auth.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SGQ.Auth.Autorizacoes
{
    public class AutorizacaoPorClaimsDoUsuario
    {
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Split(',').Contains(claimValue));
        }

    }

    public class AutorizacaoPorPerfilAttribute : TypeFilterAttribute
    {
        public AutorizacaoPorPerfilAttribute(PerfilDeUsuario claimValue) : base(typeof(ValidacaoDaAutorizacaoPorClaimsFilter))
        {
            Arguments = new object[] { new Claim("Perfis", claimValue.ToString()) };
        }
    }

    public class ValidacaoDaAutorizacaoPorClaimsFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public ValidacaoDaAutorizacaoPorClaimsFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            if (!AutorizacaoPorClaimsDoUsuario.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
