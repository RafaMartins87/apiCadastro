using Api.Business;
using Api.Common;
using Api.DbScripts;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class CadastroRepository : AcessoDados, ICadastroRepository, IDisposable 
    {

        //comentei
        private CadastroBusiness _cadastroBusiness = new CadastroBusiness();
        private CadastroDbScript dbScript = new CadastroDbScript();
        public CadastroRepository() { Dispose(true); }

        public string CadastroAdd(CadastroModel dados)
        {
            try
            {
                string retornoValidaAdd = _cadastroBusiness.CadastroValidaAdd(dados);

                if(retornoValidaAdd != "OK")
                {
                    return retornoValidaAdd;
                }

                var execCadastro = Executar(dbScript.CadastroAdd(dados));

                dbScript.Dispose();
                _cadastroBusiness.Dispose();
                return "Dados Cadastrados";

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<CadastroModel> CadastroGet()
        {
            try
            {
                
                var getCadastro = Pesquisar<CadastroModel>(dbScript.CadastroGet());

                dbScript.Dispose();
                _cadastroBusiness.Dispose();
                return getCadastro;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string CadastroUpd(CadastroModel dados)
        {
            try
            {

                var execCadastro = Executar(dbScript.CadastroUpd(dados));

                dbScript.Dispose();
                _cadastroBusiness.Dispose();
                return "Dados = " + "Nome: " + dados.nome +  " |" + " Email: " +  dados.email + "inseridos";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string CadastroDel(int id)
        {
            try
            {

                var execCadastro = Executar(dbScript.CadastroDel(id));

                dbScript.Dispose();
                _cadastroBusiness.Dispose();
                return "id = " + id + "deletado";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CadastroRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
