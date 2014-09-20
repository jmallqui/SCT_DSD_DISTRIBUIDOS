using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ConsetturBussinessDataAccess;
using ConsetturBussinessEntity;

namespace ConsetturBussinessLogic
{
    public class blTransaccionDetalle
    {
        private daTransaccionDetalle o_daTransaccionDetalle = new daTransaccionDetalle();

        public bool Obtener_NumLectura(string IdTx,
                                       ref Int16 numLectura,
                                       ref string mensajeError)
        {
            return o_daTransaccionDetalle.Obtener_NumLectura(IdTx,
                                                             ref numLectura,
                                                             ref mensajeError);
        }

        public bool Registrar_TransaccDetalle(beTransaccionDetalle obeTransaccDet,
                                              ref string mensajeError,
                                              ref bool insertar,
                                              ref DateTime fechaRegistro,
                                              bool registrarSDF)
        {
            return o_daTransaccionDetalle.Registrar_TransaccDetalle(obeTransaccDet,
                                                                    ref mensajeError,
                                                                    ref insertar,
                                                                    ref fechaRegistro,
                                                                    registrarSDF);
        }

        public bool Listar_DetallePendiente(string IdTx,
                                            ref string mensajeError,
                                            ref List<beTransaccionDetalle> listaTransaccionDetalle,
                                            ref bool totalDescargado,
                                            bool consultarSincronizar)
        {
            return o_daTransaccionDetalle.Listar_DetallePendiente(IdTx,
                                                                  ref mensajeError,
                                                                  ref listaTransaccionDetalle,
                                                                  ref totalDescargado,
                                                                  consultarSincronizar);
        }

        public bool Listar_Detalle(string IdTx,
                                   ref string mensajeError,
                                   ref List<beTransaccionDetalle> listaTransaccionDetalle)
        {
            return o_daTransaccionDetalle.Listar_Detalle(IdTx,
                                                         ref mensajeError,
                                                         ref listaTransaccionDetalle);
        }

        public bool Eliminar_TransaccionDetalle(string idTx,
                                                string codBarraTicket,
                                                bool eliminado,
                                                ref string mensajeError)
        {
            return o_daTransaccionDetalle.Eliminar_TransaccionDetalle(idTx,
                                                                      codBarraTicket,
                                                                      eliminado,
                                                                      ref mensajeError);
        }

        public bool TotalDetallePendiente(ref string mensajeError,
                                          ref Int32 detallePendiente)
        {
            return o_daTransaccionDetalle.TotalDetallePendiente(ref mensajeError, 
                                                                ref detallePendiente);

        }
    }
}
