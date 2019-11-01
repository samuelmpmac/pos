using Microsoft.EntityFrameworkCore;
using SGQ.ControleDeProcessosAutomotivos.Entidades;
using SGQ.ControleDeProcessosAutomotivos.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeProcessosAutomotivos.Repositorios
{
    public interface IRepositorioDePecas
    {
        void ConfigurarDbContext(PecaContext dbContext);
        IEnumerable<Peca> ObterTodos(String filtro);
        Peca ObterPeloIdentificador(Int32 identificador);
        Peca Gravar(Peca peca);
        void Atualizar(Peca pecaExistente, Peca pecaNova);
        void Excluir(Peca peca);
    }
}
