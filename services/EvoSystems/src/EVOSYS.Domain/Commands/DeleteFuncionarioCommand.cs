using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Commands
{
    public class DeleteFuncionarioCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
