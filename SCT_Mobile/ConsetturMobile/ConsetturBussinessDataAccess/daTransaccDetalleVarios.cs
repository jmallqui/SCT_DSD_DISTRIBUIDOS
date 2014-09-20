using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using ConsetturBussinessEntity;
using ConsetturCompartido;

namespace ConsetturBussinessDataAccess
{
    public class daTransaccDetalleVarios
    {
        bool correcto = false;
        string consulta = string.Empty;
        daCnxPDA clsCnxPDA = new daCnxPDA();

        public bool Registrar_TransaccDetalleVarios(beTransaccDetalleVarios oTransaccDetVarios,
                                                    ref string mensajeError)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            int totalRegDet = 0;
            int totalRegDetVar = 0;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //Detalle
                totalRegDet = 0;
                consulta = "Select Count(1) From TransaccionDetalle Where IdTx=@IdTx And Coalesce(FlgAnulado,0)= 0";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = oTransaccDetVarios.IdTx;
                totalRegDet = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                //Detalle Varios
                totalRegDetVar = 0;
                consulta = "Select Count(1) From TransacDetalleVarios Where IdTx=@IdTx And Coalesce(FlgAnulado,0)= 0";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = oTransaccDetVarios.IdTx;
                totalRegDetVar = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                //2° Consultar si ya se encuentra registrado
                consulta = "Select Count(1) From TransacDetalleVarios Where IdTx=@IdTx And IdVarios=@IdVarios";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = oTransaccDetVarios.IdTx;
                cmdSqlCE.Parameters.Add("@IdVarios", SqlDbType.SmallInt, 24).Value = oTransaccDetVarios.IdVarios;
                Int32 resultado = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                if (resultado == 0)
                {
                    //3° Insertar registro
                    consulta = "Insert Into TransacDetalleVarios(IdTx,IdVarios,Cantidad,Observaciones,Usuario) " +
                                                        "Values (@IdTx,@IdVarios,@Cantidad,@Observaciones,@Usuario)";
                }
                else
                {
                    //4° Actualizar registro
                    consulta = "Update TransacDetalleVarios " +
                               "Set Cantidad = Cantidad + @Cantidad, " +
                               "Observaciones = @Observaciones, " +
                               "Usuario = @Usuario " +
                               "Where IdTx=@IdTx And IdVarios=@IdVarios";
                }

                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = oTransaccDetVarios.IdTx;
                cmdSqlCE.Parameters.Add("@IdVarios", SqlDbType.SmallInt, 24).Value = oTransaccDetVarios.IdVarios;
                cmdSqlCE.Parameters.Add("@Cantidad", SqlDbType.SmallInt).Value = oTransaccDetVarios.Cantidad;
                cmdSqlCE.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 500).Value = oTransaccDetVarios.Obs;
                cmdSqlCE.Parameters.Add("@Usuario", SqlDbType.NVarChar, 20).Value = oTransaccDetVarios.Usuario;

                mensajeError = "Error al grabar transacción detalle varios";
                cmdSqlCE.ExecuteNonQuery();

                //5° Solo si es el primer registro se actualiza el estado
                if ((totalRegDet == 0) && (totalRegDetVar == 0))
                {
                    consulta = "Update Transaccion " +
                               "Set FlgEstado = 1," +
                               "FechaUpdate   = @FechaUpdate," +
                               "UsuarioUpdate = @UsuarioUpdate," +
                               "HoraInicio    = @HoraInicio " +
                               "Where IdTx    = @IdTx";

                    cmdSqlCE.CommandText = consulta;
                    cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                    cmdSqlCE.Parameters.Clear();
                    cmdSqlCE.Parameters.Add("@FechaUpdate", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdSqlCE.Parameters.Add("@UsuarioUpdate", SqlDbType.NVarChar, 20).Value = oTransaccDetVarios.Usuario;
                    cmdSqlCE.Parameters.Add("@HoraInicio", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = oTransaccDetVarios.IdTx;
                    cmdSqlCE.ExecuteNonQuery();

                    mensajeError = "Error al actualizar el estado de la transacción";
                }

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
                //5° Cerrar conexión
                correcto = clsCnxPDA.Accion_BD_PDA(false, ref mensajeError);
                cmdSqlCE.Dispose();
            }

            return correcto;
        }

