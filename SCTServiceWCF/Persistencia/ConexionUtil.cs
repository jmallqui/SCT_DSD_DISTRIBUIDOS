using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCTServiceWCF.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=.\\JMALLQUI;Initial Catalog=SCT;User ID=dsdupc;Password=d1stribuidos";
        }
    }
}