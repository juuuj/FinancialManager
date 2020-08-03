using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using GestãoFinanceira.Models;

namespace GestãoFinanceira.DAO
{
    public class FuncionariosDAO
    {
        public void Adiciona(Funcionario fnc)
        {
            using (var context = new CorporacaoContext())
            {
                context.Funcionario.Add(fnc);
                context.SaveChanges();
            }
        }

        public void Remover(Funcionario fnc)
        {
            using (var context = new CorporacaoContext())
            {
                context.Funcionario.Remove(fnc);
                context.SaveChanges();
            }
        }

        public void Atualizar(int cod, decimal v)
        {
            using (var context = new CorporacaoContext())
            {
                Funcionario func = context.Funcionario.Where(fnc => fnc.Id == cod).FirstOrDefault();
                func.Salario = v;
                context.Funcionario.Update(func);
                context.SaveChanges();
            }
        }

        public IList<Funcionario> Lista()
        {
            using (var contexto = new CorporacaoContext())
            {
                return contexto.Funcionario.ToList();
            }
        }

        public void Atualiza(Funcionario fnc)
        {
            using (var contexto = new CorporacaoContext())
            {
                contexto.Entry(fnc).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Funcionario BuscaPorNome(string nome)
        {
            using (var contexto = new CorporacaoContext())
            {
                return contexto.Funcionario.Where(fnc => fnc.NomeFuncionario == nome).FirstOrDefault();
            }
        }

    }
}