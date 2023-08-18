using DepartamentosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartamentosAPI.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes)
       : base(opcoes)
        {

        }
    }
}