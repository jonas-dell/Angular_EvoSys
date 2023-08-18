using EvoSystems.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Commands
{
    public class CreateFuncionarioCommand : IRequest<string>
    {
        public CreateFuncionarioDTO CreateFuncionarioDTO { get; set; }
    }
}
