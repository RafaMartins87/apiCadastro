using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Common
{
    public class Error : IDisposable
    {
        public HttpStatusCode httpStatus { get; set; }
        public string metodo { get; set; }
        public string detalhe { get; set; }

        public Error(HttpStatusCode _httpStatus, string _metodo, string _detalhe)
        {
            httpStatus = _httpStatus;
            metodo = _metodo;
            detalhe = _detalhe;
        }
        #region IDisposable Support
        private bool disposedValue = false; // Para detectar chamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                { }

                disposedValue = true;
            }
        }

        ~Error()
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
