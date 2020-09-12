using API.TesteConfitec.Data.Context;
using API.TesteConfitec.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.TesteConfitec.Data
{
    public class DispatcherUsuarios
    {
        private readonly DataContext dbContext;

        public DispatcherUsuarios()
        {
            dbContext = new DataContext();
        }

        public bool Adicionar(Usuarios usuario)
        {
            int linhasAfetadas = 0;

            if (usuario != null)
            {
                try
                {
                    dbContext.Database.BeginTransaction();

                    dbContext.Usuarios.Add(usuario);

                    linhasAfetadas = dbContext.SaveChanges();

                    if (linhasAfetadas > 0)
                        dbContext.Database.CommitTransaction();
                    else
                        throw new Exception("Não foi possível adicionar o registro. Favor tentar novamente.");
                }
                catch (Exception ex)
                {
                    dbContext.Database.RollbackTransaction();
                    throw new Exception(string.Concat("Erro ao adicionar: ", ex.Message));
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }

            return linhasAfetadas > 0;
        }

        public bool Editar(Usuarios usuario)
        {
            int linhasAfetadas = 0;

            if (usuario != null)
            {
                try
                {
                    dbContext.Database.BeginTransaction();

                    var pUsuario = dbContext.Usuarios.Where(x => x.Id == usuario.Id).FirstOrDefault();

                    dbContext.Usuarios.Update(pUsuario).CurrentValues.SetValues(usuario);

                    linhasAfetadas = dbContext.SaveChanges();

                    if (linhasAfetadas > 0)
                        dbContext.Database.CommitTransaction();
                    else
                        throw new Exception("Não foi possível editar o registro. Favor tentar novamente.");
                }
                catch (Exception ex)
                {
                    dbContext.Database.RollbackTransaction();
                    throw new Exception(string.Concat("Erro ao editar: ", ex.Message));
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }

            return linhasAfetadas > 0;
        }

        public bool Excluir(int id)
        {
            int linhasAfetadas = 0;

            if (id > 0)
            {
                try
                {
                    dbContext.Database.BeginTransaction();

                    var pUsuario = ObterPorId(id);

                    dbContext.Usuarios.Remove(pUsuario);

                    linhasAfetadas = dbContext.SaveChanges();

                    if (linhasAfetadas > 0)
                        dbContext.Database.CommitTransaction();
                    else
                        throw new Exception("Não foi possível excluir o registro. Favor tentar novamente.");
                }
                catch (Exception ex)
                {
                    dbContext.Database.RollbackTransaction();
                    throw new Exception(string.Concat("Erro ao excluir: ", ex.Message));
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
            }

            return linhasAfetadas > 0;
        }

        public Usuarios ObterPorId(int id)
        {
            Usuarios pUsuario = new Usuarios();

            if (id > 0)
            {
                try
                {
                    pUsuario = dbContext.Usuarios.FirstOrDefault(a => a.Id == id);

                    if (pUsuario == null)
                        throw new Exception("Usuário não encontrado.");
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao obter usuário: ", ex.Message));
                }
            }

            return pUsuario;
        }

        public List<Usuarios> ObterPorNome(string nome)
        {
            List<Usuarios> pUsuarios = new List<Usuarios>();

            if (!string.IsNullOrEmpty(nome))
            {
                try
                {
                    pUsuarios = dbContext.Usuarios.Where(a => a.Nome == nome).ToList();

                    if (pUsuarios.Count == 0)
                        throw new Exception("Usuário não encontrado.");
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao obter usuário: ", ex.Message));
                }
            }

            return pUsuarios;
        }

        public Usuarios ObterPorEmail(string email)
        {
            Usuarios pUsuario = new Usuarios();

            if (!string.IsNullOrEmpty(email))
            {
                try
                {
                    pUsuario = dbContext.Usuarios.FirstOrDefault(a => a.Email == email);

                    if (pUsuario == null)
                        throw new Exception("Usuário não encontrado.");
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Concat("Erro ao obter usuário: ", ex.Message));
                }
            }

            return pUsuario;
        }

        public List<Usuarios> ObterLista()
        {
            List<Usuarios> pUsuarios = new List<Usuarios>();

            try
            {
                pUsuarios = dbContext.Usuarios.ToList().OrderBy(a => a.Id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Erro ao obter usuários: ", ex.Message));
            }

            if(pUsuarios.Count == 0)
                throw new Exception("Não existem usuários cadastrados.");

            return pUsuarios;
        }

        public bool ValidarEmail(string email, Util.TipoAcao tipoAcao, int id)
        {
            if(tipoAcao == Util.TipoAcao.Adicionar)
                return dbContext.Usuarios.Where(a => a.Email == email).ToList().Count > 0;

            if(tipoAcao == Util.TipoAcao.Editar)
                return dbContext.Usuarios.Where(a => a.Email == email && a.Id != id).ToList().Count > 0;

            return true;
        }
    }
}
