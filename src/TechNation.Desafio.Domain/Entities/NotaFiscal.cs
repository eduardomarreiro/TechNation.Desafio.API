﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNation.Desafio.Domain.Entities
{
    public class NotaFiscal : Base
    {
        public string NomePagador { get; set; }
        public string NumeroIdentificacao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataCobranca { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public string DocumentoNotaFiscal { get; set; }
        public string DocumentoBoletoBancario { get; set; }

        // Foreign key
        public int IdStatusNotaFiscal { get; set; }

        // Navigation property
        public StatusNotaFiscal StatusNotaFiscal { get; set; }
    }
}
