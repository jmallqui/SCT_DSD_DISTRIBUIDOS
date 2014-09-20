using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsetturMobile.Formulario
{
    class clsComentado
    {

        //private void Ejecutar_NumControl()
        //{
        //    mensajeSDF = string.Empty;
        //    resultado = false;

        //    //1° Si tiene contenido
        //    if (txtNumControl.Text.Trim().Length == 0)
        //    {
        //        MessageBox.Show("Ingrese 'N° Control'",
        //                        clsUtil.TituloAviso,
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Exclamation,
        //                        MessageBoxDefaultButton.Button1);
        //        txtNumControl.Focus();

        //        btnEscanear.Enabled = false;
        //        txtVehiculo.ReadOnly = true;
        //        txtChofer.ReadOnly = true;
        //        return;
        //    }

        //    Cursor.Current = Cursors.WaitCursor;

        //    //2° Validar si no hay ningún error

        //    //2.1° Online
        //    try
        //    {
        //        wsTrasaccion = null;
        //        wsTrasaccion = wsConsMobile.buscar_tx_control_cabecera(txtNumControl.Text,
        //                                                               clsUtil.opLoginUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor.Current = Cursors.Default;
        //        MessageBox.Show(ex.Message.ToString(),
        //                        clsUtil.TituloAviso,
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Exclamation,
        //                        MessageBoxDefaultButton.Button1);

        //        txtNumControl.SelectAll();
        //        txtNumControl.Focus();

        //        btnEscanear.Enabled = false;
        //        btnCerrar.Enabled = false;
        //        btnCancelar.Enabled = false;
        //        btnBusVacio.Enabled = false;

        //        txtChofer.ReadOnly = true;
        //        return;
        //    }

        //    //3° Validar si el resultado es correcto
        //    Int16 idCentroCP = wsTrasaccion.idCentro;
        //    string vehiculo = txtVehiculo.Text;

        //    if (wsTrasaccion.errNumber == 0)
        //    {
        //        if (clsUtil.opIdCentro != idCentroCP)
        //        {
        //            //3.1° Si son de diferentes centro -> Cerrar la transacción
        //            Cursor.Current = Cursors.WaitCursor;

        //            MessageBox.Show("Bus en proceso. Cerrando transacción anterior ...",
        //                            clsUtil.TituloAviso,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Exclamation,
        //                            MessageBoxDefaultButton.Button1);
        //            CerrarTransaccion(false);
        //            NuevoControl();
        //            txtVehiculo.Text = vehiculo;
        //            Vehiculo_Enter();

        //            MostrarPanelAviso(false, "");
        //            Cursor.Current = Cursors.Default;
        //        }
        //    }

        //    if (wsTrasaccion.errNumber == -1)
        //    {
        //        if (wsTrasaccion.mensaje != "Control en proceso por otro usuario")
        //        {
        //            //3.1° Si es diferente a 'Control en proceso'
        //            Cursor.Current = Cursors.Default;
        //            MessageBox.Show(wsTrasaccion.mensaje,
        //                            clsUtil.TituloAviso,
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Exclamation,
        //                            MessageBoxDefaultButton.Button1);

        //            txtNumControl.SelectAll();
        //            txtNumControl.Focus();

        //            btnEscanear.Enabled = false;
        //            btnCerrar.Enabled = false;
        //            btnCancelar.Enabled = false;
        //            btnBusVacio.Enabled = false;

        //            txtChofer.ReadOnly = true;
        //            return;
        //        }
        //        else
        //        {
        //            //3.2° Si está en 'Control en proceso'
        //            vehiculo = txtVehiculo.Text;

        //            if (idCentroCP != clsUtil.opIdCentro)
        //            {
        //                //3.3° Si son de diferentes centro -> Cerrar la transacción
        //                Cursor.Current = Cursors.WaitCursor;
        //                MessageBox.Show("Bus en proceso. Cerrando transacción anterior ...",
        //                                clsUtil.TituloAviso,
        //                                MessageBoxButtons.OK,
        //                                MessageBoxIcon.Exclamation,
        //                                MessageBoxDefaultButton.Button1);
        //                CerrarTransaccion(false);
        //                NuevoControl();
        //                txtVehiculo.Text = vehiculo;
        //                Vehiculo_Enter();

        //                MostrarPanelAviso(false, "");
        //                Cursor.Current = Cursors.Default;
        //            }
        //            else
        //            {
        //                //3.3° Si es el mismo centro -> Tomar la información
        //                string[] datos;
        //                datos = wsTrasaccion.docChofer.Split('|');
        //                string loginUserCP = datos[1].Trim();

        //                try
        //                {
        //                    wsTrasaccion = null;
        //                    wsTrasaccion = wsConsMobile.buscar_tx_control_cabecera(txtNumControl.Text,
        //                                                                           loginUserCP);
        //                }
        //                catch (Exception ex)
        //                {
        //                    Cursor.Current = Cursors.Default;
        //                    MessageBox.Show(ex.Message.ToString(),
        //                                    clsUtil.TituloAviso,
        //                                    MessageBoxButtons.OK,
        //                                    MessageBoxIcon.Exclamation,
        //                                    MessageBoxDefaultButton.Button1);

        //                    txtNumControl.SelectAll();
        //                    txtNumControl.Focus();

        //                    btnEscanear.Enabled = false;
        //                    btnCerrar.Enabled = false;
        //                    btnCancelar.Enabled = false;
        //                    btnBusVacio.Enabled = false;

        //                    txtChofer.ReadOnly = true;
        //                    return;
        //                }
        //            }
        //        }
        //    }

        //    //4° Es correcto 
        //    clsUtil.opIdTx = txtNumControl.Text.Trim();
        //    txtNumControl.Text = txtNumControl.Text.Trim();
        //    pasajerosAdd = false;

        //    if (wsTrasaccion.docChofer.Trim().Length != 0)
        //    {
        //        //Colocar valores

        //        //Vehículo
        //        clsUtil.opIdVehiculo = wsTrasaccion.idVehiculo;
        //        txtVehiculo.Text = wsTrasaccion.placaVehiculo;
        //        clsUtil.opCodBarrasVehiculo = txtVehiculo.Text;

        //        //Chofer
        //        clsUtil.opIdChofer = wsTrasaccion.idChofer;
        //        txtChofer.Text = wsTrasaccion.docChofer;
        //        clsUtil.opCodBarrasChofer = txtChofer.Text;
        //        txtNombreChofer.Text = wsTrasaccion.chofer;
        //        clsUtil.opNombreChofer = txtNombreChofer.Text;

        //        GuardarCabecera();

        //        txtNumControl.ReadOnly = true;
        //        txtVehiculo.ReadOnly = true;
        //        txtChofer.ReadOnly = true;

        //        btnEscanear.Enabled = true;
        //        btnCerrar.Enabled = true;
        //        btnCancelar.Enabled = true;

        //        if (tipoServicio != 1)
        //        {
        //            btnBusVacio.Enabled = false;
        //        }
        //        else
        //        {
        //            btnBusVacio.Enabled = true;
        //        }

        //        Cursor.Current = Cursors.Default;
        //        btnEscanear.Focus();
        //    }
        //    else
        //    {
        //        txtChofer.ReadOnly = false;
        //        txtChofer.SelectAll();
        //        txtChofer.Focus();
        //    }

        //    //4.3° Mostrar los controles
        //    Cursor.Current = Cursors.Default;

        //    return;
        //}


        //FORMULARIO : CONTROL DE TICKET

        //private void ListarDetalle(bool desdeBD)
        //{
        //    lvDetalle.Items.Clear();

        //    if ((desdeBD) && (clsUtil.online))
        //    {
        //        //Filtrado desde WS
        //        if (!(clsUtil.wsListaTransaccDet == null))
        //        {
        //            lvDetalle.Items.Clear();
        //            foreach (var itemLista in clsUtil.wsListaTransaccDet)
        //            {
        //                ListViewItem lvItem = new ListViewItem(itemLista.nroLectura.ToString());
        //                lvItem.SubItems.Add(itemLista.codigoBarrasTicket);
        //                lvItem.SubItems.Add(clsUtil.opIdTx);
        //                lvDetalle.Items.Add(lvItem);
        //            }
        //        }

        //        txtTotal.Text = lvDetalle.Items.Count.ToString();
        //        return;
        //    }

        //    if ((desdeBD == false) || (clsUtil.online == false))
        //    {
        //        //Filtrado desde SDF
        //        resultado = false;

        //        List<beTransaccionDetalle> listabeTransaccionDetalle = new List<beTransaccionDetalle>();
        //        resultado = oblTransacDet.Listar_Detalle(clsUtil.opIdTx,
        //                                                 ref mensajeError,
        //                                                 ref listabeTransaccionDetalle);

        //        if (resultado)
        //        {
        //            lvDetalle.Items.Clear();
        //            foreach (beTransaccionDetalle itemLista in listabeTransaccionDetalle)
        //            {
        //                ListViewItem lvItem = new ListViewItem(itemLista.NumLectura.ToString());
        //                lvItem.SubItems.Add(itemLista.CodBaraTicket);
        //                lvItem.SubItems.Add(clsUtil.opIdTx);

        //                if (itemLista.FlgSubida == false)
        //                {
        //                    lvItem.BackColor = Color.Crimson;
        //                    lvItem.ForeColor = Color.White;
        //                }
        //                else
        //                {
        //                    lvItem.BackColor = Color.White;
        //                    lvItem.ForeColor = Color.Black;
        //                }
        //                lvDetalle.Items.Add(lvItem);
        //            }
        //        }
        //        txtTotal.Text = lvDetalle.Items.Count.ToString();
        //    }
        //}


        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (lblMensajesAsientos.BackColor == Color.Red)
        //    {
        //        lblMensajesAsientos.BackColor = Color.White;
        //        lblMensajesAsientos.ForeColor = Color.Red;
        //    }
        //    else
        //    {
        //        lblMensajesAsientos.BackColor = Color.Red;
        //        lblMensajesAsientos.ForeColor = Color.White;
        //    }
        //}



        //private void ListarDetalle2()
        //{
        //    //lvDetalle.Items.Clear();
        //    //txtTotal.Text = lvDetalle.Items.Count.ToString();
        //    //totalLeido = lvDetalle.Items.Count;
        //    //List<wsConsettur.TransaccionDetalle> wsListaTransaccDet = new List<wsConsettur.TransaccionDetalle>();

        //    ////° ONLINE (WS)
        //    //if (clsUtil.online)
        //    //{
        //    //    wsConsettur.Transaccion wsTrasaccion = new ConsetturMobile.wsConsettur.Transaccion();
        //    //    wsTrasaccion = null;

        //    //    try
        //    //    {
        //    //        wsTrasaccion = wsConsMobile.buscar_tx_control_cabecera(clsUtil.opIdTx,
        //    //                                                               clsUtil.opLoginUser);
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        MessageBox.Show(ex.Message,
        //    //                        clsUtil.TituloAviso,
        //    //                        MessageBoxButtons.OK,
        //    //                        MessageBoxIcon.Exclamation,
        //    //                        MessageBoxDefaultButton.Button1);
        //    //    }

        //    //    wsListaTransaccDet = null;
        //    //    if (!(wsTrasaccion.transaccionDetalle == null))
        //    //    {
        //    //        wsListaTransaccDet = wsTrasaccion.transaccionDetalle.ToList();
        //    //    }

        //    //    if (!(wsListaTransaccDet == null))
        //    //    {
        //    //        lvDetalle.Items.Clear();
        //    //        foreach (var itemLista in wsListaTransaccDet)
        //    //        {
        //    //            ListViewItem lvItem = new ListViewItem(itemLista.nroLectura.ToString());
        //    //            lvItem.SubItems.Add(itemLista.codigoBarrasTicket);
        //    //            lvItem.SubItems.Add(clsUtil.opIdTx);
        //    //            lvDetalle.Items.Add(lvItem);
        //    //        }
        //    //    }

        //    //    if (lvDetalle.Items.Count == 0)
        //    //    {
        //    //        btnEliminar.Enabled = false;
        //    //    }
        //    //    else
        //    //    {
        //    //        btnEliminar.Enabled = true;
        //    //    }
        //    //    totalLeido = lvDetalle.Items.Count;
        //    //    txtTotal.Text = lvDetalle.Items.Count.ToString();
        //    //    return;
        //    //}

        //    ////2° OFFLINE (SDF)
        //    //resultado = false;

        //    List<beTransaccionDetalle> listabeTransaccionDetalle = new List<beTransaccionDetalle>();
        //    resultado = oblTransacDet.Listar_Detalle(clsUtil.opIdTx,
        //                                             ref mensajeError,
        //                                             ref listabeTransaccionDetalle);

        //    if (resultado)
        //    {
        //        lvDetalle.Items.Clear();
        //        foreach (beTransaccionDetalle itemLista in listabeTransaccionDetalle)
        //        {
        //            ListViewItem lvItem = new ListViewItem(itemLista.NumLectura.ToString());
        //            lvItem.SubItems.Add(itemLista.CodBaraTicket);
        //            lvItem.SubItems.Add(clsUtil.opIdTx);

        //            if (itemLista.FlgSubida == false)
        //            {
        //                lvItem.BackColor = Color.Crimson;
        //                lvItem.ForeColor = Color.White;
        //            }
        //            else
        //            {
        //                lvItem.BackColor = Color.White;
        //                lvItem.ForeColor = Color.Black;
        //            }
        //            lvDetalle.Items.Add(lvItem);
        //        }
        //    }
        //    totalLeido = lvDetalle.Items.Count;
        //    txtTotal.Text = lvDetalle.Items.Count.ToString();
        //}


    }
}
