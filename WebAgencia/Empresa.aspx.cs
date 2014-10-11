using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAgencia.proxyEmpresas;

namespace WebAgencia
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                cargarGrilla();
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtEmpresa.Text.Length == 0)
            {
                lblMensaje.Text = "Ingrese Empresa....";
            }
            else if (txtruc.Text.Length == 0)
            {

                lblMensaje.Text = "Ingrese RUC....";
            }
            else
            {
                try
                {
                    lblMensaje.Text = "";

                    proxyEmpresas.EmpresasClient empresa = new EmpresasClient();

                    txtCodigo.Text = empresa.CrearEmpresa(txtEmpresa.Text, txtruc.Text, txtTelefono.Text, txtDireccion.Text).ID_EMPRESA.ToString();
                    cargarGrilla();
                    limpiar();
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error registrar datos....";


                }
            }
        }

        void limpiar()
        {
            txtCodigo.Text = "";
            txtEmpresa.Text="";
            txtruc.Text="";
            txtTelefono.Text="";
            txtDireccion.Text = "";
        }
        void cargarGrilla()
        {
            proxyEmpresas.EmpresasClient empresa = new EmpresasClient();
            var dato = empresa.ListarEmpresa();

            gvempresa.DataSource = dato;
            gvempresa.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                int codigoEmpr = int.Parse(txtCodigo.Text);
                lblMensaje.Text = "";
                proxyEmpresas.EmpresasClient empresa = new EmpresasClient();

                var emp = empresa.ObtenerEmpresa(codigoEmpr);

                if (emp == null)
                {
                    lblMensaje.Text = "Empresa no registrada....";
                }
                else { 
                txtEmpresa.Text = emp.EMPRESA.ToString();
                txtruc.Text = emp.RUC.ToString();
                txtTelefono.Text = emp.TELEFONO.ToString();
                txtDireccion.Text = emp.DIRECCION.ToString();
                }
            }
            catch (Exception ex)
            {
               
                lblMensaje.Text = "Error obtener datos....";

               
            }

            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                int codigoEmpr = int.Parse(txtCodigo.Text);
                lblMensaje.Text = "";
                proxyEmpresas.EmpresasClient empresa = new EmpresasClient();

                var emp = empresa.ModificarEmpresa(codigoEmpr, txtEmpresa.Text, txtruc.Text, txtTelefono.Text, txtDireccion.Text).ID_EMPRESA.ToString();
                cargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar datos....";
               

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                int codigoEmpr=int.Parse(txtCodigo.Text);                                    
                lblMensaje.Text = "";
                proxyEmpresas.EmpresasClient empresa = new EmpresasClient();
                if (empresa.ObtenerEmpresa(codigoEmpr) == null)
                {
                    lblMensaje.Text = "Empresa no registrado....";
                }
                else
                {
                    empresa.EliminarEmpresa(codigoEmpr);
                    cargarGrilla();
                    limpiar();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se puede eliminar....";

                limpiar();
            }

        }
    }
}