using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SCTServiceWCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IConductores" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IConductores
    {
        [OperationContract]
        void DoWork();
    }
}
