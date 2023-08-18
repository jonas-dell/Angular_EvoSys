using EvoSystems.Domain.Commands;
using EvoSystems.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EvoSystems.Domain.CommandHandlers
{
    public class DeleteFuncionarioCommandHandler : IRequestHandler<DeleteFuncionarioCommand, string>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public DeleteFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<string> Handle(DeleteFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = await _funcionarioRepository.DeletarFuncionario(request.Id);

            if (funcionario == null)
            {
                return "Funcionário não encontrado.";
            }

            await _funcionarioRepository.DeletarFuncionario(funcionario);

            return "Funcionário excluído com sucesso.";
        }
    }
}
