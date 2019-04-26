using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repositories.Mapping
{
    public class DesenvolvedoraMap : EntityTypeConfiguration<Desenvolvedora>
    {
        public DesenvolvedoraMap()
        {
            ToTable("DESENVOLVEDORA");

            HasKey(d => d.IdDesenvolvedora);

            Property(d => d.IdDesenvolvedora)
                .HasColumnName("IDDESENVOLVEDORA")
                .IsRequired();

            Property(d => d.Nome)
                .HasColumnName("NOME")
                .IsRequired();

            Property(d => d.CNPJ)
                .HasColumnName("CNPJ")
                .IsRequired();
        }
    }
}
