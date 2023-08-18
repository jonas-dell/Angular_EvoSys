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
    [Route("api/[controller]/[action]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IMediator _mediator; 
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IMediator mediator)
        {
            _funcionarioRepository = funcionarioRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetFuncionarioAsync()
        {
            var result = await _funcionarioRepository.GetFuncionarios();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionarioPeloDepartamentoIdAsync(int departamentoId)
        {
            var result = await _funcionarioRepository.GetFuncionariosPeloDepartamentoId(departamentoId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFuncionario(
            [FromBody] CreateFuncionarioDTO createfuncionarioDTO)
        {
            var command = new CreateFuncionarioCommand
            {
                CreateFuncionarioDTO = createfuncionarioDTO
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFuncionario([FromBody] Funcionario funcionario)
        {
            await _funcionarioRepository.UpdateFuncionario(funcionario);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFuncionario([FromQuery] int id)
        {

            var result = await _funcionarioRepository.DeletarFuncionario(id);

            return Ok(result);
        }
        
    }

}