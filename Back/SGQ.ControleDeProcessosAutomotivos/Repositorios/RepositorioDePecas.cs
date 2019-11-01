using Microsoft.EntityFrameworkCore;
using SGQ.ControleDeProcessosAutomotivos.Entidades;
using SGQ.ControleDeProcessosAutomotivos.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeProcessosAutomotivos.Repositorios
{
    public class RepositorioDePecas : IRepositorioDePecas
    {
        private PecaContext dbContext;

        public void ConfigurarDbContext(PecaContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Excluir(Peca pecaExistente)
        {
            dbContext.Pecas.Remove(pecaExistente);
            dbContext.SaveChanges();
        }

        public Peca Gravar(Peca peca)
        {
            dbContext.Pecas.Add(peca);
            dbContext.SaveChanges();

            return peca;
        }

        public void Atualizar(Peca pecaExistente, Peca pecaNova)
        {
            pecaExistente.Nome = pecaNova.Nome;
            pecaExistente.Descricao = pecaNova.Descricao;

            foreach (var norma in pecaExistente.NormasEControlesRelacionados)
            {
                if (!pecaNova.NormasEControlesRelacionados.Any(n => n.IdentificadorDaNormaOuControle == norma.IdentificadorDaNormaOuControle))
                {
                    dbContext.Entry(norma).State = EntityState.Deleted;
                }
            }

            foreach (var norma in pecaNova.NormasEControlesRelacionados)
            {
                if (!pecaExistente.NormasEControlesRelacionados.Any(n => n.IdentificadorDaNormaOuControle == norma.IdentificadorDaNormaOuControle))
                {
                    pecaExistente.NormasEControlesRelacionados.Add(new NormasEControlesRelacionados()
                    {
                        IdentificadorDaNormaOuControle = norma.IdentificadorDaNormaOuControle
                    });
                }
            }

            dbContext.SaveChanges();
        }

        public Peca ObterPeloIdentificador(int identificador)
        {
            return dbContext.Pecas.Include(p => p.NormasEControlesRelacionados).FirstOrDefault(p => p.Id == identificador);
        }

        public IEnumerable<Peca> ObterTodos(string filtro)
        {
            return dbContext.Pecas.Where(
                 p =>
                 String.IsNullOrWhiteSpace(filtro) ||
                 p.Id.ToString().Contains(filtro) ||
                 p.Nome.ToLower().Contains(filtro) ||
                 p.Descricao.ToLower().Contains(filtro)
                 );
        }
    }
}
