using EvoSystems.Domain.Commands;
using EvoSystems.Domain.Repositories;
using MediatR;

namespace EvoSystems.Domain.CommandHandlers
{
    public class DeleteDepartamentoCommandHandler : IRequestHandler<DeleteDepartamentoCommand, string>
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public DeleteDepartamentoCommandHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<string> Handle(DeleteDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = await _departamentoRepository.DeletarDepartamento(request.Id);

            if (departamento == null)
            {
                return "Departamento não encontrado.";
            }

            await _departamentoRepository.DeletarDepartamento(departamento);

            return "Departamento excluído com sucesso.";
        }
    }
}
