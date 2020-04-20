using Api.Common;
using Api.DbScripts;
using Api.Models;
using System;

namespace Api.Business
{
    public class CadastroBusiness : AcessoDados, IDisposable
    {
        private CadastroDbScript dbScript = new CadastroDbScript();
        public string CadastroValidaAdd(CadastroModel dados)
        {
            return "OK";
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                { }

                disposedValue = true;
            }
        }

        ~CadastroBusiness()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
