    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using SCTServiceWCF.Persistencia;
    using SCTServiceWCF.Dominio;

    namespace SCTServiceWCF.Servicios
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVehiculos" in both code and config file together.
        [ServiceContract]
        public interface IVehiculos
        {
            [OperationContract]
            Vehiculo CrearVehiculo(string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int ID_EMPRESA);
            [OperationContract]
            Vehiculo ObtenerVehiculo(int ID_VEHICULO);
            [OperationContract]
            Vehiculo ModificarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int id_empresa, int FLAG_ANULA);
            [OperationContract]
            List<Vehiculo> ListarVehiculo();
            [OperationContract]
            Vehiculo EliminarVehiculo(int ID_VEHICULO, string PLACA, string MODELO, string MARCA, string ANNIO_FABRICACION, string NRO_UNIDAD, int id_empresa, int FLAG_ANULA);
        }
    }
