using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repositories.Mapping
{
    public class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {
            ToTable("JOGO");

            HasKey(j => j.IdJogo);

            Property(j => j.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            Property(j => j.Categoria)
                .HasColumnName("CATEGORIA")
                .IsRequired();

            Property(j => j.Classificacao)
                .HasColumnName("CLASSIFICACAO")
                .IsRequired();

            Property(j => j.DataLancamento)
                .HasColumnName("DATALANCAMENTO")
                .IsRequired();

            Property(j => j.IdDesenvolvedora)
                .HasColumnName("IDDESENVOLVEDORA")
                .IsRequired();

            Property(j => j.IdPlataforma)
                .HasColumnName("IDPLATAFORMA")
                .IsRequired();
        }
    }
}
