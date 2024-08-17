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
    public class NotaFiscalMapping : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.NomePagador)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(n => n.NumeroIdentificacao)
                .IsRequired()
                .HasMaxLength(6)
                .HasConversion(
                    v => v.PadLeft(6, '0'),
                    v => v
                )
                .HasAnnotation("RegularExpression", "^[0-9]{6}$");

            builder.Property(n => n.DataEmissao)
                .IsRequired();

            builder.Property(n => n.Valor)
                .IsRequired();

            builder.Property(n => n.DocumentoNotaFiscal)
                .IsRequired();

            builder.Property(n => n.DocumentoBoletoBancario)
                .IsRequired();

            builder.HasOne(n => n.StatusNotaFiscal)
                .WithMany(s => s.NotasFiscais)
                .HasForeignKey(n => n.IdStatusNotaFiscal);
        }
    }
}
