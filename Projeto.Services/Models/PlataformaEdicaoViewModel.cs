using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class PlataformaEdicaoViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o Id")]
        public int IdPlataforma { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe Modelo")]
        public string Modelo { get; set; }
    }
}