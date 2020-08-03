using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestãoFinanceira.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; set; }
    }
}