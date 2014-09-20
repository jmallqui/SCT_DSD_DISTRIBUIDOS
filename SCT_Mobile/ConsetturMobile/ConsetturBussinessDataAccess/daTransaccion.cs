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
    public class daTransaccion
    {
        bool correcto = false;
        string consulta = string.Empty;
        daCnxPDA clsCnxPDA = new daCnxPDA();

        public bool Registrar_Transaccion(beTransaccion obeTransaccion,
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
                //2° Verificar si existe transacción
                Int16 existeTransac = 0;
                consulta = "Select Count(1) From Transaccion Where IdTx=@IdTx";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccion.IdTx;
                existeTransac = Convert.ToInt16(cmdSqlCE.ExecuteScalar());

                if (existeTransac == 0)
                {
                    //3° Insertar cabecera
                    consulta = "Insert Into Transaccion(IdTx, IdVehiculo, IdChofer, IdCentro," +
                                                       "FlgEstado, Usuario, FechaRegistro, FlgSubida," +
                                                       "CodBarrasVehiculo, CodBarrasChofer, NombreChofer) " +
                               "Values (@IdTx, @IdVehiculo, @IdChofer, @IdCentro," +
                               "@FlgEstado, @Usuario, @FechaRegistro, @FlgSubida," +
                               "@CodBarrasVehiculo, @CodBarrasChofer, @NombreChofer)";

                    cmdSqlCE.CommandText = consulta;
                    cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                    cmdSqlCE.Parameters.Clear();
                    cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = obeTransaccion.IdTx;
                    cmdSqlCE.Parameters.Add("@IdVehiculo", SqlDbType.SmallInt).Value = obeTransaccion.IdVehiculo;
                    cmdSqlCE.Parameters.Add("@IdChofer", SqlDbType.SmallInt).Value = obeTransaccion.IdChofer;
                    cmdSqlCE.Parameters.Add("@IdCentro", SqlDbType.SmallInt).Value = obeTransaccion.IdCentro;
                    cmdSqlCE.Parameters.Add("@FlgEstado", SqlDbType.SmallInt).Value = obeTransaccion.FlgEstado;
                    cmdSqlCE.Parameters.Add("@Usuario", SqlDbType.NVarChar, 20).Value = obeTransaccion.Usuario;
                    cmdSqlCE.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdSqlCE.Parameters.Add("@FlgSubida", SqlDbType.Bit).Value = false;
                    cmdSqlCE.Parameters.Add("@CodBarrasVehiculo", SqlDbType.NVarChar, 14).Value = obeTransaccion.CodBarrasVehiculo;
                    cmdSqlCE.Parameters.Add("@CodBarrasChofer", SqlDbType.NVarChar, 14).Value = obeTransaccion.CodBarrasChofer;
                    cmdSqlCE.Parameters.Add("@NombreChofer", SqlDbType.NVarChar, 50).Value = obeTransaccion.NombreChofer;
                    cmdSqlCE.ExecuteNonQuery();
                }

                mensajeError = "Error al registrar transacción";
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

        public bool Actualizar_CerrarTransaccion(string IdTx,
                                                 string Usuario,
                                                 bool FlgSubida,
                                                 ref string mensajeError,
                                                 ref List<beTransaccionDetalle> listaTransaccionDetalle,
                                                 ref List<beTransaccDetalleVarios> listaTransaccDetalleVarios,
                                                 bool totDescargadoDet,
                                                 bool totDescargadoDetVarios)
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
                //2° Cerrar transacción
                consulta = "Update Transaccion " +
                           "Set FlgEstado = 2," +
                           "HoraFin = @HoraFin," +
                           "UsuarioCerrado = @UsuarioCerrado," +
                           "FlgSubida = @FlgSubida " +
                           "Where IdTx = @IdTx";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@HoraFin", SqlDbType.DateTime).Value = DateTime.Now;
                cmdSqlCE.Parameters.Add("@UsuarioCerrado", SqlDbType.NVarChar, 20).Value = Usuario;
                cmdSqlCE.Parameters.Add("@FlgSubida", SqlDbType.Bit).Value = FlgSubida;
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al cerrar transacción";
                correcto = true;

                if (FlgSubida)
                {
                    //3° Actualizar / Eliminar (Pendientes 'TRANSACCIÓN DETALLE')
                    if (totDescargadoDet)
                    {
                        //3.1° Eliminar ítems
                        consulta = "Delete From TransaccionDetalle Where IdTx = @IdTx";
                        cmdSqlCE.CommandText = consulta;
                        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                        cmdSqlCE.Parameters.Clear();
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                        cmdSqlCE.ExecuteNonQuery();
                        mensajeError = "Error al eliminar ítems de 'Transacción Detalle'";
                        correcto = true;
                    }
                    else
                    {
                        //3.1° Actualizar ítems
                        consulta = "Update TransaccionDetalle " +
                                   "Set FlgSubida = @FlgSubida " +
                                   "Where IdTx = @IdTx And CodBarraTicket = @CodBarraTicket";
                        cmdSqlCE.CommandText = consulta;
                        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                        cmdSqlCE.Parameters.Clear();
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                        cmdSqlCE.Parameters.Add("@CodBarraTicket", SqlDbType.NVarChar, 12);
                        cmdSqlCE.Parameters.Add("@FlgSubida", SqlDbType.Bit);

                        foreach (beTransaccionDetalle oeTransaccionDetalle in listaTransaccionDetalle)
                        {
                            cmdSqlCE.Parameters["@CodBarraTicket"].Value = oeTransaccionDetalle.CodBaraTicket;
                            cmdSqlCE.Parameters["@FlgSubida"].Value = oeTransaccionDetalle.FlgSubida;
                            cmdSqlCE.ExecuteNonQuery();
                        }
                        mensajeError = "Error al actualizar 'Transaccion Detalle'";
                        correcto = true;
                    }

                    //4° Actualizar / Eliminar (Pendientes 'TRANSACCIÓN DETALLE VARIOS')
                    if (totDescargadoDetVarios)
                    {
                        //4.1° Eliminar ítems
                        consulta = "Delete From TransacDetalleVarios Where IdTx = @IdTx";
                        cmdSqlCE.CommandText = consulta;
                        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                        cmdSqlCE.Parameters.Clear();
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                        cmdSqlCE.ExecuteNonQuery();
                        mensajeError = "Error al eliminar ítems de 'Transaccion Detalle Varios'";
                        correcto = true;
                    }
                    else
                    {
                        consulta = "Update TransacDetalleVarios " +
                                   "Set FlgSubida = @FlgSubida " +
                                   "Where IdTx = @IdTx And IdVarios = @IdVarios";
                        cmdSqlCE.CommandText = consulta;
                        cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                        cmdSqlCE.Parameters.Clear();
                        cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                        cmdSqlCE.Parameters.Add("@IdVarios", SqlDbType.SmallInt);
                        cmdSqlCE.Parameters.Add("@FlgSubida", SqlDbType.Bit);

                        foreach (beTransaccDetalleVarios oeTransacDetVarios in listaTransaccDetalleVarios)
                        {
                            cmdSqlCE.Parameters["@IdVarios"].Value = oeTransacDetVarios.IdVarios;
                            cmdSqlCE.Parameters["@FlgSubida"].Value = oeTransacDetVarios.FlgSubida;
                            cmdSqlCE.ExecuteNonQuery();
                        }
                        mensajeError = "Error al listar 'Transaccion Detalle Varios'";
                        correcto = true;
                    }
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

        public bool Cancelar_Transaccion(string IdTx,
                                         ref string mensajeError,
                                         bool cancelado)
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
                //2° Eliminar 'Transacción'
                consulta = "Delete From Transaccion Where IdTx=@IdTx";
                //if (cancelado)
                //{
                //    consulta = "Delete From Transaccion Where IdTx=@IdTx";
                //}
                //else
                //{
                //    consulta = "Update Transaccion Set FlgAnulado = 1 Where IdTx=@IdTx";
                //}
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al eliminar transacción";

                //3° Eliminar 'Transacción Detalle'
                consulta = "Delete From TransaccionDetalle Where IdTx=@IdTx";
                //if (cancelado)
                //{
                //    consulta = "Delete From TransaccionDetalle Where IdTx=@IdTx";
                //}
                //else
                //{
                //    consulta = "Update TransaccionDetalle Set FlgAnulado = 1 Where IdTx=@IdTx";
                //}
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al eliminar 'Transacción Detalle'";

                //4° Eliminar 'Transacción Detalle Varios'
                consulta = "Delete From TransacDetalleVarios Where IdTx=@IdTx";
                //if (cancelado)
                //{
                //    consulta = "Delete From TransacDetalleVarios Where IdTx=@IdTx";
                //}
                //else
                //{
                //    consulta = "Update TransacDetalleVarios Set FlgAnulado = 1 Where IdTx=@IdTx";
                //}
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al eliminar 'Transacción Detalle Varios'";
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

        public bool Validar_Transaccion(string IdTx,
                                        ref beTransaccion obeTransaccion,
                                        ref string mensajeError)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeDataReader drSqlCE;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Verificar si existe transacción
                consulta = "Select Coalesce(CodBarrasVehiculo,'') as  CodBarrasVehiculo," +
                                  "Coalesce(IdVehiculo,0) as  IdVehiculo," +
                                  "Coalesce(IdChofer,0) as  IdChofer," +
                                  "Coalesce(CodBarrasChofer,'') as  CodBarrasChofer," +
                                  "Coalesce(NombreChofer,'') as  NombreChofer," +
                                  "Coalesce(IdCentro,0) as IdCentro " +
                           "From Transaccion Where IdTx=@IdTx";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;

                drSqlCE = cmdSqlCE.ExecuteReader();

                while (drSqlCE.Read())
                {
                    obeTransaccion = new beTransaccion();
                    obeTransaccion.IdTx = drSqlCE.GetString(drSqlCE.GetOrdinal("IdTx"));
                    obeTransaccion.CodBarrasVehiculo = drSqlCE.GetString(drSqlCE.GetOrdinal("CodBarrasVehiculo"));
                    obeTransaccion.IdVehiculo = Convert.ToInt16(drSqlCE.GetOrdinal("IdVehiculo"));
                    obeTransaccion.IdChofer = Convert.ToInt16(drSqlCE.GetOrdinal("IdChofer"));
                    obeTransaccion.CodBarrasChofer = drSqlCE.GetString(drSqlCE.GetOrdinal("CodBarrasChofer"));
                    obeTransaccion.NombreChofer = drSqlCE.GetString(drSqlCE.GetOrdinal("NombreChofer"));
                    obeTransaccion.IdCentro = Convert.ToInt16(drSqlCE.GetOrdinal("IdCentro"));
                }
                mensajeError = "Error al validar transacción";
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

        public bool Listar_TransaccionPendiente(ref List<beTransaccion> listaTransaccion,
                                                ref string mensajeError,
                                                string usuarioLogin,
                                                ref bool boolHoraInicio,
                                                ref bool boolHoraFin)
        {
            correcto = false;
            SqlCeCommand cmdSqlCE = new SqlCeCommand();
            SqlCeDataReader drSqlCE;
            beTransaccion obeTransaccion;
            boolHoraInicio = false;
            boolHoraFin = false;

            //1° Abrir conexión
            correcto = clsCnxPDA.Accion_BD_PDA(true, ref mensajeError);
            if (!(correcto))
            {
                return correcto;
            }

            try
            {
                //2° Verificar si existe transacción
                consulta = "Select IdTx," +
                                   "IdVehiculo, IdChofer, IdCentro," +
                                   "HoraInicio," +
                                   "HoraFin," +
                                   "Coalesce(UsuarioCerrado,'') as UsuarioCerrado " +
                           "From Transaccion Where Coalesce(FlgSubida,0)=0 " +
                           "And Coalesce(FlgAnulado,0) = 0 And Coalesce(FlgEstado,0) <> '0'";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();

                drSqlCE = cmdSqlCE.ExecuteReader();

                while (drSqlCE.Read())
                {
                    obeTransaccion = new beTransaccion();
                    //IdTx
                    obeTransaccion.IdTx = drSqlCE.GetString(drSqlCE.GetOrdinal("IdTx"));
                    //IdVehiculo
                    obeTransaccion.IdVehiculo = drSqlCE.GetInt16(drSqlCE.GetOrdinal("IdVehiculo"));
                    //IdChofer
                    obeTransaccion.IdChofer = drSqlCE.GetInt16(drSqlCE.GetOrdinal("IdChofer"));
                    //IdCentro
                    obeTransaccion.IdCentro = drSqlCE.GetInt16(drSqlCE.GetOrdinal("IdCentro"));

                    //HoraInicio
                    if (drSqlCE.IsDBNull(drSqlCE.GetOrdinal("HoraInicio")))
                    {
                        boolHoraInicio = false;
                    }
                    else
                    {
                        obeTransaccion.HoraInicio = drSqlCE.GetDateTime(drSqlCE.GetOrdinal("HoraInicio"));
                        boolHoraInicio = true;
                    }

                    //HoraFin
                    if (drSqlCE.IsDBNull(drSqlCE.GetOrdinal("HoraFin")))
                    {
                        obeTransaccion.HoraFin = DateTime.Now;
                        boolHoraFin = false;
                    }
                    else
                    {
                        obeTransaccion.HoraFin = drSqlCE.GetDateTime(drSqlCE.GetOrdinal("HoraFin"));
                        boolHoraFin = true;
                    }

                    //UsuarioCerrado
                    if ((drSqlCE.IsDBNull(drSqlCE.GetOrdinal("UsuarioCerrado"))) ||
                        (drSqlCE.GetString(drSqlCE.GetOrdinal("UsuarioCerrado")).ToString().Length == 0))
                    {
                        obeTransaccion.UsuarioCerrado = usuarioLogin;
                    }
                    else
                    {
                        obeTransaccion.UsuarioCerrado = drSqlCE.GetString(drSqlCE.GetOrdinal("UsuarioCerrado")).ToString();
                    }

                    listaTransaccion.Add(obeTransaccion);
                }
                mensajeError = "Error al validar transacción";
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

        public bool Actualizar_Sincronización(string IdTx,
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
                //2° Eliminar Detalle 
                consulta = "Delete From TransaccionDetalle Where IdTx = @IdTx";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al eliminar ítems de 'Transacción Detalle'";

                //3° Eliminar Detalle Varios
                consulta = "Delete From TransacDetalleVarios Where IdTx = @IdTx";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al eliminar ítems de 'Transaccion Detalle Varios'";

                //4° Eliminar Transaccion
                consulta = "Delete From Transaccion Where IdTx = @IdTx";
                cmdSqlCE.CommandText = consulta;
                cmdSqlCE.Connection = daCnxPDA.cnxPDA;
                cmdSqlCE.Parameters.Clear();
                cmdSqlCE.Parameters.Add("@IdTx", SqlDbType.NVarChar, 12).Value = IdTx;
                cmdSqlCE.ExecuteNonQuery();
                mensajeError = "Error al eliminar ítems de 'Transaccion Detalle Varios'";

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
                //4° Cerrar conexión
                correcto = clsCnxPDA.Accion_BD_PDA(false, ref mensajeError);
                cmdSqlCE.Dispose();
            }

            return correcto;
        }
    }
}
