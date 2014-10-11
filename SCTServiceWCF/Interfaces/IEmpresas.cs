using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SCTServiceWCF.Dominio;

namespace SCTServiceWCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmpresas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpresas
    {
        [OperationContract]
        Empresa CrearEmpresa(string empresa, string ruc, string telefono, string direccion);
        [OperationContract]
        Empresa ObtenerEmpresa(int codigo);
        [OperationContract]
        Empresa ModificarEmpresa(int codigo, string empresa, string ruc, string telefono, string direccion);
        [OperationContract]
        void EliminarEmpresa(int codigo);
        [OperationContract]
        List<Empresa> ListarEmpresa();

    }
}
