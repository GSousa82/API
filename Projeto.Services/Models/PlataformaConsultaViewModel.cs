using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class PlataformaConsultaViewModel
    {
       
        public int IdPlataforma { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
    }
}