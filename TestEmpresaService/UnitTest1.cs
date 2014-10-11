using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCTServiceWCF.Dominio;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace TestEmpresaService
{
    [TestClass]
    public class UnitTest1
    {
        /*
        [TestMethod]
        public void CrearEmpresaTest()
        {
            SCTServiceWCF.Servicios.Empresas EmpresaWS = new SCTServiceWCF.Servicios.Empresas();
            Empresa resultado = EmpresaWS.CrearEmpresa("Transporte Cholo", "104343234432", "5643232", "su casa en donde no se");
            Assert.AreEqual("Transporte Cholo", resultado.EMPRESA);            
        }*/

        //[TestMethod]
        //public void ModificarEmpresaTest()
        //{
        //    SCTServiceWCF.Servicios.Empresas EmpresaWS = new SCTServiceWCF.Servicios.Empresas();
        //    Empresa resultado = EmpresaWS.ModificarEmpresa(24, "Empresa el Ande", "343234565675", "453212", "su domicilio");
        //    Assert.AreEqual("Empresa el Ande", resultado.EMPRESA);
        //}

        /*
        [TestMethod]
        public void EliminarEmpresaTest()
        {
            SCTServiceWCF.Servicios.Empresas EmpresaWS = new SCTServiceWCF.Servicios.Empresas();
            EmpresaWS.EliminarEmpresa(24);
          
           // Assert.AreEqual(null, resultado);
        }
        [TestMethod]
        public void ListarEmpresaTest()
        {
            SCTServiceWCF.Servicios.Empresas EmpresaWS = new SCTServiceWCF.Servicios.Empresas();
            List<Empresa> resultado = EmpresaWS.ListarEmpresa();
            Assert.AreEqual(8, resultado.Count);
        }
        */

        //obtenber de alumno GET
        [TestMethod]
        public void CRUDTest()
        {
            HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost:20001/Servicios/ControlBoletos.svc/Control/100990010000000001");
            req2.Method = "GET";
            HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();
            StreamReader reader2 = new StreamReader(res2.GetResponseStream());
            string alumnoJson = reader2.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Tickets tk = js2.Deserialize<Tickets>(alumnoJson);
            Assert.AreEqual("101010010001949765", tk.COD_BARRA_TICKET);

            //Alumno almunoObtenido = js2.Deserialize<Alumno>(alumnoJson);
            //Assert.AreEqual("1", almunoObtenido.Codigo);
            //Assert.AreEqual("Juan", almunoObtenido.Nombre);
        }
    }
}
