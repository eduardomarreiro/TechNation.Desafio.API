using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Application.DTOs;
using TechNation.Desafio.Application.Interfaces;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Interfaces.Repositories;

namespace TechNation.Desafio.Application.Services
{
    public class StatusNotaFiscalApplicationService : ApplicationServiceBase<StatusNotaFiscal, StatusNotaFiscalDto>, IStatusNotaFiscalApplicationService
    {
        public StatusNotaFiscalApplicationService(IRepositoryBase<StatusNotaFiscal> repositoryBase, IMapper mapper) 
            : base(repositoryBase, mapper)
        {
        }


    }
}
