using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SCTServiceWCF.Persistencia;
using SCTServiceWCF.Dominio;

namespace SCTServiceWCF.Persistencia
{
    public class CentroDAO : BaseDAO <Centro, int>
    {
    }
}