using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ConsetturBussinessDataAccess;
using ConsetturBussinessEntity;

namespace ConsetturBussinessLogic
{
    public class blTransaccion
    {
        private daTransaccion o_daTransaccion = new daTransaccion();

        public bool Registrar_Transaccion(beTransaccion obeTransaccion,
                                          ref string mensajeError)
        {
            return o_daTransaccion.Registrar_Transaccion(obeTransaccion,
                                                         ref mensajeError);
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
            return o_daTransaccion.Actualizar_CerrarTransaccion(IdTx,
                                                                Usuario,
                                                                FlgSubida,
                                                                ref mensajeError,
                                                                ref listaTransaccionDetalle,
                                                                ref listaTransaccDetalleVarios,
                                                                totDescargadoDet,
                                                                totDescargadoDetVarios);
        }

        public bool Cancelar_Transaccion(string IdTx,
                                         ref string mensajeError,
                                         bool cancelado)
        {
            return o_daTransaccion.Cancelar_Transaccion(IdTx,
                                                        ref mensajeError,
                                                        cancelado);
        }

        public bool Validar_Transaccion(string IdTx,
                                        ref beTransaccion obeTransaccion,
                                        ref string mensajeError)
        {
            return o_daTransaccion.Validar_Transaccion(IdTx,
                                                       ref obeTransaccion,
                                                       ref mensajeError);
        }

        public bool Listar_TransaccionPendiente(ref List<beTransaccion> listaTransaccion,
                                                ref string mensajeError,
                                                string usuarioLogin,
                                                ref bool boolHoraInicio,
                                                ref bool boolHoraFin)
        {
            return o_daTransaccion.Listar_TransaccionPendiente(ref listaTransaccion,
                                                               ref mensajeError,
                                                               usuarioLogin,
                                                               ref boolHoraInicio,
                                                               ref boolHoraFin);
        }

        public bool Actualizar_Sincronización(string IdTx,
                                              ref string mensajeError)
        {
            return o_daTransaccion.Actualizar_Sincronización(IdTx, ref mensajeError);
        }

    }
}
