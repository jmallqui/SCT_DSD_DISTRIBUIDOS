using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsetturBussinessDataAccess;
using ConsetturBussinessEntity;

namespace ConsetturBussinessLogic
{
    public class blTransaccDetalleVarios
    {
        private daTransaccDetalleVarios o_daTransaccDetalleVarios = new daTransaccDetalleVarios();

        public bool Registrar_TransaccDetalleVarios(beTransaccDetalleVarios oTransaccDetVarios,
                                                    ref string mensajeError)
        {
            return o_daTransaccDetalleVarios.Registrar_TransaccDetalleVarios(oTransaccDetVarios,
                                                                             ref mensajeError);
        }

        public bool Listar_DetallePendienteVarios(string IdTx,
                                                  ref string mensajeError,
                                                  ref List<beTransaccDetalleVarios> listaTransaccDetalleVarios,
                                                  ref bool totalDescargado,
                                                  bool consultarSincronizar)
        {
            return o_daTransaccDetalleVarios.Listar_DetallePendienteVarios(IdTx,
                                                                           ref mensajeError,
                                                                           ref listaTransaccDetalleVarios,
                                                                           ref totalDescargado,
                                                                           consultarSincronizar);
        }

        public bool Listar_Detalle(string IdTx,
                                   ref string mensajeError,
                                   ref List<beTransaccDetalleVarios> listaTransaccDetalleVarios)
        {
            return o_daTransaccDetalleVarios.Listar_Detalle(IdTx,
                                                            ref mensajeError,
                                                            ref listaTransaccDetalleVarios);
        }

        public bool Eliminar_TranscDetalleVar(string idTx,
                                              Int16 IdVarios,
                                              ref string mensajeError)
        {
            return o_daTransaccDetalleVarios.Eliminar_TranscDetalleVar(idTx, 
                                                                       IdVarios, 
                                                                       ref mensajeError);
        }

        public bool TotalDetallePendienteVarios(ref string mensajeError,
                                                ref Int32 detallePendienteVarios)
        {
            return o_daTransaccDetalleVarios.TotalDetallePendienteVarios(ref mensajeError,
                                                                         ref detallePendienteVarios);
        }
    }
}
