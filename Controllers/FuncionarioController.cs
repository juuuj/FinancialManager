using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestãoFinanceira.Models;
using GestãoFinanceira.DAO;

namespace GestãoFinanceira.Controllers
{
    public class FuncionarioController : Controller
    {
        public ActionResult Form()
        {
            ViewBag.Empresa = Session["usuarioLogado"];

            BeneficiosDAO dao = new BeneficiosDAO();
            ViewBag.Beneficio = dao.Lista();

            return View();
        }

        public ActionResult Adiciona(Funcionario fnc, int idBeneficio)
        {
            if (fnc.NomeFuncionario != null || fnc.NomeFuncionario.Length > 50)
            {
                EmpresasDAO empresa = new EmpresasDAO();
                int idEmpresa = empresa.BuscaId(Session["nomeEmpresa"].ToString());

                fnc.IdEmpresa = idEmpresa;
                fnc.IdBeneficio = idBeneficio;

                FuncionariosDAO dao = new FuncionariosDAO();
                dao.Adiciona(fnc);
                return RedirectToAction("Index", "Conta");
            }
            else { return RedirectToAction("Adiciona"); }
        }
    }
}