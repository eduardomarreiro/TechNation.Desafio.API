using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Application.DTOs;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Filters;
using TechNation.Desafio.Domain.Response;

namespace TechNation.Desafio.Application.Interfaces
{
    public interface INotaFiscalApplicationService : IApplicationServiceBase<NotaFiscalDto>
    {
        Task<List<CardNotaFiscalResponse>> GetQtdNotasPorCategoria(DashboardNotaFiscalDto cardsNotaFiscalDto);
        Task<ChartResponse> GetInadimplenciaMensal(DashboardNotaFiscalDto model);
        Task<ChartResponse> GetReceitaMensal(DashboardNotaFiscalDto model);
        Task<List<NotaFiscal>> GetInfoTableDashboard(DashboardNotaFiscalDto dashboardNotaFiscalDto);
    }
}
