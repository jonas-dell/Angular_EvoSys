using DepartamentosAPI.Models;
using EvoSystems.Domain.Commands;
using EvoSystems.Domain.Repositories;
using MediatR;


namespace EvoSystems.Domain.CommandHandlers
{
    public class CreateFuncionarioCommandHandler : IRequestHandler<CreateFuncionarioCommand, string>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public CreateFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<string> Handle(CreateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = new Funcionario()
            {
                Nome = request.CreateFuncionarioDTO.Nome,
                RG = request.CreateFuncionarioDTO.RG,
                Foto = request.CreateFuncionarioDTO.Foto,
                DepartamentoId = request.CreateFuncionarioDTO.DepartamentoId
            };

            await _funcionarioRepository.CreateFuncionario(funcionario);

            return "";
        }
    }
}
