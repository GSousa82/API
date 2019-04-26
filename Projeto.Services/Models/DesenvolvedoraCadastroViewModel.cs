using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class DesenvolvedoraCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da Desenvolvedora")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CNPJ")]
        public int CNPJ { get; set; }
    }
}