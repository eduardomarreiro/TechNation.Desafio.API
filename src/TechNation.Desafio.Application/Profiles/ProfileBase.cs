using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Application.DTOs;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Filters;

namespace TechNation.Desafio.Application.Mappings
{
    public class ProfileBase : Profile
    {
        public ProfileBase()
        {
            CreateMap<StatusNotaFiscal, StatusNotaFiscalDto>();
            CreateMap<StatusNotaFiscalDto, StatusNotaFiscal>();
            CreateMap<NotaFiscal, NotaFiscalDto>()
                .ForMember(dest => dest.StatusNotaFiscal, opt => opt.MapFrom(src => src.StatusNotaFiscal.Nome))
                .ForMember(dest => dest.DataEmissao, opt => opt.MapFrom(src => src.DataEmissao.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.DataCobranca, opt => opt.MapFrom(src => src.DataCobranca.Value.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.DataPagamento, opt => opt.MapFrom(src => src.DataPagamento.Value.ToString("yyyy-MM-dd")));
            CreateMap<NotaFiscalDto, NotaFiscal>()
            .ForMember(dest => dest.StatusNotaFiscal, opt => opt.Ignore()); // Ignora o StatusNotaFiscal pois é um mapeamento apenas para o nome;
            CreateMap<DashboardNotaFiscalDto, DashboardNotaFiscalFilter>();
            CreateMap<DashboardNotaFiscalFilter, DashboardNotaFiscalDto>();
        }
    }
}
