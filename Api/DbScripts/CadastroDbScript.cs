using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.DbScripts
{
    public class CadastroDbScript
    {

        public Dictionary<string, object> CadastroAdd(CadastroModel dados)
        {
            string SQL = "INSERT INTO DADOS(INT, NOME, EMAIL) VALUES (:INT, :NOME, :EMAIL)";

            return new Dictionary<string, object>() { { SQL, dados } };
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

        ~CadastroDbScript()
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
