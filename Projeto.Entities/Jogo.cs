using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entities
{
    public class Jogo
    {
        public virtual int IdJogo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Categoria { get; set; }
        public virtual string Classificacao { get; set; }
        public virtual DateTime DataLancamento { get; set; }
        public virtual int IdDesenvolvedora { get; set; }
        public virtual int IdPlataforma { get; set; }
    }
}
