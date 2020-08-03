using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestãoFinanceira.Models;
using GestãoFinanceira.DAO;

namespace GestãoFinanceira.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            ViewBag.Empresa = Session["usuarioLogado"];

            ContasDAO daoC = new ContasDAO();
            IList<Conta> cnt = daoC.Lista();
            ViewBag.Conta = cnt;

            FuncionariosDAO daoF = new FuncionariosDAO();
            IList<Funcionario> fnc = daoF.Lista();
            ViewBag.Funcionario = fnc;

            BeneficiosDAO daoB = new BeneficiosDAO();
            IList<Beneficio> bnf = daoB.Lista();
            ViewBag.Beneficio = bnf;

            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Conta cnt, bool? tipo, bool? situacao)
        {
            if (cnt.NomeConta != null || cnt.NomeConta.Length < 40)
            {
                if (tipo == null)
                    cnt.Tipo = 0;
                else cnt.Tipo = 1;

                if (situacao == null)
                    cnt.Situacao = 0;
                else cnt.Situacao = 1;

                EmpresasDAO empresa = new EmpresasDAO();
                int idEmpresa = empresa.BuscaId(Session["nomeEmpresa"].ToString());
                cnt.IdEmpresa = idEmpresa;

                ContasDAO dao = new ContasDAO();
                dao.Adiciona(cnt);
                return RedirectToAction("Index", "Conta");
            }
            else { return RedirectToAction("Form"); }
        }

        public ActionResult Atualizar(string cnt)
        {
            ContasDAO dao = new ContasDAO();
            Conta conta = dao.BuscaPorNome(cnt);

            if (conta.Situacao == 0)
            {
                conta.Situacao = 1;

                dao = new ContasDAO();
                dao.Atualiza(conta);


                EmpresasDAO empD = new EmpresasDAO();
                Empresa emp = ViewBag.Empresa;

                if (conta.Tipo == 0)
                {
                    emp.Saldo -= conta.ValorConta;
                    empD.Atualiza(emp);
                }
                else
                {
                    emp.Saldo += conta.ValorConta;
                    empD.Atualiza(emp);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoverFuncionario(string fnc)
        {
            FuncionariosDAO daoF = new FuncionariosDAO();
            daoF.Remover(daoF.BuscaPorNome(fnc));

            return RedirectToAction("Index");
        }

        public ActionResult RemoverConta(string cnt)
        {
            ContasDAO daoC = new ContasDAO();
            daoC.Remover(daoC.BuscaPorNome(cnt));

            return RedirectToAction("Index");
        }
    }
}