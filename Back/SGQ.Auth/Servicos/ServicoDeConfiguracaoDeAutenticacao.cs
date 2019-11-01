using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SGQ.Auth.Configuracoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGQ.Auth.Servicos
{
    public class ServicoDeConfiguracaoDeAutenticacao
    {
        public static void ConfigurarServicos(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("ConfiguracoesDeAutenticacao");
            services.Configure<ConfiguracoesDeAutenticacao>(appSettingsSection);

            var appSettings = appSettingsSection.Get<ConfiguracoesDeAutenticacao>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });
        }

        public static void ConfigurarPipeline(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
        }
    }
}
