﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.DTO
{
    public class UpdateFuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Foto { get; set; }
        public int DepartamentoId { get; set; }
    }
}
