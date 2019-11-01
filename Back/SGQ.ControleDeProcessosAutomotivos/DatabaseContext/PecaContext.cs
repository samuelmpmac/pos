using Microsoft.EntityFrameworkCore;
using SGQ.ControleDeProcessosAutomotivos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGQ.ControleDeProcessosAutomotivos.DatabaseContext
{
    public class PecaContext : DbContext
    {
        public PecaContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Peca> Pecas { get; set; }
    }
}
