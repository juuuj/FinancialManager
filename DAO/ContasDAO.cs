using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using GestãoFinanceira.Models;

namespace GestãoFinanceira.DAO
{
    public class ContasDAO
    {
        public void Adiciona(Conta cont)
        {
            using (var context = new CorporacaoContext())
            {
                context.Conta.Add(cont);
                context.SaveChanges();
            }
        }

        public void Remover(Conta cnt)
        {
            using (var context = new CorporacaoContext())
            {
                context.Conta.Remove(cnt);
                context.SaveChanges();
            }
        }

        public void Atualizar(int cod, int situacao)
        {
            using (var context = new CorporacaoContext())
            {
                Conta cnt = context.Conta.Where(c => c.Id == cod).FirstOrDefault();
                cnt.Situacao = situacao;
                context.Conta.Update(cnt);
                context.SaveChanges();
            }
        }

        public void AtualizarValor(int cod, decimal v)
        {
            using (var context = new CorporacaoContext())
            {
                Conta cnt = context.Conta.Where(c => c.Id == cod).FirstOrDefault();
                cnt.ValorConta = v;
                context.Conta.Update(cnt);
                context.SaveChanges();
            }
        }

        public IList<Conta> Lista()
        {
            using (var contexto = new CorporacaoContext())
            {
                return contexto.Conta.ToList();
            }
        }

        public void Atualiza(Conta cont)
        {
            using (var contexto = new CorporacaoContext())
            {
                contexto.Entry(cont).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Conta BuscaPorNome(string nome)
        {
            using (var contexto = new CorporacaoContext())
            {
                return contexto.Conta.Where(cnt => cnt.NomeConta == nome).FirstOrDefault();
            }
        }
    }
}