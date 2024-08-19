using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Entities;

namespace TechNation.Desafio.Infra.Mappings
{
    public class StatusNotaFiscalMapping : IEntityTypeConfiguration<StatusNotaFiscal>
    {
        public void Configure(EntityTypeBuilder<StatusNotaFiscal> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