        public bool Listar_DetallePendienteVarios(string IdTx,
                                                  ref string mensajeError,
                                                  ref List<beTransaccDetalleVarios> listaTransaccDetalleVarios,
                                                  ref bool totalDescargado,
                                                  bool consultarSincronizar)
        {
            correcto = false;
            totalDescargado = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeDataReader drSqlCE;
            beTransaccDetalleVarios oeTransaccDetalleVarios;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Verificar cuantos registros fueron descargados
                int TotVar = 1;
                int SubVar = 0;

                ////Total Detalle
                //if (consultarSincronizar)
                //{
                //    consulta = "Select Count(1) From TransacDetalleVarios Where Coalesce(FlgAnulado,0)= 0";
                //}
                //else
                //{
                //    consulta = "Select Count(1) From TransacDetalleVarios Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0";
                //}
                //cmdSqlCE.CommandText = consulta;
                //cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                //cmdSqlCE.Parameters.Clear();
                //if (consultarSincronizar == false)
                //{
                //    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                //}
                //TotVar = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                ////Total Descargado
                //if (consultarSincronizar)
                //{
                //    consulta = "Select Count(1) From TransacDetalleVarios Where Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0) = 1";
                //}
                //else 
                //{
                //    consulta = "Select Count(1) From TransacDetalleVarios Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0) = 1";
                //}
                //cmdSqlCE.CommandText = consulta;
                //cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                //cmdSqlCE.Parameters.Clear();
                //cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                //SubVar = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                //mensajeError = "Error al verificar cantidad de ítems";
                //correcto = true;

                if (TotVar == SubVar)
                {
                    totalDescargado = true;
                }
                else
                {
                    //3° Listar
                    if (consultarSincronizar)
                    {
                        consulta = "Select IdVarios, Cantidad, Observaciones, Usuario " +
                                   "From  TransacDetalleVarios " +
                                   "Where Coalesce(FlgAnulado,0)= 0";
                    }
                    else 
                    {
                        consulta = "Select IdVarios, Cantidad, Observaciones, Usuario " +
                                   "From  TransacDetalleVarios " +
                                   "Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0"; 
                    }
                    cmdSqlCE.CommandText = consulta;
                    cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                    cmdSqlCE.Parameters.Clear();
                    if (consultarSincronizar == false)
                    {
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                    }
                    drSqlCE = cmdSqlCE.ExecuteReader();

                    while (drSqlCE.Read())
                    {
                        oeTransaccDetalleVarios = new beTransaccDetalleVarios();
                        oeTransaccDetalleVarios.IdVarios = drSqlCE.GetInt16(drSqlCE.GetOrdinal("IdVarios"));
                        oeTransaccDetalleVarios.Cantidad = drSqlCE.GetInt16(drSqlCE.GetOrdinal("Cantidad"));
                        oeTransaccDetalleVarios.Obs = drSqlCE.GetString(drSqlCE.GetOrdinal("Observaciones"));
                        oeTransaccDetalleVarios.Usuario = drSqlCE.GetString(drSqlCE.GetOrdinal("Usuario"));
                        listaTransaccDetalleVarios.Add(oeTransaccDetalleVarios);
                    }
                    drSqlCE.Close();

                    mensajeError = "Error al listar 'Transaccion detalle varios'";
                    correcto = true;
                }
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

        //public bool Listar_DetallePendienteVarios(string IdTx,
        //                                          ref string mensajeError,
        //                                          ref List<beTransaccDetalleVarios> listaTransaccDetalleVarios,
        //                                          ref bool totalDescargado,
        //                                          bool consultarSincronizar)
        //{
        //    correcto = false;
        //    totalDescargado = false;
        //    SqlCeCommand cmdSqlCE = new SqlCeCommand();
        //    SqlCeDataReader drSqlCE;
        //    beTransaccDetalleVarios oeTransaccDetalleVarios;

        //    //1° Abrir conexión
        //    correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
        //    if (!(correcto))
        //    {
        //        return correcto;
        //    }

        //    try
        //    {
        //        //2° Verificar cuantos registros fueron descargados
        //        int TotVar = 0;
        //        int SubVar = 0;

        //        //Total Detalle
        //        if (consultarSincronizar)
        //        {
        //            consulta = "Select Count(1) From TransacDetalleVarios Where Coalesce(FlgAnulado,0)= 0";
        //        }
        //        else
        //        {
        //            consulta = "Select Count(1) From TransacDetalleVarios Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0";
        //        }
        //        cmdSqlCE.CommandText = consulta;
        //        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
        //        cmdSqlCE.Parameters.Clear();
        //        if (consultarSincronizar == false)
        //        {
        //            cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
        //        }
        //        TotVar = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

        //        //Total Descargado
        //        if (consultarSincronizar)
        //        {
        //            consulta = "Select Count(1) From TransacDetalleVarios Where Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0) = 1";
        //        }
        //        else
        //        {
        //            consulta = "Select Count(1) From TransacDetalleVarios Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0) = 1";
        //        }
        //        cmdSqlCE.CommandText = consulta;
        //        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
        //        cmdSqlCE.Parameters.Clear();
        //        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
        //        SubVar = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

        //        mensajeError = "Error al verificar cantidad de ítems";
        //        correcto = true;

        //        if (TotVar == SubVar)
        //        {
        //            totalDescargado = true;
        //        }
        //        else
        //        {
        //            //3° Listar
        //            if (consultarSincronizar)
        //            {
        //                consulta = "Select IdVarios, Cantidad, Observaciones, Usuario " +
        //                           "From  TransacDetalleVarios " +
        //                           "Where Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0)= 0";
        //            }
        //            else
        //            {
        //                consulta = "Select IdVarios, Cantidad, Observaciones, Usuario " +
        //                           "From  TransacDetalleVarios " +
        //                           "Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0)= 0";
        //            }
        //            cmdSqlCE.CommandText = consulta;
        //            cmdSqlCE.Connection = daCnxPDA.cnxPDA;
        //            cmdSqlCE.Parameters.Clear();
        //            if (consultarSincronizar == false)
        //            {
        //                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
        //            }
        //            drSqlCE = cmdSqlCE.ExecuteReader();

        //            while (drSqlCE.Read())
        //            {
        //                oeTransaccDetalleVarios = new beTransaccDetalleVarios();
        //                oeTransaccDetalleVarios.IdVarios = drSqlCE.GetInt16(drSqlCE.GetOrdinal("IdVarios"));
        //                oeTransaccDetalleVarios.Cantidad = drSqlCE.GetInt16(drSqlCE.GetOrdinal("Cantidad"));
        //                oeTransaccDetalleVarios.Obs = drSqlCE.GetString(drSqlCE.GetOrdinal("Observaciones"));
        //                oeTransaccDetalleVarios.Usuario = drSqlCE.GetString(drSqlCE.GetOrdinal("Usuario"));
        //                listaTransaccDetalleVarios.Add(oeTransaccDetalleVarios);
        //            }
        //            drSqlCE.Close();

        //            mensajeError = "Error al listar 'Transaccion detalle varios'";
        //            correcto = true;
        //        }
        //    }

        //    catch (SqlCeException sqlCEex)
        //    {
        //        if (clsCompartida.mostrarMsjeError)
        //        {
        //            mensajeError = sqlCEex.Message;
        //        }
        //        correcto = false;
        //    }

        //    catch (Exception ex)
        //    {
        //        if (clsCompartida.mostrarMsjeError)
        //        {
        //            mensajeError = ex.Message;
        //        }
        //        correcto = false;
        //    }

        //    finally
        //    {
        //        //4° Cerrar conexión
        //        correcto = clsCnxPDA.Accion_BD_PDA(false, ref mensajeError);
        //        cmdSqlCE.Dispose();
        //    }

        //    return correcto;
        //}

        public bool Listar_Detalle(string IdTx,
                                   ref string mensajeError,
                                   ref List<beTransaccDetalleVarios> listaTransaccDetalleVarios)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeDataReader drSqlCE;
            beTransaccDetalleVarios oeTransaccDetalleVarios;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Listar
                consulta = "Select TransacDetalleVarios.IdVarios," +
                                  "TransacDetalleVarios.DescVarios," +
                                  "TransacDetalleVarios.Cantidad," +
                                  "Coalesce(TransacDetalleVarios.Observaciones,'') as Obs " +
                           "From  TransacDetalleVarios  inner join OtrosPasajeros " +
                                 "TransacDetalleVarios.IdVarios = OtrosPasajeros.IdVarios " +
                           "Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0";

                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                drSqlCE = cmdSqlCE.ExecuteReader();

                while (drSqlCE.Read())
                {
                    oeTransaccDetalleVarios = new beTransaccDetalleVarios();
                    oeTransaccDetalleVarios.IdTx = IdTx;
                    oeTransaccDetalleVarios.IdVarios = Convert.ToInt16(drSqlCE.GetOrdinal("IdVarios"));
                    oeTransaccDetalleVarios.DescPasajero = drSqlCE.GetString(drSqlCE.GetOrdinal("DescVarios"));
                    oeTransaccDetalleVarios.Cantidad = Convert.ToInt16(drSqlCE.GetOrdinal("Cantidad"));
                    oeTransaccDetalleVarios.Obs = drSqlCE.GetString(drSqlCE.GetOrdinal("Obs"));
                    listaTransaccDetalleVarios.Add(oeTransaccDetalleVarios);
                }
                drSqlCE.Close();

                mensajeError = "Error al listar 'Transaccion Detalle Varios'";
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

        public bool Eliminar_TranscDetalleVar(string idTx,
                                              Int16 IdVarios,
                                              ref string mensajeError)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Eliminar 'Transaccion Detalle'
                consulta = "Delete From TransacDetalleVarios Where IdTx=@IdTx And IdVarios=@IdVarios";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = idTx;
                cmdSqlCE.Parameters.Add("@IdVarios", SqlDbType.SmallInt).Value = IdVarios;
                cmdSqlCE.ExecuteNonQuery();

                mensajeError = "Error al eliminar ítem de 'Transacción Detalle Varios'";
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
                //5° Cerrar conexión
                correcto = clsCnxPDA.Accion_BD_PDA(false, ref mensajeError);
                cmdSqlCE.Dispose();
            }

            return correcto;
        }

        public bool TotalDetallePendienteVarios(ref string mensajeError,
                                                ref Int32 detallePendienteVarios)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                consulta = "Select Count(1) From TransacDetalleVarios Where Coalesce(FlgAnulado,0)= 0 ";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                detallePendienteVarios = Convert.ToInt32(cmdSqlCE.ExecuteScalar());
                mensajeError = "Error al listar 'Transaccion detalle varios'";
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

    }
}
