using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAgencia.proxyCentros;
using System.Xml;

namespace WebAgencia
{
    public partial class Centro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarGrilla();
            }
            
            proxyEmpresas.EmpresasClient ct = new proxyEmpresas.EmpresasClient();    
            var str = ct.ListarEmpresa();         
            DropDownList1.Items.Add("-Select-");            
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(ToString(str));
            //XmlNodeList nodes = doc.DocumentElement.SelectNodes("//Table");        
            //foreach (XmlNode node in nodes)
            //{
            //    DropDownList1.Items.Add(node["Name"].InnerText);
            //}
            DropDownList1.DataSource = str;
            DropDownList1.Items.Add("EMPRESA");
        }
        void cargarGrilla()
        {
            proxyCentros.CentroClient centro = new CentroClient();
            var dato = centro.ListarCentro();
            gvCentro.DataSource = dato;
            gvCentro.DataBind();
        }

        void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
           
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";

                proxyCentros.CentroClient centro = new CentroClient();
                centro.CrearCentro(txtDescripcion.Text, Convert.ToInt16(DropDownList1.SelectedValue));
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error registrar datos :" + ex.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                int codigoCent = int.Parse(txtCodigo.Text);
                lblMensaje.Text = "";
                proxyCentros.CentroClient centro = new CentroClient();

                var cen = centro.ModificarCentro(codigoCent, txtDescripcion.Text, Convert.ToInt16(DropDownList1.SelectedValue)).ID_CENTRO.ToString();
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar datos....";


            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                int codigoCen = int.Parse(txtCodigo.Text);
                lblMensaje.Text = "";
                proxyCentros.CentroClient centro = new CentroClient();

                var cen = centro.ObtenerCentro(codigoCen);

                if (cen == null)
                {
                    lblMensaje.Text = "Centro no registrado....";
                }
                else
                {
                    txtDescripcion.Text = cen.DESCRIPCION.ToString();
                    DropDownList1.SelectedValue = cen.EMPRESA.ToString();
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error obtener datos....";


            }
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

    }
}