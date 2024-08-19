using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNation.Desafio.Domain.Response
{
    public class ChartResponse
    {
        public List<string> Labels { get; set; }
        public List<decimal> Data {  get; set; }
    }
}
