using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Infra.Mappings;

namespace TechNation.Desafio.Infra.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<NotaFiscal> NotaFiscal {  get; set; }
        public DbSet<StatusNotaFiscal> StatusNotaFiscal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotaFiscalMapping());
            modelBuilder.ApplyConfiguration(new StatusNotaFiscalMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
