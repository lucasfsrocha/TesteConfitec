using System;
using System.Collections.Generic;
using System.Text;

namespace API.TesteConfitec.Models
{
    public class InUsuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public Util.Escolaridade Escolaridade { get; set; }
    }
}
