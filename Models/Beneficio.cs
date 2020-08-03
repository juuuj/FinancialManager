using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestãoFinanceira.Models
{
    public class Beneficio
    {
        public int Id { get; set; }
        public string NomeBeneficio { get; set; }
        public decimal ValorBeneficio { get; set; }
    }
}