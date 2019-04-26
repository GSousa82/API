using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repositories.Mapping
{
    public class PlataformaMap : EntityTypeConfiguration<Plataforma>
    {
        public PlataformaMap()
        {
            //Nome da tabela
            ToTable("PLATAFORMA");

            //chave primária
            HasKey(p => p.IdPlataforma);

            Property(p => p.IdPlataforma)
                    .HasColumnName("IDPLATAFORMA")
                    .IsRequired();

            Property(p => p.Nome)
                    .HasColumnName("NOME")
                    .IsRequired();

            Property(p => p.Modelo)
                    .HasColumnName("MODELO")
                    .IsRequired();

            Property(p => p.IdPlataforma)
                    .HasColumnName("IDPLATAFORMA")
                    .IsRequired();
        }
    }
}
