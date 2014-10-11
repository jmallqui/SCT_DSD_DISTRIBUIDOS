using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAgencia.proxyTarifas;

namespace WebAgencia
{
    public partial class Tarifa : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarGrilla();
            }
        }

        void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            cboMoneda.SelectedIndex = 0;         
        }

        void cargarGrilla()
        {
            proxyTarifas.TarifaClient tarifa = new TarifaClient();
            var dato = tarifa.ListarTarifa();
            gvtarifa.DataSource = dato;
            gvtarifa.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";

                proxyTarifas.TarifaClient tarifa = new TarifaClient();
                tarifa.RegistrarTarifa(txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), cboMoneda.SelectedValue);
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error registrar datos :" +  ex.Message;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                proxyTarifas.TarifaClient tarifa = new TarifaClient();
                tarifa.ModificarTarifa(Convert.ToInt32(txtCodigo.Text), txtDescripcion.Text, Convert.ToDecimal(txtPrecio.Text), cboMoneda.SelectedValue);
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar datos : " +  ex.Message;

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                lblMensaje.Text = "";
                int IND_TARIFA = Convert.ToInt32(txtCodigo.Text);
                proxyTarifas.TarifaClient tarifa = new TarifaClient();
                if (tarifa.ObtenerTarifa(IND_TARIFA) == null)
                {
                    lblMensaje.Text = "Tarifa no registrado....";
                }
                else
                {
                    limpiar();
                    tarifa.EliminarTarifa(IND_TARIFA);
                    cargarGrilla();
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se puede eliminar :" + ex.Message;

                limpiar();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                int ID_TARIFA = int.Parse(txtCodigo.Text);
                lblMensaje.Text = "";
                proxyTarifas.TarifaClient tarifa = new TarifaClient();

                var tar = tarifa.ObtenerTarifa(ID_TARIFA);

                if (tar == null)
                {
                    lblMensaje.Text = "Empresa no registrada....";
                }
                else
                {
                    txtDescripcion.Text = tar.NOM_TARIFA.ToString();
                    txtPrecio.Text = tar.PRECIO.ToString();
                    cboMoneda.SelectedValue = tar.MONEDA.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error obtener datos : " + ex.Message;
            }
        }

     

        
    }
}