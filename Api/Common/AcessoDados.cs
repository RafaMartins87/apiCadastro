using Oracle.ManagedDataAccess.Client;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Common
{
    public class AcessoDados
    {
        private IDbConnection ObterConexao()
        {
            try
            {
                IDbConnection conexao = null;
                {
                    switch (Base.TIPOBANCO)
                    {
                        case "SQL":
                            conexao = new SqlConnection(Base.STRINGCONEXAO);
                            break;
                        case "ORACLE":
                            conexao = new OracleConnection(Base.STRINGCONEXAO);
                            break;
                    }
                }
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected IEnumerable<T> Pesquisar<T>(string query)
        {
            IEnumerable<T> resultado = null;
            try
            {
                using (var conexao = ObterConexao())
                {
                    resultado = conexao.Query<T>(query);
                    conexao.Close();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected IEnumerable<T> Pesquisar<T>(string consulta, object parametros = null, CommandType tipoComando = CommandType.StoredProcedure, bool comBuffer = true)
        {
            IEnumerable<T> resultado = null;
            try
            {

                using (var conexao = ObterConexao())
                {
                    resultado = conexao.Query<T>(consulta, parametros, buffered: comBuffer, commandType: tipoComando);
                    conexao.Close();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected IEnumerable<T> Pesquisar<T>(Dictionary<string, object> query)
        {
            IEnumerable<T> resultado = null;
            try
            {
                using (var conexao = ObterConexao())
                {
                    foreach (KeyValuePair<string, object> t in query)
                    {
                        resultado = conexao.Query<T>(t.Key, t.Value);
                        conexao.Close();
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected string Executar(string query)
        {
            using (var conexao = ObterConexao())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    conexao.Execute(query, transaction: transaction);
                    transaction.Commit();
                    conexao.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected string Executar(string query, object parametros)
        {
            using (var conexao = ObterConexao())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    conexao.Execute(query, param: parametros, transaction: transaction);
                    transaction.Commit();
                    conexao.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected string Executar(string procedure, object parametros, CommandType tipoComando = CommandType.Text)
        {
            using (var conexao = ObterConexao())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    conexao.Execute(procedure, param: parametros, transaction: transaction, commandType: tipoComando);
                    transaction.Commit();
                    conexao.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected string Executar(Dictionary<string, object> query)
        {
            using (var conexao = ObterConexao())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    foreach (KeyValuePair<string, object> t in query)
                    {
                        conexao.Execute(t.Key, t.Value, transaction: transaction);
                    }
                    transaction.Commit();
                    conexao.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected string Executar(Dictionary<object, string> query)
        {
            using (var conexao = ObterConexao())
            {
                var transaction = conexao.BeginTransaction();
                try
                {
                    foreach (KeyValuePair<object, string> t in query)
                    {
                        conexao.Execute(t.Value, t.Key, transaction: transaction);
                    }
                    transaction.Commit();
                    conexao.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected IEnumerable<T> ExecutarComRetorno<T>(string query)
        {
            using (var conexao = ObterConexao())
            {
                IEnumerable<T> retorno;
                var transaction = conexao.BeginTransaction();
                try
                {
                    retorno = conexao.Query<T>(query, transaction: transaction);
                    transaction.Commit();
                    conexao.Close();

                    return retorno;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected IEnumerable<T> ExecutarComRetorno<T>(string query, object parametros)
        {
            using (var conexao = ObterConexao())
            {
                IEnumerable<T> retorno;
                var transaction = conexao.BeginTransaction();
                try
                {
                    retorno = conexao.Query<T>(query, param: parametros, transaction: transaction);
                    transaction.Commit();
                    conexao.Close();

                    return retorno;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected IEnumerable<T> ExecutarComRetorno<T>(string procedure, object parametros, CommandType tipoComando = CommandType.Text)
        {
            using (var conexao = ObterConexao())
            {
                IEnumerable<T> retorno;
                var transaction = conexao.BeginTransaction();
                try
                {
                    retorno = conexao.Query<T>(procedure, param: parametros, transaction: transaction, commandType: tipoComando);
                    transaction.Commit();
                    conexao.Close();

                    return retorno;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        protected IEnumerable<T> ExecutarComRetorno<T>(Dictionary<string, object> query)
        {
            using (var conexao = ObterConexao())
            {
                IEnumerable<T> retorno = null;
                var transaction = conexao.BeginTransaction();
                try
                {
                    foreach (KeyValuePair<string, object> t in query)
                    {
                        retorno = conexao.Query<T>(t.Key, t.Value, transaction: transaction);
                    }
                    transaction.Commit();
                    conexao.Close();

                    return retorno;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }


        protected string PesquisarFirstResult(Dictionary<string, object> query)
        {

            try
            {
                using (var conexao = ObterConexao())
                {
                    string i = null;
                    foreach (var item in query)
                    {
                        i = conexao.QueryFirst<string>(item.Key, item.Value);
                    }
                    conexao.Close();
                    return i;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> PesquisarSlapper<T>(Dictionary<string, object> query)
        {
            IEnumerable<T> resultado = null;
            try
            {
                using (var conexao = ObterConexao())
                {
                    foreach (KeyValuePair<string, object> t in query)
                    {
                        IEnumerable<dynamic> dados = conexao.Query<dynamic>(t.Key, t.Value);
                        resultado = (Slapper.AutoMapper.MapDynamic<T>(dados) as IEnumerable<T>);
                        Slapper.AutoMapper.Cache.ClearAllCaches();
                        conexao.Close();
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> PesquisarSlapper<T>(string query)
        {
            IEnumerable<T> resultado = null;
            try
            {
                using (var conexao = ObterConexao())
                {
                    IEnumerable<dynamic> dados = conexao.Query<dynamic>(query);
                    resultado = (Slapper.AutoMapper.MapDynamic<T>(dados) as IEnumerable<T>);
                    Slapper.AutoMapper.Cache.ClearAllCaches();
                    conexao.Close();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

    }
}
