using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNation.Desafio.Domain.Entities
{
    public class StatusNotaFiscal : Base
    {
        public string Nome { get; set; }

        // Navigation property
        public ICollection<NotaFiscal> NotaFiscais { get; set; }
    }
}
