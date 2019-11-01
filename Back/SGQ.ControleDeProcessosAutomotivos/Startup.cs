using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGQ.Auth.Servicos;
using SGQ.ControleDeProcessosAutomotivos.DatabaseContext;
using SGQ.ControleDeProcessosAutomotivos.Repositorios;

namespace SGQ.ControleDeProcessosAutomotivos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Add(new ServiceDescriptor(typeof(IRepositorioDePecas), new RepositorioDePecas()));
            services.AddDbContext<PecaContext>(opt => opt.UseInMemoryDatabase("PROCESSOS"));

            ServicoDeConfiguracaoDeAutenticacao.ConfigurarServicos(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            ServicoDeConfiguracaoDeAutenticacao.ConfigurarPipeline(app, env);

            app.UseMvc();
        }
    }
}
