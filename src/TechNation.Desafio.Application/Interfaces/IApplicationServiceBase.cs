using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNation.Desafio.Application.Interfaces
{
    public interface IApplicationServiceBase<TEntityDto>
    {
        Task<TEntityDto> GetById(int id);
        Task<IEnumerable<TEntityDto>> GetAll();
        Task<TEntityDto> Add(TEntityDto entity);
        Task Update(TEntityDto entity);
        Task Delete(int id);
    }
}
