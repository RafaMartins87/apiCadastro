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
            string SQL = "INSERT INTO DADOS(ID, NOME, EMAIL) VALUES (@ID, @NOME, @EMAIL)";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public string CadastroGet()
        {
            string SQL = "SELECT ID, NOME, EMAIL FROM DADOS";

            return SQL;
        }

        public Dictionary<string, object> CadastroUpd(CadastroModel dados)
        {
            string SQL = "UPDATE DADOS SET NOME = @NOME, EMAIL = @EMAIL WHERE ID = @ID";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public Dictionary<string, object> CadastroDel(int id)
        {
            string SQL = "DELETE FROM DADOS WHERE ID = @ID";

            return new Dictionary<string, object>() { { SQL, new { id = id} } };
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
