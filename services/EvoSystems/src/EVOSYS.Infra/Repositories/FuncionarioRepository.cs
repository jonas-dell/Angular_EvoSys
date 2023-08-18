using DepartamentosAPI.Data;
using DepartamentosAPI.Models;
using EvoSystems.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Infra.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly Contexto _contexto;

        public FuncionarioRepository(Contexto contexto)
        {
            _contexto= contexto;
        }
        public async Task<List<Funcionario>> GetFuncionarios()
        {
            return await _contexto.Funcionarios.ToListAsync();
        }
        public async Task<List<Funcionario>> GetFuncionariosPeloDepartamentoId(int departamentoId)
        {
            return await _contexto.Funcionarios
                .Where(x => x.DepartamentoId == departamentoId)
                .ToListAsync();
        }
        public async  Task CreateFuncionario(Funcionario funcionario)
        {
            await _contexto.Funcionarios.AddAsync(funcionario);

            var result =  _contexto.SaveChanges();
        }
        public async Task UpdateFuncionario(Funcionario funcionario)
        {
            _contexto.Funcionarios.Update(funcionario);

            var result = await _contexto.SaveChangesAsync();
        }
        public async Task<int> DeletarFuncionario(int id)
        {
            int result = 0;

            var funcionario = _contexto.Funcionarios.Where(x => x.Id == id).FirstOrDefault();
        
            if(funcionario is not null)
            {
                _contexto.Funcionarios.Remove(funcionario);

                result = await _contexto.SaveChangesAsync();
            }
            return result;
        }
    }
}
