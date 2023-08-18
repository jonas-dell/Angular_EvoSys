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
    public class UpdateDepartamentoCommandHandler : IRequestHandler<UpdateDepartamentoCommand, string>
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public UpdateDepartamentoCommandHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<string> Handle(UpdateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = new Departamento()
            {
                Id = request.UpdateDepartamentoDTO.Id,
                Nome = request.UpdateDepartamentoDTO.Nome,
                Sigla = request.UpdateDepartamentoDTO.Sigla,
            };

            await _departamentoRepository.UpdateDepartamento(departamento);

            return "";
        }
    }
}
