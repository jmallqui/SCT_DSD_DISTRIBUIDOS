using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConsetturCompartido;
using ConsetturBussinessEntity;
using ConsetturBussinessLogic;
using ConsetturMobile.MonitorBaseDatos;

namespace ConsetturMobile
{
    //public partial class frmControlTicket : frmMonitorBase
    public partial class frmControlTicket : Form
    {
        public frmControlTicket()
        {
            InitializeComponent();
        }

        #region "Variables"

        public Int16 tipoServicio = 0;

        wsConsettur.WsMobile wsConsMobile = new ConsetturMobile.wsConsettur.WsMobile();
        wsConsettur.Transaccion wsTrasaccion = new ConsetturMobile.wsConsettur.Transaccion();

        blTransaccDetalleVarios oblTransacDetVarios = new blTransaccDetalleVarios();
        blTransaccionDetalle oblTransacDet = new blTransaccionDetalle();
        blTransaccion oblTransaccion = new blTransaccion();

        string mensajeError = string.Empty;

        string mensajeMostrar = string.Empty;
        string mensajeWS = string.Empty;
        string mensajeSDF = string.Empty;
        bool resultado = false;

        TextBox txtFoco;
        bool pasajerosAdd = false;
        bool busLleno = false;

        #endregion

        private void frmControlTicket_Load(object sender, EventArgs e)
        {
            switch (tipoServicio)
            {
                case 1:
                    //HB
                    this.BackColor = Color.SteelBlue;
                    lblNombreServicio.Text = "Servicio: Normal";
                    lblNombreServicio.ForeColor = Color.White;
                    break;

                case 2:
                    //HB
                    this.BackColor = Color.Yellow;
                    lblNombreServicio.Text = "Servicio: HB";
                    lblNombreServicio.ForeColor = Color.Black;
                    break;

                case 3:
                    //Chartes * 29
                    this.BackColor = Color.Cyan;
                    lblNombreServicio.Text = "Servicio: Chartes * 29";
                    lblNombreServicio.ForeColor = Color.Black;
                    break;

                case 4:
                    //Chartes *36
                    this.BackColor = Color.Crimson;
                    lblNombreServicio.Text = "Servicio: Chartes * 36";
                    lblNombreServicio.ForeColor = Color.White;
                    break;
            }

            clsUtil.totPasajerosLeidos = 0;
            Cursor.Current = Cursors.Default;
          
            lblEstadoCabecera.Visible = false;
            lblEstadoDetalle.Visible = false;
            lblEstadoEliminar.Visible = false;

            txtCentro.Text = clsUtil.opCentro;
            txtUsuario.Text = clsUtil.opUsuario;

            VistaPaneles(Paneles.Cabecera);

          
           
        }

        

        enum Paneles
        {
            Cabecera,
            Detalle,
            Eliminar
        };

        Int16 panelSelect = 0;
        private void VistaPaneles(Paneles panel)
        {
            pnlCabecera.Left = 0;
            pnlDetalle.Left = 0;
            pnlError.Left = 0;
            pnlEliminar.Left = 0;

            switch (panel)
            {
                case Paneles.Cabecera:
                    panelSelect = 1;

                    //Paneles
                    pnlCabecera.Visible = true;
                    pnlDetalle.Visible = false;
                    pnlError.Visible = false;
                    pnlEliminar.Visible = false;

                    //Controles
                    if (txtVehiculo.ReadOnly == false)
                    {
                        txtVehiculo.Focus();
                    }
                    else
                    {
                        btnEscanear.Focus();
                    }
                    this.Text = "Control Ticket";
                    break;

                case Paneles.Detalle:
                    panelSelect = 2;

                    //Paneles
                    pnlCabecera.Visible = false;
                    pnlDetalle.Visible = true;
                    pnlError.Visible = false;
                    pnlEliminar.Visible = false;

                    //Controles
                    //this.Text = "Leer Ticket";
                    //txtCodigoBarras.Text = string.Empty;
                    //txtTarifa.Text = string.Empty;
                    txtCodigoBarras.SelectAll();
                    txtCodigoBarras.Focus();
                    break;

                case Paneles.Eliminar:
                    panelSelect = 3;

                    //Paneles
                    pnlCabecera.Visible = false;
                    pnlDetalle.Visible = false;
                    pnlError.Visible = false;
                    pnlEliminar.Visible = true;

                    //Controles
                    this.Text = "Eliminar Ticket";
                    txtCodTicketEliminar.Text = string.Empty;
                    txtCodTicketEliminar.Focus();
                    break;
            }
        }

        #region "Cabecera"

        //1° Vehículo
        private void txtVehiculo_GotFocus(object sender, EventArgs e)
        {
            if (txtVehiculo.ReadOnly == false)
            {
                txtFoco = txtVehiculo;
            }
        }

