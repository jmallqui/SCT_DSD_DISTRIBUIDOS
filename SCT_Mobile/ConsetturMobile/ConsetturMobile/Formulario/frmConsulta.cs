using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ConsetturMobile.MonitorBaseDatos;

namespace ConsetturMobile
{
   //public partial class frmConsulta : frmMonitorBase
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        #region "Variables"

        wsConsettur.WsMobile wsConsMobile = new ConsetturMobile.wsConsettur.WsMobile();
        string mensajeWS = string.Empty;

        #endregion

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;

            wsConsMobile.Url = clsUtil.rutaWS;
            lblEstadoConsulta.Visible = false;

            //1° Verificar Online / Offline
            //base.ConfigurarMonitor();
            //ActualizarEstado();

            //2° Cargar centros
            cboCentros.DisplayMember = "centro";
            cboCentros.ValueMember = "idcentro";
            cboCentros.DataSource = clsUtil.listaCentros;

            //3° Controles
            dtpFecha.Value = DateTime.Now;
            cboCentros.Focus();
        }

        //protected override void ActualizarEstado()
        //{
        //    if (clsUtil.online)
        //    {
        //        lblEstadoConsulta.ForeColor = Color.Green;
        //        lblEstadoConsulta.Text = "Online";
        //    }
        //    else
        //    {
        //        lblEstadoConsulta.ForeColor = Color.Crimson;
        //        lblEstadoConsulta.Text = "Offline";
        //    }
        //}

        private void cboCentros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                dtpFecha.Focus();
            }
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                btnListar.Focus();
            }
        }

        private void HabControles(bool hab)
        {
            cboCentros.Enabled = hab;
            dtpFecha.Enabled = hab;
            btnListar.Enabled = hab;
            btnSalir.Enabled = hab;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Int32 subTotal = 0;
            Int32 total = 0;

            Int32 totalTickets = 0;
            Int32 totalOtros = 0;

            //1° Validar
            if (cboCentros.Items.Count == 0)
            {
                MessageBox.Show("Cargar centros desde 'Módulo Acceso'",
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                cboCentros.Focus();
                return;
            }

            if (cboCentros.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un centro",
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                cboCentros.Focus();
                return;
            }

            //2° Listar
            Cursor.Current = Cursors.WaitCursor;
            HabControles(false);

            Int16 idCentro = Convert.ToInt16(cboCentros.SelectedValue);
            string fecha = dtpFecha.Value.ToString("yyyyMMdd");
            List<wsConsettur.ResumenLectura> listado = new List<ConsetturMobile.wsConsettur.ResumenLectura>();
            lvDetalle.Items.Clear();

            bool huboError = false;
            try
            {
                listado = wsConsMobile.consulta_embarques(idCentro, fecha).ToList();
            }
            catch (Exception ex)
            {
                huboError = true;
                wsConsMobile = new ConsetturMobile.wsConsettur.WsMobile();
                MessageBox.Show(ex.Message,
                                clsUtil.TituloAviso,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);

                Cursor.Current = Cursors.Default;
                HabControles(true);
            }

            //3° Mostrar datos
            if (huboError)
            {
                txtViajes.Text = "0";
                Cursor.Current = Cursors.Default;
                HabControles(true);
            }
            else
            {
                if (!(listado == null) && (listado.Count > 0))
                {
                    subTotal = 0;
                    total = 0;
                    totalTickets = 0;
                    totalOtros = 0;

                    foreach (wsConsettur.ResumenLectura item in listado)
                    {
                        ListViewItem lvItem = new ListViewItem(item.contador.ToString());
                        lvItem.SubItems.Add(item.idTx);
                        lvItem.SubItems.Add(item.fecha);
                        lvItem.SubItems.Add(item.horaInicio);
                        lvItem.SubItems.Add(item.horaFin);
                        lvItem.SubItems.Add(item.tiempo);
                        lvItem.SubItems.Add(item.cantidad.ToString());
                        lvItem.SubItems.Add(item.pax.ToString());

                        subTotal = item.cantidad + item.pax;
                        lvItem.SubItems.Add(subTotal.ToString());

                        lvItem.SubItems.Add(item.nroUnidad);
                        lvItem.SubItems.Add(item.placa);
                        lvItem.SubItems.Add(item.conductor);
                        lvItem.SubItems.Add(item.usuario);
                        lvItem.SubItems.Add(item.estado);
                        lvDetalle.Items.Add(lvItem);

                        totalTickets = totalTickets + item.cantidad;
                        totalOtros = totalOtros + item.pax;

                        total = total + subTotal;
                    }
                }

                txtTotalTickets.Text = totalTickets.ToString();
                txtTotalPax.Text = totalOtros.ToString();

                txtViajes.Text = lvDetalle.Items.Count.ToString();
                txtTotalPasajeros.Text = total.ToString();

                Cursor.Current = Cursors.Default;
                HabControles(true);
            }
            Cursor.Current = Cursors.Default;
            HabControles(true);
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                btnListar.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del 'Módulo Consulta'?",
                clsUtil.TituloConfirmacion,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
            }
        }

        private void frmConsulta_Closing(object sender, CancelEventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }
    }
}