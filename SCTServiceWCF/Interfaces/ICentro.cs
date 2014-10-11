using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SCTServiceWCF.Dominio;
using System.Web;

namespace SCTServiceWCF.Servicios
{
    [ServiceContract]
    public interface ICentro
    {
        [OperationContract]
        Centro CrearCentro(string descripcion, int empresa);
        [OperationContract]
        Centro ObtenerCentro(int codigo);
        [OperationContract]
        Centro ModificarCentro(int codigo, string descripcion, int empresa);
        //[OperationContract]
        //void EliminarCentro(int codigo);
        [OperationContract]
        List<Centro> ListarCentro();

    }
}