using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Filters;
using TechNation.Desafio.Domain.Response;

namespace TechNation.Desafio.Domain.Interfaces.Repositories
{
    public interface INotaFiscalRepository : IRepositoryBase<NotaFiscal>
    {
        Task<List<CardNotaFiscalResponse>> GetQtdNotasPorCategoria(DashboardNotaFiscalFilter model);
        Task<ChartResponse> GetInadimplenciaMensal(DashboardNotaFiscalFilter model);
        Task<ChartResponse> GetReceitaMensal(DashboardNotaFiscalFilter model);
        Task<List<NotaFiscal>> GetInfoTableDashboard(DashboardNotaFiscalFilter model);
    }
}
