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
    public class ApplicationServiceBase<TEntity, TEntityDto> : IApplicationServiceBase<TEntityDto> 
        where TEntity : Base 
        where TEntityDto : BaseDto
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IMapper _mapper;

        public ApplicationServiceBase(IRepositoryBase<TEntity> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }
        public async Task<TEntityDto> Add(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            await _repositoryBase.Add(entity);
            entityDto = _mapper.Map<TEntityDto>(entity);
            return entityDto;
        }

        public async Task Delete(int id)
        {
            await _repositoryBase.Delete(id);
        }

        public async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var entities = await _repositoryBase.GetAll();
            return _mapper.Map<IEnumerable<TEntityDto>>(entities);
        }

        public async Task<TEntityDto> GetById(int id)
        {
            var entity = await _repositoryBase.GetById(id);
            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task Update(TEntityDto entityDto)
        {
            var entity = await _repositoryBase.GetById(entityDto.Id);
            _mapper.Map(entityDto, entity);
            await _repositoryBase.Update(entity);
        }
    }
}