        private void txtVehiculo_LostFocus(object sender, EventArgs e)
        {
            teclado.Enabled = false;
        }

        private void txtVehiculo_TextChanged(object sender, EventArgs e)
        {
            txtChofer.ReadOnly = true;

            btnEscanear.Enabled = false;
            btnCerrar.Enabled = false;
            btnCancelar.Enabled = false;
            btnBusVacio.Enabled = false;

            if (txtVehiculo.Text.Trim().Length == 0)
            {
                txtNumVehiculo.Text = string.Empty;
                lblNumBus.Text = string.Empty;
            }
        }

        private bool Obtener_Transaccion_Vehiculo(string vehiculo, 
                                                  string transaccion,
                                                  ref Int16 idVehiculo, 
                                                  ref string numUnidad)
        {
            bool correcto = false;

            clsUtil.totPasajerosLeidos = 0;
            wsConsettur.Vehiculo wsVehiculoVal = new ConsetturMobile.wsConsettur.Vehiculo();           
            Int16 accionTransAnt = 0;
            string loginUserTrans = string.Empty;
            string codBarrasChofer = string.Empty;

            //1° OBTENER DATOS TRANSACCIÓN DE VEHÍCULO
            try
            {
                clsUtil.opIdTx = transaccion;
                wsTrasaccion = null;
                wsTrasaccion = wsConsMobile.buscar_tx_control_cabecera(transaccion,
                                                                       clsUtil.opLoginUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);

                Cursor.Current = Cursors.Default;
                txtVehiculo.SelectAll();
                txtVehiculo.Focus();
                btnEscanear.Enabled = false;
                txtChofer.ReadOnly = true;
                return false;
            }

            //2° VERIFICAR TRANSACCIÓN
            Int16 idCentroCP = wsTrasaccion.idCentro;

            if (idCentroCP != 0)
            {
                if (((wsTrasaccion.errNumber == 0) && (clsUtil.opIdCentro != idCentroCP)) ||
                   ((wsTrasaccion.errNumber == -1) && (clsUtil.opIdCentro != idCentroCP) && (wsTrasaccion.mensaje == "Control en proceso por otro usuario")))
                {
                    //2.1° Cerrar transacción anterior y crear una nueva
                    accionTransAnt = 1;
                }

                if ((wsTrasaccion.errNumber == -1) && (clsUtil.opIdCentro == idCentroCP) && (wsTrasaccion.mensaje == "Control en proceso por otro usuario"))
                {
                    //2° Obtener información de transacción anterior para continuar
                    accionTransAnt = 2;
                }
            }
            switch (accionTransAnt)
            {
                case 1:
                    MessageBox.Show("Bus en proceso. Cerrando transacción anterior ...",
                                    clsUtil.TituloAviso,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);

                    //2.1.1° Cerrar transacción anterior
                    CerrarTransaccion(false);
                    NuevoControl();
                    txtVehiculo.Text = vehiculo;

                    //2.1.2° Generar nueva transacción por vehículo
                    try
                    {
                        wsVehiculoVal = wsConsMobile.buscar_vehiculos(vehiculo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(),
                                        clsUtil.TituloAviso,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1);

                        Cursor.Current = Cursors.Default;
                        txtVehiculo.SelectAll();
                        txtVehiculo.Focus();
                        btnEscanear.Enabled = false;
                        txtChofer.ReadOnly = true;
                        return false;
                    }

                    if (wsVehiculoVal.errNumber == -1)
                    {
                        MessageBox.Show(wsVehiculoVal.mensaje,
                                        clsUtil.TituloAviso,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1);

                        Cursor.Current = Cursors.Default;
                        txtVehiculo.SelectAll();
                        txtVehiculo.Focus();
                        btnEscanear.Enabled = false;
                        txtChofer.ReadOnly = true;
                        return false;
                    }

                    if (wsVehiculoVal.marca.Length > 0)
                    {
                        idVehiculo = wsVehiculoVal.idVehiculo;
                        numUnidad = wsVehiculoVal.nroUnidad.Trim();
                        clsUtil.opIdTx = wsVehiculoVal.marca.Trim();
                        wsTrasaccion = null;
                    }

                    break;

                case 2:
                    //2.2.1° Obtener información de transacción en proceso
                    string[] datos;
                    datos = wsTrasaccion.docChofer.Split('|');
                    loginUserTrans = string.Empty;

                    clsUtil.opIdTx = wsTrasaccion.idTx;
                    codBarrasChofer = datos[0].Trim();
                    loginUserTrans = datos[1].Trim();

                    try
                    {
                        wsTrasaccion = null;
                        wsTrasaccion = wsConsMobile.buscar_tx_control_cabecera(clsUtil.opIdTx,
                                                                               loginUserTrans);
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(ex.Message.ToString(),
                                        clsUtil.TituloAviso,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1);
                        return false;
                    }
                    break;
            }

            //3° MOSTRAR INFORMACIÓN DE TRANSACCIÓN
            Int16 idChofer = 0;
            string nombreChofer = string.Empty;

            if ((accionTransAnt == 0) || (accionTransAnt == 2))
            {
                if ((wsTrasaccion.docChofer != null) && (wsTrasaccion.docChofer.Trim().Length != 0))
                {
                    //Vehículo
                    idVehiculo = wsTrasaccion.idVehiculo;
                    vehiculo = wsTrasaccion.placaVehiculo.Trim();
        
                    //Chofer
                    idChofer = wsTrasaccion.idChofer;

                    string[] datos;
                    datos = wsTrasaccion.docChofer.Split('|');

                    if (datos.Length > 0)
                    {
                        codBarrasChofer = datos[0].Trim();
                    }
                    nombreChofer = wsTrasaccion.chofer.Trim();

                    //Tickets Leídos
                    clsUtil.totPasajerosLeidos = 0;

                    //* Detalle
                    if ((wsTrasaccion != null) && (wsTrasaccion.transaccionDetalle != null))
                    {
                        clsUtil.totPasajerosLeidos = wsTrasaccion.transaccionDetalle.ToList().Count;
                    }

                    //* Detalle Varios
                    Int32 pasajeroVarios = 0;
                    if ((wsTrasaccion != null) && (wsTrasaccion.transaccionDetalleVarios != null))
                    {
                        foreach (wsConsettur.TransaccionDetalleVarios item in wsTrasaccion.transaccionDetalleVarios)
                        {
                            pasajeroVarios = pasajeroVarios + item.cantidad;
                        }
                        clsUtil.totPasajerosLeidos = clsUtil.totPasajerosLeidos + pasajeroVarios;
                    }
                }
            }

            //Vehículo
            clsUtil.opIdVehiculo = idVehiculo;
            clsUtil.opCodBarrasVehiculo = vehiculo;
            txtVehiculo.Text = vehiculo;
            txtNumVehiculo.Text = numUnidad;
            lblNumBus.Text = numUnidad;

            //Transacción
            txtNumControl.Text = clsUtil.opIdTx.Trim();

            //Chofer
            clsUtil.opIdChofer = idChofer;
            txtChofer.Text = codBarrasChofer;
            clsUtil.opCodBarrasChofer = codBarrasChofer;
            txtNombreChofer.Text = nombreChofer;
            clsUtil.opNombreChofer = nombreChofer;

           

            //Total Tickets Leídos
            txtTotal.Text = clsUtil.totPasajerosLeidos.ToString();

            Cursor.Current = Cursors.Default;
            correcto = true;

            return correcto;
        }


       

