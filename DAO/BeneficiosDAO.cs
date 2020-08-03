using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using GestãoFinanceira.Models;

namespace GestãoFinanceira.DAO
{
    public class BeneficiosDAO
    {
        public IList<Beneficio> Lista()
        {
            using (var contexto = new CorporacaoContext())
            {
                return contexto.Beneficio.ToList();
            }
        }

        public int BuscaId(string nome)
        {
            using (var contexto = new CorporacaoContext())
            {
                var existente = contexto.Beneficio.Where(bnf => bnf.NomeBeneficio == nome).FirstOrDefault();

                return existente.Id;
            }
        }
    }
}