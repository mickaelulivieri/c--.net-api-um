using api_dotnet_um.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace api_dotnet_um.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("NomeDaConexao"){}

        public DbSet<Contato> contatos { get; set; }
    }
}