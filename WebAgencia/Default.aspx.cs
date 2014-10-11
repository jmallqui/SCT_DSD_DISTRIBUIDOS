using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace WebAgencia
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                cargarGrilla();
            }
        }

        void cargarGrilla()
        {
            //proxyEmpresas.EmpresasClient empresa = new EmpresasClient();
            //var dato = empresa.ListarEmpresa();


            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/SCTServiceWCF/Servicios/ControlBoletos.svc/Controles");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            //Tickets tk = js2.Deserialize<Tickets>(alumnoJson);

            //Deserialize<List<BigCommerceOrderProduct>>(jsonData);
            var dato = js2.Deserialize<List<Tickets>>(alumnoJson);
            grdTickets.DataSource = dato;
            grdTickets.DataBind();
        }
    }

    public class Tickets
    {

       
        public string COD_BARRA_TICKET { get; set; }
        
        public string NOM_TARIFA { get; set; }

       
        public string FEC_REGISTRO { get; set; }

       
        public string PUNTO_VENTA { get; set; }
        
        public string MENSAJE { get; set; }
        
        public int ERRNUMBER { get; set; }






    }
}