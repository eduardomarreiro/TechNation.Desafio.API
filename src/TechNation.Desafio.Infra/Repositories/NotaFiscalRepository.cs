using Microsoft.EntityFrameworkCore;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Enums;
using TechNation.Desafio.Domain.Filters;
using TechNation.Desafio.Domain.Interfaces.Repositories;
using TechNation.Desafio.Domain.Response;
using TechNation.Desafio.Infra.Context;

namespace TechNation.Desafio.Infra.Repositories
{
    public class NotaFiscalrepository : RepositoryBase<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalrepository(SqlContext sqlContext) : base(sqlContext)
        {
        }

        public async Task<List<CardNotaFiscalResponse>> GetQtdNotasPorCategoria(CardsNotaFiscalFilter model)
        {

            var query = _sqlContext.Set<NotaFiscal>().AsNoTracking().AsQueryable();

            query = ApplyDateFilters(query, model);
            

            var notas = await query.ToListAsync();

            var totalNotas = notas.Count;
            var notasEmitidas = notas.Count(n => n.IdStatusNotaFiscal == (int)EStatusNotaFiscal.Emitida);
            var notasSemCobranca = notas.Count(n => n.IdStatusNotaFiscal != (int)EStatusNotaFiscal.CobrancaRealizada);
            var notasVencidas = notas.Count(n => n.IdStatusNotaFiscal == (int)EStatusNotaFiscal.PagamentoEmAtraso);
            var notasAVencer = notas.Count(n => n.IdStatusNotaFiscal != (int)EStatusNotaFiscal.PagamentoEmAtraso && n.DataPagamento == null);
            var notasPagas = notas.Count(n => n.IdStatusNotaFiscal == (int)EStatusNotaFiscal.PagamentoRealizado);

            return new List<CardNotaFiscalResponse>
            {
                new CardNotaFiscalResponse { Categoria = "Total Notas", Quantidade = totalNotas },
                new CardNotaFiscalResponse { Categoria = "Emitida", Quantidade = notasEmitidas },
                new CardNotaFiscalResponse { Categoria = "Sem Cobranca", Quantidade = notasSemCobranca },
                new CardNotaFiscalResponse { Categoria = "Vencidas", Quantidade = notasVencidas },
                new CardNotaFiscalResponse { Categoria = "A Vencer", Quantidade = notasAVencer },
                new CardNotaFiscalResponse { Categoria = "Pagas", Quantidade = notasPagas }
            };

        }

        private IQueryable<NotaFiscal> ApplyDateFilters(IQueryable<NotaFiscal> query, CardsNotaFiscalFilter model)
        {
            if (model.DataEmissaoDe is not null)
                query = query.Where(n => n.DataEmissao >= model.DataEmissaoDe);

            if (model.DataEmissaoAte is not null)
                query = query.Where(n => n.DataEmissao <= model.DataEmissaoAte);

            if (model.DataCobrancaDe is not null)
                query = query.Where(n => n.DataCobranca >= model.DataCobrancaDe);

            if (model.DataCobrancaAte is not null)
                query = query.Where(n => n.DataCobranca <= model.DataCobrancaAte);

            if (model.DataPagamentoDe is not null)
                query = query.Where(n => n.DataPagamento >= model.DataPagamentoDe);

            if (model.DataPagamentoAte is not null)
                query = query.Where(n => n.DataPagamento <= model.DataPagamentoAte);

            return query;
        }
    }
}
