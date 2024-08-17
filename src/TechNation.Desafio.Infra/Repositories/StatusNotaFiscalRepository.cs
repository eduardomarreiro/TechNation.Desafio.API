using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Interfaces.Repositories;
using TechNation.Desafio.Infra.Context;

namespace TechNation.Desafio.Infra.Repositories
{
    public class StatusNotaFiscalRepository : RepositoryBase<StatusNotaFiscal>, IStatusNotaFiscalRepository
    {
        public StatusNotaFiscalRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
