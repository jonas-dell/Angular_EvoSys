using EvoSystems.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Commands
{
    public class CreateDepartamentoCommand : IRequest<string>
    {
        public CreateDepartamentoDTO CreateDepartamentoDTO { get; set; }
    }
}
