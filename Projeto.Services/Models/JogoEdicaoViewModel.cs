using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class JogoEdicaoViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o Id do Jogo")]
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome go Jogo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Classificação")]
        public string Classificacao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Desenvolvedora")]
        public int IdDesenvolvedora { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Plataforma")]
        public int IdPlataforma { get; set; }
    }
}
