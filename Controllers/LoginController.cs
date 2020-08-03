using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestãoFinanceira.Models;
using GestãoFinanceira.DAO;

namespace GestãoFinanceira.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AutenticaLogin(string loginEmpresa, string senhaEmpresa)
        {
            EmpresasDAO dao = new EmpresasDAO();
            Empresa emp = dao.Busca(loginEmpresa, senhaEmpresa);

            if (emp != null)
            {
                Session["usuarioLogado"] = emp;
                Session["nomeEmpresa"] = emp.NomeEmpresa;
                return RedirectToAction("Index", "Conta");
            }
            else
                return RedirectToAction("Index", "Login");
        }

        public ActionResult Sair()
        {
            Session["usuarioLogado"] = null;
            Session["nomeEmpresa"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}