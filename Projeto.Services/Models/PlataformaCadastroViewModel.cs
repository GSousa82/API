using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class PlataformaCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da Plataforma")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Modelo")]
        public string Modelo { get; set; }
    }
}