using DepartamentosAPI.Models;
using EvoSystems.Domain.Commands;
using EvoSystems.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.CommandHandlers
{
    public class UpdateFuncionarioCommandHandler : IRequestHandler<UpdateFuncionarioCommand, string>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public UpdateFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<string> Handle(UpdateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = new Funcionario()
            {
                Id = request.UpdateFuncionarioDTO.Id,
                Nome = request.UpdateFuncionarioDTO.Nome,
                RG = request.UpdateFuncionarioDTO.RG,
                Foto = request.UpdateFuncionarioDTO.Foto,
                DepartamentoId = request.UpdateFuncionarioDTO.DepartamentoId
            };

            await _funcionarioRepository.UpdateFuncionario(funcionario);

            return "";
        }
    }
}
