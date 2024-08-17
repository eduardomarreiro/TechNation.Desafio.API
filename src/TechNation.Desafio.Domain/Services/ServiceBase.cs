using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNation.Desafio.Domain.Interfaces.Repositories;
using TechNation.Desafio.Domain.Interfaces.Services;

namespace TechNation.Desafio.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _rep;

        public ServiceBase(IRepositoryBase<TEntity> rep)
        {
            _rep = rep;
        }

        public async Task Add(TEntity entity)
        {
            await _rep.Add(entity);
        }

        public async Task Delete(int id)
        {
            await _rep.Delete(id);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return _rep.GetAll();
        }

        public Task<TEntity> GetById(int id)
        {
            return _rep.GetById(id);
        }

        public async Task Update(TEntity entity)
        {
            await _rep.Update(entity);
        }
    }
}
