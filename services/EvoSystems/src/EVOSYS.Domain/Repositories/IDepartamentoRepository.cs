using DepartamentosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Repositories
{
    public interface IDepartamentoRepository
    {
        Task<List<Departamento>> GetDepartementos();
        Task CreateDepartamento(Departamento departamento);
        Task UpdateDepartamento(Departamento departamento);
        Task<int> DeletarDepartamento(int id);
    }
}
