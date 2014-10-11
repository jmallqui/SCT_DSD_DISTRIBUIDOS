using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SCTServiceWCF.Persistencia;
using SCTServiceWCF.Dominio;


namespace SCTServiceWCF.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Vehiculos" in code, svc and config file together.
    public class Vehiculos : IVehiculos
    {
        private VehiculoDAO vehiculoDAO = null;
        private VehiculoDAO VehiculoDAO
        {
            get
            {
                if (vehiculoDAO == null)
                    vehiculoDAO = new VehiculoDAO();
                return vehiculoDAO;

            }


        }

        private EmpresaDAO empresaDAO = null;
        private EmpresaDAO EmpresaDAO
        {
            get
            {
                if (empresaDAO == null)
                    empresaDAO = new EmpresaDAO();
                return empresaDAO;

            }


        }

        public Vehiculo CrearVehiculo(string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int ID_EMPRESA)      
        {
            Empresa empresaExiste = EmpresaDAO.Obtener(ID_EMPRESA);
            Vehiculo VehiculoACrear = new Vehiculo()
            {
                PLACA = PLACA,
                MODELO = MODELO,
                MARCA = MARCA,
                ANNIO_FABRICACION = ANNIO_FABRICACION,
                NRO_UNIDAD = NRO_UNIDAD,
                ID_EMPRESA = empresaExiste.ID_EMPRESA,

            };
            return VehiculoDAO.Crear(VehiculoACrear);
        }


        public Vehiculo ObtenerVehiculo(int ID_VEHICULO)
        {

            return VehiculoDAO.Obtener(ID_VEHICULO);
        }

        public Vehiculo ModificarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int FLAG_ANULA, int ID_EMPRESA)
        {
            Vehiculo vehiculoaAModificar = new Vehiculo()

            {

                ID_VEHICULO = ID_VEHICULO,
                PLACA = PLACA,
                MODELO = MODELO,
                MARCA = MARCA,
                ANNIO_FABRICACION = ANNIO_FABRICACION,
                NRO_UNIDAD = NRO_UNIDAD,
                FLAG_ANULA = FLAG_ANULA,
                ID_EMPRESA = ID_EMPRESA,
                

            };

            return VehiculoDAO.Modificar(vehiculoaAModificar);
        }

        public Vehiculo EliminarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int id_empresa, int FLAG_ANULA)
        {
            Vehiculo vehiculoaAEliminar = new Vehiculo()
            {
                ID_VEHICULO = ID_VEHICULO,
                PLACA = PLACA,
                MODELO = MODELO,
                MARCA = MARCA,
                ANNIO_FABRICACION = ANNIO_FABRICACION,
                NRO_UNIDAD = NRO_UNIDAD,
                FLAG_ANULA = FLAG_ANULA,
                ID_EMPRESA = id_empresa,
            };
            
            return VehiculoDAO.Modificar(vehiculoaAEliminar);
       }

        
        public List<Vehiculo> ListarVehiculo()
        {
            return VehiculoDAO.ListarTodos().ToList();
        }

    }
}
