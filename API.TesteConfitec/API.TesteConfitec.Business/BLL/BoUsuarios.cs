using API.TesteConfitec.Data;
using API.TesteConfitec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.TesteConfitec.Busines
{
    public class BoUsuarios
    {
        public OutUsuario Adicionar(InUsuario pUsuario)
        {
            var retorno = new OutUsuario();
            var usuario = new Usuarios();

            try
            {
                ValidarModelo(pUsuario, ref usuario, Util.TipoAcao.Adicionar);

                var dspUsuario = new DispatcherUsuarios();

                bool indicaSucesso = dspUsuario.Adicionar(usuario);

                if (indicaSucesso)
                {
                    retorno.Status = Util.STATUS_OK;
                    retorno.MensagemRetorno = "Usuário adicionado com sucesso.";
                    retorno.ListaUsuarios.Add(usuario);
                }

            }
            catch(Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        public OutUsuario Editar(InUsuario pUsuario)
        {
            var retorno = new OutUsuario();
            var usuario = new Usuarios();

            try
            {
                ValidarModelo(pUsuario, ref usuario, Util.TipoAcao.Editar);

                var dspUsuario = new DispatcherUsuarios();

                bool indicaSucesso = dspUsuario.Editar(usuario);

                if (indicaSucesso)
                {
                    retorno.Status = Util.STATUS_OK;
                    retorno.MensagemRetorno = "Usuário alterado com sucesso.";
                    retorno.ListaUsuarios.Add(usuario);
                }

            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        public OutUsuario Excluir(int Id)
        {
            var retorno = new OutUsuario();
            
            try
            {
                if (Id == 0)
                    throw new Exception("ID inválido");

                var dspUsuario = new DispatcherUsuarios();

                bool indicaSucesso = dspUsuario.Excluir(Id);

                if (indicaSucesso)
                {
                    retorno.Status = Util.STATUS_OK;
                    retorno.MensagemRetorno = "Usuário excluído com sucesso.";
                }

            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        public OutUsuario ObterPorId(int Id)
        {
            var retorno = new OutUsuario();

            try
            {
                if (Id == 0)
                    throw new Exception("ID inválido");

                var dspUsuario = new DispatcherUsuarios();

                var usuario = dspUsuario.ObterPorId(Id);

                if (usuario != null)
                {
                    retorno.Status = Util.STATUS_OK;
                    retorno.ListaUsuarios.Add(usuario);
                }

            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        public OutUsuario ObterPorNome(string nome)
        {
            var retorno = new OutUsuario();

            try
            {
                if (string.IsNullOrEmpty(nome))
                    throw new Exception("Nome inválido");

                var dspUsuario = new DispatcherUsuarios();

                var usuarios = dspUsuario.ObterPorNome(nome);

                if (usuarios != null)
                {
                    retorno.Status = Util.STATUS_OK;
                    retorno.ListaUsuarios = usuarios;
                }

            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        public OutUsuario ObterPorEmail(string email)
        {
            var retorno = new OutUsuario();

            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new Exception("Email inválido");

                var dspUsuario = new DispatcherUsuarios();

                var usuario = dspUsuario.ObterPorEmail(email);

                if (usuario != null)
                {
                    retorno.Status = Util.STATUS_OK;
                    retorno.ListaUsuarios.Add(usuario);
                }

            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        public OutUsuario ObterLista()
        {
            var retorno = new OutUsuario();

            try
            {
                var dspUsuario = new DispatcherUsuarios();

                var usuarios = dspUsuario.ObterLista();

                if (usuarios != null)
                {
                    retorno.Status = Util.STATUS_OK;
                    retorno.ListaUsuarios = usuarios;
                }

            }
            catch (Exception ex)
            {
                retorno.Status = Util.STATUS_ERRO;
                retorno.MensagemRetorno = ex.Message;
            }

            return retorno;
        }

        public void ValidarModelo(InUsuario pUsuario, ref Usuarios usuario, Util.TipoAcao tipoAcao)
        {
            var dspUsuario = new DispatcherUsuarios();

            if (string.IsNullOrEmpty(pUsuario.Nome))
                throw new Exception("Favor preencher o campo de nome.");

            if (pUsuario.Nome.Length < 3)
                throw new Exception("Nome inválido.");

            if (string.IsNullOrEmpty(pUsuario.Sobrenome))
                throw new Exception("Favor preencher o campo de sobrenome.");

            if (pUsuario.Sobrenome.Length < 3)
                throw new Exception("Sobrenome inválido.");

            if (pUsuario.DataNascimento == DateTime.MinValue)
                throw new Exception("Data de nascimento inválida");

            if (pUsuario.DataNascimento >= DateTime.Now.Date)
                throw new Exception("Data de nascimento não pode ser depois que a data atual");

            if (string.IsNullOrEmpty(pUsuario.Email))
                throw new Exception("Favor preencher o campo de email.");

            if (dspUsuario.ValidarEmail(pUsuario.Email, tipoAcao, pUsuario.Id))
                throw new Exception("Email já cadastrado na base de dados.");

            if (pUsuario.Escolaridade == Util.Escolaridade.Indefinido)
                throw new Exception("Favor selecionar uma das opções de escolaridade.");

            usuario.DataNascimento = pUsuario.DataNascimento;
            usuario.Email = pUsuario.Email;
            usuario.Escolaridade = pUsuario.Escolaridade;
            usuario.Id = pUsuario.Id;
            usuario.Nome = pUsuario.Nome;
            usuario.Sobrenome = pUsuario.Sobrenome;

        }
    }

    
}
