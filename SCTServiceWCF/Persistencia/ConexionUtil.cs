using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsesoresService.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=(local);Initial Catalog=BD_Asesores;Integrated Security=SSPI;";
        }
    }
}