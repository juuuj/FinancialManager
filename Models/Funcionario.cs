using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestãoFinanceira.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdBeneficio { get; set; }
        public string NomeFuncionario { get; set; }
        public decimal Salario { get; set; }
    }
}