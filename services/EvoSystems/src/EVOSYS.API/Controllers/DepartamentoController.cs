using DepartamentosAPI.Data;
using DepartamentosAPI.Models;
using EvoSystems.Domain.Commands;
using EvoSystems.Domain.DTO;
using EvoSystems.Domain.Repositories;
using EvoSystems.Infra.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDepartamentoRepository _departamentoRepository;
        
        public DepartamentoController(IDepartamentoRepository departamentoRepository,IMediator mediator)
        {
            _departamentoRepository = departamentoRepository;
            _mediator = mediator;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var result = await _departamentoRepository.GetDepartementos();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartamento(
            [FromBody] CreateDepartamentoDTO createDepartamentoDTO)
        {   
           
            var command = new CreateDepartamentoCommand
            {
                CreateDepartamentoDTO = createDepartamentoDTO
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartamento(
            [FromBody] UpdateDepartamentoDTO updateDepartamentoDTO)
        {
            var command = new UpdateDepartamentoCommand
            {
                UpdateDepartamentoDTO = updateDepartamentoDTO
            };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartamento([FromQuery] int id)
        {
            var result = await _departamentoRepository.DeletarDepartamento(id);

            return Ok(result);
        }
    }
}