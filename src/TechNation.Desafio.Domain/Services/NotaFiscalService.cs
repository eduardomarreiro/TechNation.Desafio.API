using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Interfaces.Repositories;
using TechNation.Desafio.Domain.Interfaces.Services;

namespace TechNation.Desafio.Domain.Services
{
    public class NotaFiscalService : ServiceBase<NotaFiscal>, INotaFiscalService
    {
        public NotaFiscalService(IRepositoryBase<NotaFiscal> rep) : base(rep)
        {
        }
    }
}
