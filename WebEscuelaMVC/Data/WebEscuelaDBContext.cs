using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Data
{
    public class WebEscuelaDBContext : DbContext
    {
        public WebEscuelaDBContext() : base("keyWebEscuelaDBMVC") { }

        public DbSet<Aula> Aulas { get; set; }
    }
}