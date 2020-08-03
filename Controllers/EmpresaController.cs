using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestãoFinanceira.Models;
using GestãoFinanceira.DAO;

namespace GestãoFinanceira.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            ViewBag.Empresa = Session["usuarioLogado"];
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Bastidores()
        {
            return View();
        }

        public ActionResult Adiciona(Empresa emp)
        {
            if (emp.NomeEmpresa != null || emp.NomeEmpresa.Length > 50 || emp.Senha != null || emp.Senha.Length < 8 || emp.Senha.Length > 50)
            {
                EmpresasDAO dao = new EmpresasDAO();
                dao.Adiciona(emp);
                Session["usuarioLogado"] = emp;
                Session["nomeEmpresa"] = emp.NomeEmpresa;
                return RedirectToAction("Index", "Conta");
            }
            else { return RedirectToAction("Form"); }
        }

        public ActionResult Contato()
        {
            ViewBag.Empresa = Session["usuarioLogado"];
            return View();
        }
    }
}