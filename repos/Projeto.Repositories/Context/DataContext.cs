using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using Projeto.Repositories.Mapping;
using System.Configuration;
using System.Data.Entity;

namespace Projeto.Repositories.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base(ConfigurationManager.ConnectionStrings["ProjetoJogos"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JogoMap());
            modelBuilder.Configurations.Add(new DesenvolvedoraMap());
            modelBuilder.Configurations.Add(new PlataformaMap());
        }

        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Desenvolvedora> Desenvolvedora { get; set; }
        public DbSet<Plataforma> Plataforma { get; set; }
    }
}
