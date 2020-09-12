using System;
using System.Collections.Generic;
using System.Text;

namespace API.TesteConfitec.Models
{
    public static class Util
    {
        public static string ConnectionString { get; set; }

        public const string STATUS_OK = "OK";
        public const string STATUS_ERRO = "ERRO";

        public enum Escolaridade
        {
            Indefinido,
            Infantil,
            Fundamental,
            Medio,
            Superior
        }

        public enum TipoAcao
        {
            Indefinido,
            Adicionar,
            Editar,
            Excluir,
            Consultar,
            Outra
        }
    }
}
