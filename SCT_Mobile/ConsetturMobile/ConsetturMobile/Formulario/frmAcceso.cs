using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConsetturCompartido;
using ConsetturMobile.MonitorBaseDatos;
using System.IO;
using ConsetturBussinessEntity;
using ConsetturBussinessLogic;

namespace ConsetturMobile
{
    public partial class frmAcceso : Form
    {
        public frmAcceso()
        {
            InitializeComponent();
        }

        #region "Variables"

        string url = string.Empty;
        string tiempo = string.Empty;
        wsConsettur.WsMobile wsConsMobile = new ConsetturMobile.wsConsettur.WsMobile();
        TextBox txtFoco;

        #endregion

        private void frmAcceso_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            teclado.Enabled = false;

            lblEstadoAcceso.Visible = false;
            lblEstadoCentros.Visible = false;
            lblEstadoMenu.Visible = false;

            //if (clsConfiguracion.ObtenerDatos(ref url,
            //                                  ref tiempo))
            //{
            //    clsUtil.rutaWS = url;
            //    clsUtil.tiempo = Convert.ToInt32(tiempo);

            //    //1° Verificar Online / Offline
            //    base.ConfigurarMonitor();
            //}

            //ActualizarEstado();

            //2° Otros
            VistaPaneles(Paneles.Acceso);
        }

        //protected override void ActualizarEstado()
        //{
        //    if (clsUtil.online)
        //    {
        //        lblEstadoAcceso.ForeColor = Color.Green;
        //        lblEstadoCentros.ForeColor = Color.Green;
        //        lblEstadoMenu.ForeColor = Color.Green;

        //        lblEstadoAcceso.Text = "Online";
        //        lblEstadoCentros.Text = "Online";
        //        lblEstadoMenu.Text = "Online";
        //    }
        //    else
        //    {
        //        lblEstadoAcceso.ForeColor = Color.Crimson;
        //        lblEstadoCentros.ForeColor = Color.Crimson;
        //        lblEstadoMenu.ForeColor = Color.Crimson;

        //        lblEstadoAcceso.Text = "Offline";
        //        lblEstadoCentros.Text = "Offline";
        //        lblEstadoMenu.Text = "Offline";
        //    }
        //}

        private void frmAcceso_Activated(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtUsuario.SelectAll();
            txtUsuario.Focus();
        }

        enum Paneles
        {
            Acceso,
            Centros,
            Menu,
            Servicio
        };

        private void VistaPaneles(Paneles panel)
        {
            pnlAcceso.Left = 0;
            pnlCentros.Left = 0;
            pnlMenu.Left = 0;
          
            switch (panel)
            {
                case Paneles.Acceso:
                    //Paneles
                    pnlAcceso.Visible = true;
                    pnlCentros.Visible = false;
                    pnlMenu.Visible = false;
                    
                    //Botones
                    btnteclado.Visible = true;
                    btnSalirServicio.Visible = false;
                    txtUsuario.Text = string.Empty;
                    txtContrasena.Text = string.Empty;
                    txtUsuario.SelectAll();
                    txtUsuario.Focus();

                    this.Text = "Acceso";
                    break;

                case Paneles.Centros:
                    //Paneles
                    pnlAcceso.Visible = true;
                    pnlCentros.Visible = true;
                    pnlMenu.Visible = false;
                    pnlCentros.BringToFront();

                    //Botones
                    btnteclado.Visible = false;
                    btnSalirServicio.Visible = false;
                    teclado.Enabled = false;
                    this.Text = "Centros";
                    lbCentros.Focus();
                    break;

                case Paneles.Menu:
                    //Paneles
                    pnlAcceso.Visible = true;
                    pnlCentros.Visible = false;
                    pnlMenu.Visible = true;
                    pnlMenu.BringToFront();

                    //Botones
                    btnteclado.Visible = false;
                    btnSalirServicio.Visible = false;
                    teclado.Enabled = false;
                    btnControlTicket.Focus();

                    this.Text = "Menú Principal";
                    break;

                case Paneles.Servicio:
                    //Paneles
                    pnlAcceso.Visible = true;
                    pnlCentros.Visible = false;
                    pnlMenu.Visible = false;
          
                    btnteclado.Visible = false;
                    btnSalirServicio.Visible = true;
                    this.Text = "Tipo de Servicio";
                    break;
            }
        }

