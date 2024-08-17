using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechNation.Desafio.Application.DTOs;
using TechNation.Desafio.Application.Interfaces;

namespace TechNation.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusNotaFiscalController : ControllerBase
    {
        private readonly IStatusNotaFiscalApplicationService _statusNotaFiscalApplicationService;
        public StatusNotaFiscalController(IStatusNotaFiscalApplicationService statusNotaFiscalApplicationService)
        {
            _statusNotaFiscalApplicationService = statusNotaFiscalApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusNotaFiscalDto>>> GetAll()
        {
            var statusNF = await _statusNotaFiscalApplicationService.GetAll();
            return Ok(statusNF);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StatusNotaFiscalDto>> GetById(int id)
        {
            var statusNF = await _statusNotaFiscalApplicationService.GetById(id);
            if (statusNF is null)
            {
                return NotFound();
            }
            return Ok(statusNF);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] StatusNotaFiscalDto StatusNotaFiscalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _statusNotaFiscalApplicationService.Add(StatusNotaFiscalDto);
            return CreatedAtAction(nameof(GetById), new { id = StatusNotaFiscalDto.Id }, StatusNotaFiscalDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody][FromRoute] StatusNotaFiscalDto StatusNotaFiscalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statusNF = await _statusNotaFiscalApplicationService.GetById(id);
            if (statusNF is null)
            {
                return NotFound();
            }

            StatusNotaFiscalDto.Id = id;

            await _statusNotaFiscalApplicationService.Update(StatusNotaFiscalDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var statusNF = await _statusNotaFiscalApplicationService.GetById(id);
            if (statusNF is null)
            {
                return NotFound();
            }

            await _statusNotaFiscalApplicationService.Delete(id);
            return NoContent();
        }
    }
}
