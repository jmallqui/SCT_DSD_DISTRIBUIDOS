using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using ConsetturBussinessEntity;
using ConsetturCompartido;

namespace ConsetturBussinessDataAccess
{
    public class daOtrosPasajeros
    {
        bool correcto = false;
        string consulta = string.Empty;
        daCnxPDA clsCnxPDA = new daCnxPDA();

        public bool Listar_OtrosPasajeros(ref string mensajeError,
                                          ref List<beOtrosPasajeros> listaOtrosPasajeros)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeDataReader drSqlCE;
            beOtrosPasajeros oeOtroPasajero;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Listar
                consulta = "Select IdVarios, DescVarios " +
                           "From  OtrosPasajeros ";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                drSqlCE = cmdSqlCE.ExecuteReader();

                while (drSqlCE.Read())
                {
                    oeOtroPasajero = new beOtrosPasajeros();
                    oeOtroPasajero.IdVarios = drSqlCE.GetInt16(drSqlCE.GetOrdinal("IdVarios"));
                    oeOtroPasajero.DescVarios = drSqlCE.GetString(drSqlCE.GetOrdinal("DescVarios"));
                    listaOtrosPasajeros.Add(oeOtroPasajero);
                }
                drSqlCE.Close();

                mensajeError = "Error al listar 'Otros pasajeros'";
                correcto = true;
            }

            catch (SqlCeException sqlCEex)
            {
                if (clsCompartida.mostrarMsjeError)
                {
                    mensajeError = sqlCEex.Message;
                }
                correcto = false;
            }

            catch (Exception ex)
            {
                if (clsCompartida.mostrarMsjeError)
                {
                    mensajeError = ex.Message;
                }
                correcto = false;
            }

            finally
            {
                //4° Cerrar conexión
                correcto = clsCnxPDA.Accion_BD_PDA(false, ref mensajeError);
                cmdSqlCE.Dispose();
            }

            return correcto;
        }

        public bool Registrar_OtrosPasajeros(List<beOtrosPasajeros> listaOtrosPasajeros,
                                             ref string mensajeError)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeTransaction transcSqlCE = null;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            transcSqlCE = daCnxPDA.cnxPDA.BeginTransaction(IsolationLevel.ReadCommitted);
            cmdSqlCE.Transaction = transcSqlCE;

            try
            {
                //2° Eliminar ítems de 'Otros pasajeros'
                consulta = "Delete From OtrosPasajeros";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al elimninar 'Otros pasajeros'";

                //3° Verificar si existe transacción
                consulta = "Insert Into OtrosPasajeros(IdVarios, DescVarios) " +
                           "Values(@IdVarios, @DescVarios)";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdVarios", SqlDbType.SmallInt);
                cmdSqlCE.Parameters.Add("@DescVarios", SqlDbType.NVarChar, 50);
                foreach (beOtrosPasajeros oeOtroPasajero in listaOtrosPasajeros)
                {
                    cmdSqlCE.Parameters["@IdVarios"].Value = oeOtroPasajero.IdVarios;
                    cmdSqlCE.Parameters["@DescVarios"].Value = oeOtroPasajero.DescVarios;
                    cmdSqlCE.ExecuteNonQuery();
                }
                mensajeError = "Error al registrar 'Otros pasajeros'";

                correcto = true;
                transcSqlCE.Commit(CommitMode.Deferred);
            }

            catch (SqlCeException sqlCEex)
            {
                if (clsCompartida.mostrarMsjeError)
                {
                    mensajeError = sqlCEex.Message;
                }
                transcSqlCE.Rollback();
                correcto = false;
            }

            catch (Exception ex)
            {
                if (clsCompartida.mostrarMsjeError)
                {
                    mensajeError = ex.Message;
                }
                transcSqlCE.Rollback();
                correcto = false;
            }

            finally
            {
                //5° Cerrar conexión
                correcto = clsCnxPDA.Accion_BD_PDA(false, ref mensajeError);
                cmdSqlCE.Dispose();
            }

            return correcto;
        }
    }
}