        #region "Acceso"

        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if ((pnlCentros.Visible == false) && (pnlMenu.Visible == false) )
            {
                Cursor.Current = Cursors.WaitCursor;

                frmConfiguracion frm = new frmConfiguracion();
                frm.Show();

                Cursor.Current = Cursors.Default;
            }
        }

        private void txtUsuario_GotFocus(object sender, EventArgs e)
        {
            txtFoco = txtUsuario;
        }

        private void txtUsuario_LostFocus(object sender, EventArgs e)
        {
            teclado.Enabled = false;
        }

        private void txtContrasena_GotFocus(object sender, EventArgs e)
        {
            txtFoco = txtContrasena;
        }

        private void txtContrasena_LostFocus(object sender, EventArgs e)
        {
            teclado.Enabled = false;
        }

        private void frmAcceso_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void btnteclado_Click(object sender, EventArgs e)
        {
            teclado.Enabled = !teclado.Enabled;

            string nombre = string.Empty;
            if (txtFoco != null)
            {
                txtFoco.Focus();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                txtContrasena.Focus();
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != Convert.ToChar(Keys.Enter)))
            {
                return;
            }
            btnAceptar.Focus();
            ValidarUsuario();
        }

        private void ValidarUsuario()
        {
          
            VistaPaneles(Paneles.Centros);
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void CargarOtrosPasajeros()
        {
            bool resultado = false;
            string mensajeSDF = string.Empty;
            blOtroPasajero oblOtroPasajero = new blOtroPasajero();

            //1° Verificar en el WS
            wsConsettur.OtrosPasajeros[] wsListaTipoPasajeros = null;
            try
            {
                wsListaTipoPasajeros = wsConsMobile.listar_otros_pasajeros("");
            }
            catch
            {
                return;
            }

            //2° Verificar en el WS
            List<beOtrosPasajeros> listabeOtrosPasajeros = new List<beOtrosPasajeros>();
            beOtrosPasajeros obeOtrosPasajeros = null;

            foreach (var item in wsListaTipoPasajeros)
            {
                obeOtrosPasajeros = new beOtrosPasajeros();
                obeOtrosPasajeros.IdVarios = item.idVarios;
                obeOtrosPasajeros.DescVarios = item.descripcion;
                listabeOtrosPasajeros.Add(obeOtrosPasajeros);
            }

            resultado = oblOtroPasajero.Registrar_OtrosPasajeros(listabeOtrosPasajeros,
                                                                 ref mensajeSDF);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?",
                clsUtil.TituloConfirmacion,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
                //this.Dispose();
                //this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        #endregion

        #region "Centros"

        private void btnContinuar_Click(object sender, EventArgs e)
        {

            VistaPaneles(Paneles.Menu);
        }

        private void btnCancelarCentro_Click(object sender, EventArgs e)
        {
            VistaPaneles(Paneles.Acceso);
        }

        #endregion

        #region "MenuPrincipal"

        private void btnControlTicket_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            frmControlTicket frm = new frmControlTicket();
            frm.tipoServicio = 1; //Normal
            frm.Show();

            btnControlTicket.Enabled = true;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = true;
            btnSalir.Enabled = true;

            Cursor.Current = Cursors.Default;            
        }

      

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            

            Cursor.Current = Cursors.WaitCursor;

            btnControlTicket.Enabled = false;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = false;
            btnSalir.Enabled = false;

            frmConsulta frm = new frmConsulta();
            frm.Show();

            btnControlTicket.Enabled = true;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = true;
            btnSalir.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            VistaPaneles(Paneles.Centros);
        }

        #endregion

        #region "TipoServicio"

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (btnControlTicket.Enabled == false)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            btnControlTicket.Enabled = false;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = false;
            btnSalir.Enabled = false;

            frmControlTicket frm = new frmControlTicket();
            frm.tipoServicio = 1; //Normal
            frm.Show();

            btnControlTicket.Enabled = true;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = true;
            btnSalir.Enabled = true;

            Cursor.Current = Cursors.Default;            
        }

        private void btnBT_Click(object sender, EventArgs e)
        {
            if (btnControlTicket.Enabled == false)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            btnControlTicket.Enabled = false;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = false;
            btnSalir.Enabled = false;

            frmControlTicket frm = new frmControlTicket();
            frm.tipoServicio = 2; //BT
            frm.Show();

            btnControlTicket.Enabled = true;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = true;
            btnSalir.Enabled = true;

            Cursor.Current = Cursors.Default;  
        }

        private void btnChartes29_Click(object sender, EventArgs e)
        {
            if (btnControlTicket.Enabled == false)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            btnControlTicket.Enabled = false;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = false;
            btnSalir.Enabled = false;

            frmControlTicket frm = new frmControlTicket();
            frm.tipoServicio = 3; //Chartes 29
            frm.Show();

            btnControlTicket.Enabled = true;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = true;
            btnSalir.Enabled = true;

            Cursor.Current = Cursors.Default;  
        }

        private void btnChartes36_Click(object sender, EventArgs e)
        {
            if (btnControlTicket.Enabled == false)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            btnControlTicket.Enabled = false;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = false;
            btnSalir.Enabled = false;

            frmControlTicket frm = new frmControlTicket();
            frm.tipoServicio = 4; //Chartes 36
            frm.Show();

            btnControlTicket.Enabled = true;
            btnSincronizar.Enabled = false;
            btnConsultas.Enabled = true;
            btnSalir.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        #endregion

        private void btnSalirServicio_Click(object sender, EventArgs e)
        {
            VistaPaneles(Paneles.Menu);
        }

      
    }
}