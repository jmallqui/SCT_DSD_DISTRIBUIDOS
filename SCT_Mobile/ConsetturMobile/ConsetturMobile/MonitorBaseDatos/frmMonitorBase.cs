using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ConsetturMobile.MonitorBaseDatos
{
    public class frmMonitorBase : Form
    {
        public frmMonitorBase()
        {
            this.Load += new EventHandler(frmMonitorBase_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(frmMonitorBase_Closing);
            this.Activated += new EventHandler(frmMonitorBase_Activated);
            this.Deactivate += new EventHandler(frmMonitorBase_Deactivate);
        }

        void frmMonitorBase_Load(object sender, EventArgs e)
        {
        }

        void frmMonitorBase_Activated(object sender, EventArgs e)
        {
            if (_monitor != null)
            {
                _monitor.ConnectionStateChanged += Monitor_ConnectionStateChanged;
                _monitor.ErrorOccurred += Monitor_ErrorOccurred;   
            }
            Debug.WriteLine(this.Name + "_Activated");
        }

        void frmMonitorBase_Deactivate(object sender, EventArgs e)
        {
            if (_monitor != null)
            {
                _monitor.ConnectionStateChanged -= Monitor_ConnectionStateChanged;
                _monitor.ErrorOccurred -= Monitor_ErrorOccurred;
            }
            Debug.WriteLine(this.Name + "_Deactivate");
        }

        void frmMonitorBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_monitor != null)
            {
                _monitor.ConnectionStateChanged -= Monitor_ConnectionStateChanged;
                _monitor.ErrorOccurred -= Monitor_ErrorOccurred;
            }
            _monitor.Dispose();
            Debug.WriteLine(this.Name + "_Closing");
        }

        private DatabaseMonitor _monitor;

        protected void ConfigurarMonitor()
        {
            _monitor = new DatabaseMonitor(clsUtil.tiempo);
            _monitor.ConnectionStateChanged += Monitor_ConnectionStateChanged;
            _monitor.ErrorOccurred += Monitor_ErrorOccurred;
        }

        #region "Manejo de Hilo"

        public void Monitor_ErrorOccurredHandler(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.CustomeError.Message);
        }

        public void Monitor_ConnectionStateChangedHandler(object sender, ConnectionStateChangedEventArgs e)
        {
            //Realizar acción correspondiente según el estado al que cambia la conexión
            if (e.IsConnected)
            {
                //Conectado
                clsUtil.online = true;
                ActualizarEstado();
            }
            else
            {
                //Desconectado
                clsUtil.online = false;
            }
            ActualizarEstado();
        }

        protected virtual void ActualizarEstado()
        {      

        }

        public void Monitor_ErrorOccurred(object sender, ErrorEventArgs e)
        {
            try
            {
                this.Invoke(new EventHandler<ErrorEventArgs>(Monitor_ErrorOccurredHandler), sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Monitor_Error: " + ex.Message,
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,                   
                                MessageBoxDefaultButton.Button1);
            }
        }

        public void Monitor_ConnectionStateChanged(object sender, ConnectionStateChangedEventArgs e)
        {
            try
            {
                this.Invoke(new EventHandler<ConnectionStateChangedEventArgs>(Monitor_ConnectionStateChangedHandler), sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Monitor_ConnectionState: " + ex.Message,
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
            }
        }

        #endregion
    }
}
