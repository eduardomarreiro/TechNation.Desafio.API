using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNation.Desafio.Domain.Filters
{
    public class CardsNotaFiscalFilter
    {
        public DateTime? DataEmissaoDe { get; set; }
        public DateTime? DataEmissaoAte { get; set; }
        public DateTime? DataCobrancaDe { get; set; }
        public DateTime? DataCobrancaAte { get; set; }
        public DateTime? DataPagamentoDe { get; set; }
        public DateTime? DataPagamentoAte { get; set; }
        public int? IdStatusNotaFiscal { get; set; }
    }
}
