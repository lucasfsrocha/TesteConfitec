using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace API.TesteConfitec.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(50)]
        [Required]
        public string Sobrenome { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public Util.Escolaridade Escolaridade { get; set; }
    }
}
