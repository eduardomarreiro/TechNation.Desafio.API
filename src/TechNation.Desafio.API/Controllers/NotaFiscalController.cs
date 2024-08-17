﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechNation.Desafio.Application.DTOs;
using TechNation.Desafio.Application.Interfaces;

namespace TechNation.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalApplicationService _notaFiscalApplicationService;

        public NotaFiscalController(INotaFiscalApplicationService notaFiscalApplicationService)
        {
            _notaFiscalApplicationService = notaFiscalApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaFiscalDto>>> GetAll()
        {
            var notasFiscais = await _notaFiscalApplicationService.GetAll();
            return Ok(notasFiscais);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotaFiscalDto>> GetById(int id)
        {
            var notaFiscal = await _notaFiscalApplicationService.GetById(id);
            if (notaFiscal is null)
            {
                return NotFound();
            }
            return Ok(notaFiscal);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NotaFiscalDto NotaFiscalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _notaFiscalApplicationService.Add(NotaFiscalDto);
            return CreatedAtAction(nameof(GetById), new { id = NotaFiscalDto.Id }, NotaFiscalDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody][FromRoute] NotaFiscalDto NotaFiscalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notaFiscal = await _notaFiscalApplicationService.GetById(id);
            if (notaFiscal is null)
            {
                return NotFound();
            }

            NotaFiscalDto.Id = id;

            await _notaFiscalApplicationService.Update(NotaFiscalDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var notaFiscal = await _notaFiscalApplicationService.GetById(id);
            if (notaFiscal is null)
            {
                return NotFound();
            }

            await _notaFiscalApplicationService.Delete(id);
            return NoContent();
        }
    }
}