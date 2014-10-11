using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SCTServiceWCF.Dominio;
using System.ServiceModel.Web;

namespace SCTServiceWCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IControlBoletos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IControlBoletos
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Controles/{nroTicket}", ResponseFormat = WebMessageFormat.Json)]
        Tickets LeerTicket(string nroTicket);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Controles/Actualizar/{nroTicket}", ResponseFormat = WebMessageFormat.Json)]
        Tickets ActualizarTicket(string nroTicket);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Controles", ResponseFormat = WebMessageFormat.Json)]
        List<Tickets> ListarTicket();

    }
}
