using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCTServiceWCF.Dominio;

namespace TestEmpresaService
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CrearEmpresaTest()
        {
            SCTServiceWCF.Servicios.Empresas EmpresaWS = new SCTServiceWCF.Servicios.Empresas();
            Empresa resultado = EmpresaWS.CrearEmpresa("Transporte Cholo", "104343234432", "5643232", "su casa en donde no se");
            Assert.AreEqual("Transporte Cholo", resultado.EMPRESA);            
        }

        [TestMethod]
        public void ModificarEmpresaTest()
        {
            SCTServiceWCF.Servicios.Empresas EmpresaWS = new SCTServiceWCF.Servicios.Empresas();
            Empresa resultado = EmpresaWS.ModificarEmpresa(25, "Empresa el Ande", "343234565675", "453212", "su domicilio");
            Assert.AreEqual("Empresa el Ande", resultado.EMPRESA);
        }
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
        
    }
}
