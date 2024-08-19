using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Application.DTOs;
using TechNation.Desafio.Application.Interfaces;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Filters;
using TechNation.Desafio.Domain.Interfaces.Repositories;
using TechNation.Desafio.Domain.Response;

namespace TechNation.Desafio.Application.Services
{
    public class NotaFiscalApplicationService : ApplicationServiceBase<NotaFiscal, NotaFiscalDto>, INotaFiscalApplicationService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IMapper _mapper;
        public NotaFiscalApplicationService(INotaFiscalRepository notaFiscalRepository, IMapper mapper)
            : base(notaFiscalRepository, mapper)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _mapper = mapper;
        }

        public async Task<List<CardNotaFiscalResponse>> GetQtdNotasPorCategoria(DashboardNotaFiscalDto cardsNotaFiscalDto)
        {
            var cardsNotaFiscalFilter = _mapper.Map<DashboardNotaFiscalFilter>(cardsNotaFiscalDto);
            var cardNotaFiscalResponses = await _notaFiscalRepository.GetQtdNotasPorCategoria(cardsNotaFiscalFilter);
            
            return _mapper.Map<List<CardNotaFiscalResponse>>(cardNotaFiscalResponses);
        }

        public async Task<ChartResponse> GetInadimplenciaMensal(DashboardNotaFiscalDto dashboardNotaFiscalDto)
        {
            var dashboardNotaFiscalFilter = _mapper.Map<DashboardNotaFiscalFilter>(dashboardNotaFiscalDto);
            var chartResponse = await _notaFiscalRepository.GetInadimplenciaMensal(dashboardNotaFiscalFilter);

            return _mapper.Map<ChartResponse>(chartResponse);
        }

        public async Task<ChartResponse> GetReceitaMensal(DashboardNotaFiscalDto dashboardNotaFiscalDto)
        {
            var dashboardNotaFiscalFilter = _mapper.Map<DashboardNotaFiscalFilter>(dashboardNotaFiscalDto);
            var chartResponse = await _notaFiscalRepository.GetReceitaMensal(dashboardNotaFiscalFilter);

            return _mapper.Map<ChartResponse>(chartResponse);
        }

        public async Task<List<NotaFiscal>> GetInfoTableDashboard(DashboardNotaFiscalDto dashboardNotaFiscalDto)
        {
            var dashboardNotaFiscalFilter = _mapper.Map<DashboardNotaFiscalFilter>(dashboardNotaFiscalDto);
            var tableResponse = await _notaFiscalRepository.GetInfoTableDashboard(dashboardNotaFiscalFilter);

            return _mapper.Map<List<NotaFiscal>>(tableResponse);
        }

    }

}
