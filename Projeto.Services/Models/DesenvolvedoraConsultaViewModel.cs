using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class DesenvolvedoraConsultaViewModel
    {
        
        public int IdDesenvolvedora { get; set; }
        public string Nome { get; set; }
        public int CNPJ { get; set; }
    }
}