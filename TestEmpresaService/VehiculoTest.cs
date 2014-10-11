using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCTServiceWCF.Dominio;
using SCTServiceWCF.Servicios;


namespace TestEmpresaService
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        public void CrearVehiculoTest()
        {
            Vehiculos VehiculoWS = new Vehiculos();
            Vehiculo resultado = VehiculoWS.CrearVehiculo("WK-8988", "bb", "bb", "bb", "bb", 11);
            Assert.AreEqual(11, resultado.ID_EMPRESA);
        }


        [TestMethod]
        public void ObtenerVehiculoTest()
        {
            Vehiculos VehiculoWS = new Vehiculos();
            Vehiculo resultado = VehiculoWS.ObtenerVehiculo(5);
            Assert.AreEqual(5, resultado.ID_VEHICULO);
        }

        [TestMethod]
        public void ModificarVehiculoTest()
        {
            try
            {
                Vehiculos VehiculoWS = new Vehiculos();
                Vehiculo resultado = VehiculoWS.ModificarVehiculo(2, "ERD-999", "WS-999", "KIA", "2000", "02", 0, 1);
                Assert.AreEqual("KIA", resultado.MARCA);
            }
            catch (Exception ex)
            {
                Console.WriteLine("el error que pasa es   " + ex);


            }
            
            //System.Console.Out.WriteLine(resultado);
            //Console.Out.WriteLine(resultado);
        }

        [TestMethod]
        public void EliminarVehiculoTest()
        {
            try
            {
                Vehiculos VehiculoWS = new Vehiculos();
                Vehiculo resultado = VehiculoWS.ModificarVehiculo(2, "ERD-999", "WS-999", "KIA", "2000", "02", 1, 1);
                Assert.AreEqual(1, resultado.FLAG_ANULA);
            }
            catch (Exception ex)
            {
                Console.WriteLine("el error que pasa es   " + ex);


            }

            //System.Console.Out.WriteLine(resultado);
            //Console.Out.WriteLine(resultado);
        }


        [TestMethod]
        public void ListarVehiculoTest()
        {
            Vehiculos VehiculoWS = new Vehiculos();
            List<Vehiculo> resultado = VehiculoWS.ListarVehiculo();
            Assert.AreEqual(5, resultado.Count);
        }



        public VehiculoTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
