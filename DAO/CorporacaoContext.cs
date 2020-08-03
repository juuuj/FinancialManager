using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using GestãoFinanceira.Models;

namespace GestãoFinanceira.DAO
{
    public class CorporacaoContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Beneficio> Beneficio { get; set; }
        public DbSet<Conta> Conta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=regulus; Initial Catalog=PR118206; User ID=PR118206; Password=ParkerPeter");
        }
    }
}