using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class JogoConsultaViewModel
    {
        public int IdJogo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Classificacao { get; set; }
        public DateTime DataLancamento { get; set; }
        public int IdDesenvolvedora { get; set; }
        public int IdPlataforma { get; set; }
    }
}