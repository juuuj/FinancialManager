using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using GestãoFinanceira.Models;

namespace GestãoFinanceira.DAO
{
    public class EmpresasDAO
    {
        public void Adiciona(Empresa emp)
        {
            using (var context = new CorporacaoContext())
            {
                context.Empresa.Add(emp);
                context.SaveChanges();
            }
        }

        public IList<Empresa> Lista()
        {
            using (var contexto = new CorporacaoContext())
            {
                return contexto.Empresa.ToList();
            }
        }

        public void Atualiza(Empresa emp)
        {
            using (var contexto = new CorporacaoContext())
            {
                contexto.Entry(emp).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Empresa Busca(string login, string senha)
        {
            using (var contexto = new CorporacaoContext())
            {
                var existente = contexto.Empresa.Where(emp => emp.NomeEmpresa == login).FirstOrDefault();
                if (existente.Senha != senha)
                    return null;

                return existente;
            }
        }

        public int BuscaId(string nome)
        {
            using (var contexto = new CorporacaoContext())
            {
                var existente = contexto.Empresa.Where(emp => emp.NomeEmpresa == nome).FirstOrDefault();

                return existente.Id;
            }
        }
    }
}