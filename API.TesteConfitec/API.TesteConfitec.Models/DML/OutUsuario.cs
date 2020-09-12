using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace API.TesteConfitec.Models
{
    public class OutUsuario
    {
        public OutUsuario()
        {
            Status = string.Empty;
            MensagemRetorno = string.Empty;
            ListaUsuarios = new List<Usuarios>();
        }

        public string Status { get; set; }

        public string MensagemRetorno { get; set; }

        public List<Usuarios> ListaUsuarios { get; set; }
    }
}