        private void txtVehiculo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                btnEscanear.Enabled = true;
            }
        }

        //2° NumControl
        private void txtNumControl_TextChanged(object sender, EventArgs e)
        {
            txtChofer.ReadOnly = true;

            btnEscanear.Enabled = false;
            btnCerrar.Enabled = false;
            btnCancelar.Enabled = false;

            if (tipoServicio != 1)
            {
                btnBusVacio.Enabled = false;
            }
            else
            {
                btnBusVacio.Enabled = false;
            }
        }

        private void MostrarPanelAviso(bool mostrar, string mensaje)
        {
            lblMensaje.Text = string.Empty;
            pnlError.BackColor = Color.Orange;
            lblMensaje.ForeColor = Color.Black;
            pnlError.Visible = mostrar;
            pnlError.BringToFront();

            if (mostrar)
            {
                lblMensaje.Text = mensaje;
                txtVehiculo.Enabled = false;
            }
            else
            {
                txtVehiculo.Enabled = true;
            }
        }

        private void txtNumControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNumControl.ReadOnly)
            {
                btnEscanear.Focus();
                return;
            }
        }

       

        private void txtChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
               
            }
        }

       

      

        private void txtNombreChofer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
            }
        }

        private void txtCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
            }
        }

        //Botones
        private void NuevoControl()
        {
            pasajerosAdd = false;
            lblMensajesAsientos.Text = string.Empty;
            lblMensajesAsientos.Visible = false;

            lvDetalle.Items.Clear();
            txtTotal.Text = "0";
            clsUtil.totPasajerosLeidos = 0;
            clsUtil.totPasajerosMax = 0;

            txtCodigoBarras.Enabled = true;
            txtCodigoBarras.Text = string.Empty;
            txtCodigoBarras.BackColor = Color.White;

            txtNumControl.Text = string.Empty;
            txtVehiculo.Text = string.Empty;
            txtChofer.Text = string.Empty;

            txtNumControl.ReadOnly = true;
            txtChofer.ReadOnly = true;
            txtVehiculo.ReadOnly = false;

            txtCodigoBarras.Enabled = true;
            btnRegresar.Enabled = true;
            btnEliminar.Enabled = true;

            if (tipoServicio != 1)
            {
                btnOtros.Enabled = false;
            }
            else
            {
                btnOtros.Enabled = true;
            }
            btnCerrarControlTicket.Enabled = true;
            txtVehiculo.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            NuevoControl();
        }

        private void btnEscanear_Click(object sender, EventArgs e)
        {
            lblMensajesAsientos.Text = string.Empty;
            lblMensajesAsientos.Visible = false;

            txtCodigoBarras.Enabled = true;
            btnRegresar.Enabled = true;
            btnEliminar.Enabled = true;
            if (tipoServicio != 1)
            {
                btnOtros.Enabled = false;
            }
            else
            {
                btnOtros.Enabled = true;
            }

            btnCerrarControlTicket.Enabled = true;

            VistaPaneles(Paneles.Detalle);
        }

        bool FlgSubida = false;

        private void CerrarTransaccion(bool mostrarPregunta)
        {
            mensajeError = string.Empty;
            resultado = false;

            if (mostrarPregunta)
            {
                if (MessageBox.Show("¿Desea cerrar el control de tickets?",
                   clsUtil.TituloConfirmacion,
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
            }

            VistaPaneles(Paneles.Cabecera);
            NuevoControl();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            CerrarTransaccion(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cancelar la lectura de tickets realizada?",
                clsUtil.TituloConfirmacion,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del módulo 'Control de Ticket'?",
                clsUtil.TituloConfirmacion,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
               
                this.Dispose();
                this.Close();
            }
        }

        #endregion

        #region "Detalle"

        private void txtCodigoBarras_GotFocus(object sender, EventArgs e)
        {
            txtFoco = txtCodigoBarras;
        }

        private void txtCodigoBarras_LostFocus(object sender, EventArgs e)
        {
            teclado.Enabled = false;
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            txtTarifa.Text = string.Empty;
            btnRegresar.Enabled = true;
            btnEliminar.Enabled = true;
            if (tipoServicio != 1)
            {
                btnOtros.Enabled = false;
            }
            else
            {
                btnOtros.Enabled = true;
            }
            pnlDetalle.BackColor = Color.WhiteSmoke;
        }

        private void ListarDetalle3(string numeroLectura,
                                    string codigoBarras)
        {
            ListViewItem lvItem = new ListViewItem(numeroLectura);
            lvItem.SubItems.Add(codigoBarras);
            lvItem.SubItems.Add(clsUtil.opIdTx);
            lvDetalle.Items.Add(lvItem);
        }

        short numLectura;
        private string mensajePanel = string.Empty;
        private bool resultadoWS = false;
        private bool flgSubido = false;
        private string tarifa = string.Empty;
        private string tipoTarifa = string.Empty;

       

        private void LecturaCodBarras()
        {
            txtCodigoBarras.SelectAll();
            txtCodigoBarras.Focus();
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                LecturaCodBarras();
            }
        }

        
        private void btnCerrarControlTicket_Click(object sender, EventArgs e)
        {
            CerrarTransaccion(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            VistaPaneles(Paneles.Eliminar);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
        
            VistaPaneles(Paneles.Cabecera);
        }

        
        #endregion

   

        private void MostrarPanelError(bool error, string mensaje)
        {
            pnlError.BackColor = Color.Crimson;
            lblMensaje.ForeColor = Color.White;
            pnlError.Visible = error;
            pnlError.BringToFront();

            txtCodigoBarras.Enabled = !error;
            txtTarifa.Enabled = !error;
            lvDetalle.Enabled = !error;
            btnRegresar.Enabled = !error;
            btnEliminar.Enabled = !error;

            if (tipoServicio != 1)
            {
                btnOtros.Enabled = false;
            }
            else
            {
                btnOtros.Enabled = !error;
            }

            if (error)
            {
                lblMensaje.Text = mensaje;

                txtCodigoBarras.SelectAll();
                txtCodigoBarras.Focus();
                btnCerrarError.Focus();
            }
            else
            {
                lblMensaje.Text = string.Empty;
                txtCodigoBarras.SelectAll();
                txtCodigoBarras.Focus();
            }
        }

        private void btnCerrarError_Click(object sender, EventArgs e)
        {
            MostrarPanelError(false, "");
            txtCodigoBarras.SelectAll();
            txtCodigoBarras.Focus();
        }

        

      
      

        

        private void btnteclado_Click(object sender, EventArgs e)
        {
            teclado.Enabled = !teclado.Enabled;

            if (txtFoco != null)
            {
                txtFoco.Focus();
            }
        }

        

     

    }
}