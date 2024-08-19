using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Filters;
using TechNation.Desafio.Domain.Interfaces.Repositories;
using TechNation.Desafio.Domain.Interfaces.Services;
using TechNation.Desafio.Domain.Response;

namespace TechNation.Desafio.Domain.Services
{
    public class NotaFiscalService : ServiceBase<NotaFiscal>, INotaFiscalService
    {
        protected readonly INotaFiscalRepository _notaFiscalRepository;
        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository) : base(notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }
        public async Task<List<CardNotaFiscalResponse>> GetQtdNotasPorCategoria(DashboardNotaFiscalFilter model)
        {
            return await _notaFiscalRepository.GetQtdNotasPorCategoria(model);
        }

        public async Task<ChartResponse> GetInadimplenciaMensal(DashboardNotaFiscalFilter model)
        {
            return await _notaFiscalRepository.GetInadimplenciaMensal(model);
        }

        public async Task<ChartResponse> GetReceitaMensal(DashboardNotaFiscalFilter model)
        {
            return await _notaFiscalRepository.GetReceitaMensal(model);
        }
    }
}
