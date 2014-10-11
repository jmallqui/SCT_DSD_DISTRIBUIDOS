using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using SCTServiceWCF.Dominio;

namespace SCTServiceWCF.Interfaces
{
    [ServiceContract]
    public interface ITarifa
    {
        
        #region Operaciones de negocio
        //Registra un nuevo Tarifa asociado aun Sede.
        [OperationContract]
        Tarifa RegistrarTarifa(string NOM_TARIFA, decimal PRECIO, string MONEDA);
        [OperationContract]
        Tarifa ModificarTarifa(int ID_TARIFA, string NOM_TARIFA, decimal PRECIO, string MONEDA);
        [OperationContract]
        void EliminarTarifa(int ID_TARIFA);
        [OperationContract]
        Tarifa ObtenerTarifa(int ID_TARIFA);
        #endregion

        #region Metodos para la Administrar un Tarifa
        [OperationContract]
        ICollection<Tarifa> ListarTarifa();
        #endregion
    }
}