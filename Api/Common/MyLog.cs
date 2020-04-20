using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api.Common
{
    public class MyLog : IDisposable
    {
        log4net.Repository.ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        ILog logger = LogManager.GetLogger(typeof(Program));
        public MyLog()
        {
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
        public void GerarLog(string metodo, string mensagem)
        {
            logger.Info("Método: " + metodo + " - Mensagem:" + mensagem);
            Dispose(true);
        }

        public void GerarLog(string metodo, string mensagem, Exception ex)
        {
            logger.Error("Método: " + metodo + " - Mensagem:" + mensagem, ex);
            Dispose(true);
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

        ~MyLog()
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
