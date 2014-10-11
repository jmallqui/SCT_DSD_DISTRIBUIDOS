using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCTServiceWCF.Dominio;
using SCTServiceWCF.Persistencia;
using SCTServiceWCF.Servicios;

namespace TestEmpresaService
{
    [TestClass]
    public class CentroTest
    {
        [TestMethod]
        public void CrearCentroTest()
        {
            Centros CentroWS = new Centros();
            Centro resultado = CentroWS.CrearCentro("Aguas Calientes",1);
            Assert.AreEqual("Aguas Calientes", resultado.DESCRIPCION);
        }
        [TestMethod]
        public void ObtenerCentroTest()
        {
            Centros CentroWS = new Centros();
            Centro resultado = CentroWS.ObtenerCentro(1);
            Assert.AreEqual("SANTUARIO", resultado.DESCRIPCION);
        }
        [TestMethod]
        public void ListarCentroTest()
        {
            Centros CentroWS = new Centros();
            List<Centro> resultado = CentroWS.ListarCentro();
            Assert.AreEqual(3, resultado.Count);
        }

    }
}
