using Projeto_Meta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto_Meta.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public System.Data.Entity.DbSet<Projeto_Meta.Models.Modelo_02> Modelo_02 { get; set; }

        public System.Data.Entity.DbSet<Projeto_Meta.Models.Modelo_01> Modelo_01 { get; set; }
    }
}