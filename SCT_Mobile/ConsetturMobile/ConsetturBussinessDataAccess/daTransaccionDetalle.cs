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
    public class daTransaccionDetalle
    {
        bool correcto = false;
        string consulta = string.Empty;
        object resultado = null;
        int totalRegistros;
        daCnxPDA clsCnxPDA = new daCnxPDA();

        public bool Obtener_NumLectura(string IdTx,
                                       ref Int16 numLectura,
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
                //2° Insertar cabecera
                consulta = "Select Coalesce(Max(numLectura),0) + 1 From TransaccionDetalle " +
                           "Where IdTx=@IdTx And Coalesce(FlgAnulado,0)= 0";

                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                resultado = cmdSqlCE.ExecuteScalar();

                if (resultado == null)
                {
                    numLectura = 0;
                }
                else
                {
                    numLectura = Convert.ToInt16(resultado);
                }
                mensajeError = "Error al obtener 'Número de lectura";
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

        public bool Registrar_TransaccDetalle(beTransaccionDetalle obeTransaccDet,
                                              ref string mensajeError,
                                              ref bool insertar,
                                              ref DateTime fechaRegistro,
                                              bool registrarSDF)
        {
            int totalRegDet = 0;
            int totalRegDetVar = 0;
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
                //2° Verificar si ya fue registrado
                if (registrarSDF)
                {
                    //Detalle
                    totalRegDet = 0;
                    consulta = "Select Count(1) From TransaccionDetalle Where IdTx=@IdTx And Coalesce(FlgAnulado,0)= 0";
                    cmdSqlCE.CommandText = consulta;
                    cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                    cmdSqlCE.Parameters.Clear();
                    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccDet.IdTx;
                    totalRegDet = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                    //Detalle Varios
                    totalRegDetVar = 0;
                    consulta = "Select Count(1) From TransacDetalleVarios Where IdTx=@IdTx And Coalesce(FlgAnulado,0)= 0";
                    cmdSqlCE.CommandText = consulta;
                    cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                    cmdSqlCE.Parameters.Clear();
                    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccDet.IdTx;
                    totalRegDetVar = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                    //Consultar si el registro ya se encuentra
                    consulta = "Select Count(1) From TransaccionDetalle Where IdTx = @IdTx And CodBarraTicket = @CodBarraTicket " +
                               "And Coalesce(FlgAnulado,0)= 0";
                    cmdSqlCE.CommandText = consulta;
                    cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                    cmdSqlCE.Parameters.Clear();
                    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccDet.IdTx;
                    cmdSqlCE.Parameters.Add("@CodBarraTicket", SqlDbType.NVarChar, 20).Value = obeTransaccDet.CodBaraTicket;
                    totalRegistros = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                    if (totalRegistros == 0)
                    {
                        //3° Insertar detalle
                        insertar = true;
                        consulta = "Insert Into TransaccionDetalle(IdTx, CodBarraTicket, NumLectura, Obs," +
                                   "TipoTarifa, FechaRegistro, Usuario, FlgAnulado, FlgSubida) " +
                                   "Values (@IdTx, @CodBarraTicket, @NumLectura, @Obs, @TipoTarifa," +
                                   "@FechaRegistro, @Usuario, @FlgAnulado, @FlgSubida)";

                        cmdSqlCE.CommandText = consulta;
                        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                        cmdSqlCE.Parameters.Clear();
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccDet.IdTx;
                        cmdSqlCE.Parameters.Add("@CodBarraTicket", SqlDbType.NVarChar, 20).Value = obeTransaccDet.CodBaraTicket;
                        cmdSqlCE.Parameters.Add("@NumLectura", SqlDbType.SmallInt).Value = obeTransaccDet.NumLectura;
                        cmdSqlCE.Parameters.Add("@Obs", SqlDbType.NText).Value = obeTransaccDet.Obs;
                        cmdSqlCE.Parameters.Add("@TipoTarifa", SqlDbType.NChar, 50).Value = "";
                        cmdSqlCE.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
                        cmdSqlCE.Parameters.Add("@Usuario", SqlDbType.NVarChar, 20).Value = obeTransaccDet.Usuario;
                        cmdSqlCE.Parameters.Add("@FlgAnulado", SqlDbType.Bit).Value = false;
                        cmdSqlCE.Parameters.Add("@FlgSubida", SqlDbType.Bit).Value = obeTransaccDet.FlgSubida;
                        cmdSqlCE.ExecuteNonQuery();
                        mensajeError = "Error al registrar transacción detalle";
                    }
                    else
                    {
                        //3° Actualiza detalle
                        insertar = false;
                        consulta = "Select FechaRegistro From TransaccionDetalle Where IdTx = @IdTx And CodBarraTicket = @CodBarraTicket";
                        cmdSqlCE.CommandText = consulta;
                        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                        cmdSqlCE.Parameters.Clear();
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccDet.IdTx;
                        cmdSqlCE.Parameters.Add("@CodBarraTicket", SqlDbType.NVarChar, 20).Value = obeTransaccDet.CodBaraTicket;
                        fechaRegistro = Convert.ToDateTime(cmdSqlCE.ExecuteNonQuery());
                        mensajeError = "Error al seleccionar 'Fecha de Registro'";
                    }

                    //4° Verificar si es el primer registro
                    if ((totalRegDet == 0) && (totalRegDetVar == 0))
                    {
                        //5° Solo si es el primer registro se actualiza el estado
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
                        cmdSqlCE.Parameters.Add("@UsuarioUpdate", SqlDbType.NVarChar, 20).Value = obeTransaccDet.Usuario;
                        cmdSqlCE.Parameters.Add("@HoraInicio", SqlDbType.DateTime).Value = DateTime.Now;
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccDet.IdTx;
                        cmdSqlCE.ExecuteNonQuery();

                        mensajeError = "Error al actualizar el estado de la transacción";
                    }

                    //5° Total de registros


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
                //6° Cerrar conexión
                correcto = clsCnxPDA.Accion_BD_PDA(false, ref mensajeError);
                cmdSqlCE.Dispose();
            }

            return correcto;
        }

        public bool Listar_Detalle(string IdTx,
                                   ref string mensajeError,
                                   ref List<beTransaccionDetalle> listaTransaccionDetalle)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeDataReader drSqlCE;
            beTransaccionDetalle oeTransaccionDetalle;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Listar
                consulta = "Select NumLectura, CodBarraTicket, IdTx, Coalesce(FlgSubida,0) as FlgSubida " +
                           "From  TransaccionDetalle " +
                           "Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0 " +
                           "Order by NumLectura Desc";

                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                drSqlCE = cmdSqlCE.ExecuteReader();

                while (drSqlCE.Read())
                {
                    oeTransaccionDetalle = new beTransaccionDetalle();
                    oeTransaccionDetalle.NumLectura = drSqlCE.GetInt16(drSqlCE.GetOrdinal("NumLectura"));
                    oeTransaccionDetalle.CodBaraTicket = drSqlCE.GetString(drSqlCE.GetOrdinal("CodBarraTicket"));
                    oeTransaccionDetalle.IdTx = IdTx;
                    oeTransaccionDetalle.FlgSubida = drSqlCE.GetBoolean(drSqlCE.GetOrdinal("FlgSubida"));
                    listaTransaccionDetalle.Add(oeTransaccionDetalle);
                }
                drSqlCE.Close();

                mensajeError = "Error al listar 'Transaccion detalle'";
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

        public bool Listar_DetallePendiente(string IdTx,
                                            ref string mensajeError,
                                            ref List<beTransaccionDetalle> listaTransaccionDetalle,
                                            ref bool totalDescargado,
                                            bool consultarSincronizar)
        {
            correcto = false;
            totalDescargado = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeDataReader drSqlCE;
            beTransaccionDetalle oeTransaccionDetalle;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Verificar cuantos registros fueron descargados
                int TotDet = 0;
                int SubDet = 0;

                //Total Detalle
                if (consultarSincronizar)
                {
                    consulta = "Select Count(1) From TransaccionDetalle Where Coalesce(FlgAnulado,0)= 0";
                }
                else
                {
                    consulta = "Select Count(1) From TransaccionDetalle Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0";
                }
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                if (consultarSincronizar == false)
                {
                    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                }
                TotDet = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                //Total Descargado
                if (consultarSincronizar)
                {
                    consulta = "Select Count(1) From TransaccionDetalle Where Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0) = 1";
                }
                else
                {
                    consulta = "Select Count(1) From TransaccionDetalle Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0) = 1";
                }

                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                if (consultarSincronizar == false)
                {
                    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                }
                SubDet = Convert.ToInt32(cmdSqlCE.ExecuteScalar());

                mensajeError = "Error al verificar cantidad de ítems";
                correcto = true;

                if (TotDet == SubDet)
                {
                    totalDescargado = true;
                }
                else
                {
                    //3° Listar
                    if (consultarSincronizar)
                    {
                        consulta = "Select CodBarraTicket, NumLectura, Coalesce(TipoTarifa,'') as 'TipoTarifa', Obs, Usuario " +
                                   "From  TransaccionDetalle " +
                                   "Where IdTx = @IdTx And Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0)= 0";
                    }
                    else
                    {
                        consulta = "Select CodBarraTicket, NumLectura, Coalesce(TipoTarifa,'') as 'TipoTarifa', Obs, Usuario " +
                                   "From  TransaccionDetalle " +
                                   "Where Coalesce(FlgAnulado,0)= 0 And Coalesce(FlgSubida,0)= 0";
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
                        oeTransaccionDetalle = new beTransaccionDetalle();
                        oeTransaccionDetalle.CodBaraTicket = drSqlCE.GetString(drSqlCE.GetOrdinal("CodBarraTicket"));
                        oeTransaccionDetalle.NumLectura = drSqlCE.GetInt16(drSqlCE.GetOrdinal("NumLectura"));
                        oeTransaccionDetalle.TipoTarifa = drSqlCE.GetString(drSqlCE.GetOrdinal("TipoTarifa"));
                        oeTransaccionDetalle.Obs = drSqlCE.GetString(drSqlCE.GetOrdinal("Obs"));
                        oeTransaccionDetalle.Usuario = drSqlCE.GetString(drSqlCE.GetOrdinal("Usuario"));
                        oeTransaccionDetalle.IdTx = IdTx;
                        listaTransaccionDetalle.Add(oeTransaccionDetalle);
                    }
                    drSqlCE.Close();

                    mensajeError = "Error al listar 'Transaccion detalle'";
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

        public bool Eliminar_TransaccionDetalle(string idTx,
                                                string codBarraTicket,
                                                bool eliminado,
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
                consulta = "Delete From TransaccionDetalle Where IdTx=@IdTx And CodBarraTicket=@CodBarraTicket";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = idTx;
                cmdSqlCE.Parameters.Add("@CodBarraTicket", SqlDbType.NVarChar, 20).Value = codBarraTicket;
                cmdSqlCE.ExecuteNonQuery();

                mensajeError = "Error al eliminar ítem de 'Transacción Detalle'";
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

        public bool TotalDetallePendiente(ref string mensajeError,
                                          ref Int32 detallePendiente)
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
                consulta = "Select Count(1) From TransaccionDetalle Where Coalesce(FlgAnulado,0)= 0 " +
                           "And Coalesce(FlgSubida,0)= 0";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                detallePendiente = Convert.ToInt32(cmdSqlCE.ExecuteScalar());
                mensajeError = "Error al listar 'Transaccion detalle'";
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
