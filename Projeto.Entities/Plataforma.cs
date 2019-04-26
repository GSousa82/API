using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entities
{
    public class Plataforma
    {
        public virtual int IdPlataforma { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Modelo { get; set; }
    }
}
