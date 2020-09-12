using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.TesteConfitec.Busines;
using API.TesteConfitec.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.TesteConfitec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        [HttpPost("Adicionar")]
        public OutUsuario Adicionar(InUsuario pUsuario)
        {
            var retorno = new OutUsuario();
            
            try
            {
                var boUsuario = new BoUsuarios();
                retorno = boUsuario.Adicionar(pUsuario);
            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        [HttpPost("Editar")]
        public OutUsuario Editar(InUsuario pUsuario)
        {
            var retorno = new OutUsuario();

            try
            {
                var boUsuario = new BoUsuarios();
                retorno = boUsuario.Editar(pUsuario);
            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        [HttpPost("Excluir")]
        public OutUsuario Excluir(int Id)
        {
            var retorno = new OutUsuario();

            try
            {
                var boUsuario = new BoUsuarios();
                retorno = boUsuario.Excluir(Id);
            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        [HttpGet("ObterPorId")]
        public OutUsuario ObterPorId(int Id)
        {
            var retorno = new OutUsuario();

            try
            {
                var boUsuario = new BoUsuarios();
                retorno = boUsuario.ObterPorId(Id);
            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        [HttpGet("ObterPorNome")]
        public OutUsuario ObterPorNome(string nome)
        {
            var retorno = new OutUsuario();

            try
            {
                var boUsuario = new BoUsuarios();
                retorno = boUsuario.ObterPorNome(nome);
            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        [HttpGet("ObterPorEmail")]
        public OutUsuario ObterPorEmail(string email)
        {
            var retorno = new OutUsuario();

            try
            {
                var boUsuario = new BoUsuarios();
                retorno = boUsuario.ObterPorEmail(email);
            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        [HttpGet("ObterLista")]
        public OutUsuario ObterLista()
        {
            var retorno = new OutUsuario();

            try
            {
                var boUsuario = new BoUsuarios();
                retorno = boUsuario.ObterLista();
            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }
    }
}
