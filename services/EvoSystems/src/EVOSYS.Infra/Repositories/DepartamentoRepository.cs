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
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly Contexto _contexto;

        public DepartamentoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<List<Departamento>> GetDepartementos()
        {
            return await _contexto.Departamentos.ToListAsync();
        }
        public async Task CreateDepartamento(Departamento departamento)
        {
            await _contexto.Departamentos.AddAsync(departamento);

            _contexto.SaveChanges();
        }
        public async Task UpdateDepartamento(Departamento departamento)
        {
            _contexto.Departamentos.Update(departamento);

            var result = await _contexto.SaveChangesAsync();
        }
        public async Task<int> DeletarDepartamento(int id)
        {
            int result = 0;
            var departamento = _contexto.Departamentos.Where(x => x.Id == id).FirstOrDefault();

            if (departamento is not null)
            {
                _contexto.Departamentos.Remove(departamento);

                result = await _contexto.SaveChangesAsync();
            }
            return result;
        }
    }
}
