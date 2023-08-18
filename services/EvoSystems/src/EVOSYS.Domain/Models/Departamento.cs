namespace DepartamentosAPI.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public IList<Funcionario> Funcionarios { get; set; }
    }
}