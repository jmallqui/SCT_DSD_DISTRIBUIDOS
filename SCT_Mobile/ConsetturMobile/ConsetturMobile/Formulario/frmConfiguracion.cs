using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConsetturMobile
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        #region "Variables"

        string mensaje = string.Empty;
        bool sinClave = false;

        #endregion

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            txtTiempo.Text = "1";

            bool existeXML = File.Exists(clsConfiguracion.fileXml);
            if (existeXML == false)
            {
                sinClave = true;
                VistaPaneles(Paneles.Parametros);
            }
            else
            {
                VistaPaneles(Paneles.Clave);
            }
        }

        enum Paneles
        {
            Clave,
            Parametros
        };

        private void VistaPaneles(Paneles panel)
        {
            pnlClave.Left = 0;
            pnlParametros.Left = 0;

            switch (panel)
            {
                case Paneles.Clave:
                    //Paneles
                    pnlClave.Visible = true;
                    pnlParametros.Visible = false;

                    //Controles
                    txtContraseña.Text = string.Empty;
                    txtContraseña.Focus();

                    this.Text = "Acceso Configuración";
                    break;

                case Paneles.Parametros:
                    //Paneles
                    pnlClave.Visible = false;
                    pnlParametros.Visible = true;

                    //Controles
                    txtWebService.Focus();

                    this.Text = "Parámetros";
                    break;
            }
        }

        #region "Clave"

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                AccesoConfiguracion();
            }
        }

        private void btnAceptarAcceso_Click(object sender, EventArgs e)
        {
            AccesoConfiguracion();
        }

        private void AccesoConfiguracion()
        {
            //°1 Validar contenido 
            if (txtContraseña.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese la contraseña",
                               clsUtil.TituloAviso,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1);
                txtContraseña.Focus();
                return;
            }

            //°2 Obtener valores 
            string contraseña = txtContraseña.Text.Trim().ToUpper();
            Int16 resultado = clsConfiguracion.Registrado(contraseña);

            switch (resultado)
            {
                case 1:
                    MessageBox.Show("Error al buscar el archivo xml",
                                    clsUtil.TituloAviso,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);
                    break;

                case 2:
                    //Obtener datos de la url
                    string url = string.Empty;
                    string tiempo = string.Empty;

                    if (clsConfiguracion.ObtenerDatos(ref url,
                                                      ref tiempo))
                    {
                        Int32 tiempoConvert = 0;
                        if (tiempo.Trim().Length > 0)
                        {
                            tiempoConvert = Convert.ToInt32(tiempo) / 1000;
                        }
                        txtWebService.Text = url;
                        txtTiempo.Text = tiempoConvert.ToString();
                    }
                    else
                    {
                        txtWebService.Text = string.Empty;
                        txtTiempo.Text = string.Empty;
                    }
                    VistaPaneles(Paneles.Parametros);
                    break;

                case 3:
                    MessageBox.Show("Contraseña no válida",
                                    clsUtil.TituloAviso,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);
                    txtContraseña.SelectAll();
                    txtContraseña.Focus();
                    break;

                case 4:
                    sinClave = true;
                    VistaPaneles(Paneles.Parametros);
                    break;
            }
        }

        private void btnCancelarAcceso_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del módulo 'Configuración de Parámetros'?",
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

        #region "Parametros"

        private void txtWebService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                txtTiempo.Focus();
            }
        }

        private void txtTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsNumero clsNum = new ClsNumero();
            clsNum.NumDecimales = 0;
            clsNum.NumEnteros = 5;
            clsNum.PosicionCursor = ((TextBox)sender).SelectionStart;
            clsNum.SeleccionCursor = ((TextBox)sender).SelectionLength;
            e.Handled = clsNum.esNumero(((TextBox)sender).Text, Convert.ToInt32(e.KeyChar));

            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                txtNuevaContrasenia.Focus();
            }
        }

        private void txtNuevaContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                GrabarParametros();
            }
        }

        private void btnGrabarParametros_Click(object sender, EventArgs e)
        {
            GrabarParametros();
        }

        private void GrabarParametros()
        {
            int tiempo = 0;
            string linkWs = string.Empty;
            string nuevaClave = string.Empty;
            bool resultado = false;
            mensaje = string.Empty;

            //1° Validar contenido
            if (txtWebService.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese la URL del servicio web",
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                txtWebService.Focus();
                return;
            }

            if (txtTiempo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese tiempo de sincronización",
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                txtTiempo.Focus();
                return;
            }

            tiempo = Convert.ToInt32(txtTiempo.Text.Trim());

            if (tiempo == 0)
            {
                MessageBox.Show("El valor del tiempo debe ser mayor a 0",
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                txtTiempo.Focus();
                return;
            }

            if (sinClave)
            {
                if (txtNuevaContrasenia.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese contraseña para configuración",
                                    clsUtil.TituloAviso,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk,
                                    MessageBoxDefaultButton.Button1);
                    txtNuevaContrasenia.Focus();
                    return;
                }
            }


            //2° Grabar parámetros
            Cursor.Current = Cursors.WaitCursor;

            tiempo = tiempo * 1000;
            linkWs = txtWebService.Text.Trim();
            if (txtNuevaContrasenia.Text.Trim().Length > 0)
            {
                nuevaClave = txtNuevaContrasenia.Text.Trim();
            }

            resultado = clsConfiguracion.EscribirDatos(nuevaClave,
                                                       linkWs,
                                                       tiempo.ToString(),
                                                       ref mensaje);
            if (resultado)
            {
                MessageBox.Show("Parámetros guardados correctamente",
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk,
                                MessageBoxDefaultButton.Button1);
                VistaPaneles(Paneles.Clave);
            }
            else
            {
                MessageBox.Show(mensaje,
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
            }

            Cursor.Current = Cursors.Default;
        }

        private void btnCancelarParametros_Click(object sender, EventArgs e)
        {
            VistaPaneles(Paneles.Clave);
        }

        #endregion

        private void frmConfiguracion_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

    }
}