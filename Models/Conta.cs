using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestãoFinanceira.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string NomeConta { get; set; }
        public DateTime Prazo { get; set; }
        public int Situacao { get; set; }
        public decimal ValorConta { get; set; }
        public int Tipo { get; set; }
    }
}