using DepartamentosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<List<Funcionario>> GetFuncionarios();
        Task<List<Funcionario>> GetFuncionariosPeloDepartamentoId(int departamentoId);
        Task CreateFuncionario(Funcionario funcionario);
        Task UpdateFuncionario(Funcionario funcionario);
        Task<int> DeletarFuncionario(int id);
    }
}
