using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Filters;
using TechNation.Desafio.Domain.Response;

namespace TechNation.Desafio.Domain.Interfaces.Services
{
    public interface INotaFiscalService : IServiceBase<NotaFiscal>
    {
        Task<List<CardNotaFiscalResponse>> GetQtdNotasPorCategoria(CardsNotaFiscalFilter model);
    }
}
