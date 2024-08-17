using Microsoft.EntityFrameworkCore;
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
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Base
    {
        protected readonly SqlContext _sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task Add(TEntity entity)
        {
            try
            {
                await _sqlContext.Set<TEntity>().AddAsync(entity);
                await _sqlContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao adicionar a entidade.", ex);
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                if (entity is null)
                {
                    throw new KeyNotFoundException("Entidade não encontrada.");
                }

                _sqlContext.Set<TEntity>().Remove(entity);
                await _sqlContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao deletar a entidade.", ex);
            }

        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {

            return await _sqlContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _sqlContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                _sqlContext.Entry(entity).State = EntityState.Modified;
                await _sqlContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao atualizar a entidade.", ex);
            }
        }
    }
}
