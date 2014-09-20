using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsetturMobile
{
    public class DatabaseMonitor : IDisposable
    {
        #region "Variables"

        private Object _locker = new object();

        //Epecifica si esta instancia ha sido descartada (disposed). 
        private bool _disposed = false;

        //El timer de threading utilizado para las consultas.
        private Timer _timer;

        //Estado previo de la conexión
        private bool _wasConnected = false;

        //Estado actual de la conexión
        private bool _isConnected = false;

        //El evento q notifica del cambio en la conexión
        public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged;

        //El evento q notifica alguna excepción ocurrida
        public event EventHandler<ErrorEventArgs> ErrorOccurred;

        //Web Service
        wsConsettur.WsMobile wsConsMobile = new ConsetturMobile.wsConsettur.WsMobile();

        #endregion

        public DatabaseMonitor(int timerPeriod)
        {
            if (timerPeriod > 0)
            {
                _timer = new Timer(new TimerCallback(Timer_Callback), null, 0, timerPeriod);
            }
        }

        private void Timer_Callback(object o)
        {
            lock (_locker)
            {
                try
                {
                    //Consulto el estado de la conexión
                    bool _isConnected = GetConnectionState();

                    //Si hay cambio en el estado
                    if (!(_wasConnected == _isConnected))
                    {
                        //Lanzo el evento
                        ConnectionStateChangedEventArgs e = new ConnectionStateChangedEventArgs();
                        e.IsConnected = _isConnected;
                        this.OnConnectionStateChanged(e);
                    }

                    _wasConnected = _isConnected;
                }
                catch (Exception ex)
                {
                    ErrorEventArgs errorArgs = new ErrorEventArgs();
                    errorArgs.CustomeError = ex;
                    this.OnErrorOccurred(errorArgs);
                }
            }
        }

        private bool GetConnectionState()
        {
            bool isConnected = false;
            wsConsMobile.Url = clsUtil.rutaWS;

            try
            {
                isConnected = wsConsMobile.verificar_conexion();
            }
            catch
            {
                isConnected = false;
            }

            clsUtil.online = isConnected;
            return isConnected;
        }

        protected void OnConnectionStateChanged(ConnectionStateChangedEventArgs e)
        {
            if (ConnectionStateChanged != null)
            {
                ConnectionStateChanged(this, e);
            }
        }

        protected virtual void OnErrorOccurred(ErrorEventArgs e)
        {
            if (ErrorOccurred != null)
            {
                ErrorOccurred(this, e);
            }
        }

        #region Miembros de IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            //Protect from being called multiple times. 
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (!(_timer == null))
                {
                    _timer.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion
    }
}
