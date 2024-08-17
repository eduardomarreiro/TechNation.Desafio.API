using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNation.Desafio.Application.DTOs
{
    public class StatusNotaFiscalDto : BaseDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
