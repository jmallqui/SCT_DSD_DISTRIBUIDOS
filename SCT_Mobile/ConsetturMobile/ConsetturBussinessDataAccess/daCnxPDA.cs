using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using ConsetturCompartido;

namespace ConsetturBussinessDataAccess
{
    public class daCnxPDA
    {
        //Variables
        string rutaBD = string.Empty;
        public static string cadenaCnx = string.Empty;
        public static SqlCeConnection cnxPDA = new SqlCeConnection();

        public bool Accion_BD_PDA(bool abrir,
                                  ref string mensajeError)
        {
            rutaBD = clsCompartida.rutaBD_PDA;
            cadenaCnx = "Data Source = " + rutaBD;

            //1° Verificar existencia de la base de datos
            if (!File.Exists(rutaBD))
            {
                mensajeError = "La base de datos no existe";
                return false;
            }

            //2° Cerrando la BD
            try
            {
                if (cnxPDA.State == System.Data.ConnectionState.Open)
                {
                    cnxPDA.Close();
                    cnxPDA.Dispose();
                }
            }
            catch (SqlCeException sqlCEex)
            {
                mensajeError = sqlCEex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }

            //3° Abriendo BD si es solicitado
            if (abrir)
            {
                cnxPDA = new SqlCeConnection(cadenaCnx);
                cnxPDA.Open();
            }
            return true;
        }
    }
}


