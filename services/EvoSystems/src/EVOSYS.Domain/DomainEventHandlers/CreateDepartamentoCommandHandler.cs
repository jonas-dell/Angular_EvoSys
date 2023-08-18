using DepartamentosAPI.Models;
using EvoSystems.Domain.Commands;
using EvoSystems.Domain.DTO;
using EvoSystems.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.CommandHandlers
{
    public class CreateDepartamentoCommandHandler : IRequestHandler<CreateDepartamentoCommand, string>
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public CreateDepartamentoCommandHandler(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<string> Handle(CreateDepartamentoCommand request, CancellationToken cancellationToken)
        {
            var departamento = new Departamento()
            {
                Nome = request.CreateDepartamentoDTO.Nome,
                Sigla = request.CreateDepartamentoDTO.Sigla,
            };

            await _departamentoRepository.CreateDepartamento(departamento);


            return "";
        }
    }
}
