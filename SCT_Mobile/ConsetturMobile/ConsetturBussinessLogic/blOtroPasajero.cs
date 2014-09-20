using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ConsetturBussinessDataAccess;
using ConsetturBussinessEntity;

namespace ConsetturBussinessLogic
{
    public class blOtroPasajero
    {
        private daOtrosPasajeros o_daOtrosPasajeros = new daOtrosPasajeros();
        public bool Listar_OtrosPasajeros(ref string mensajeError,
                                          ref List<beOtrosPasajeros> listaOtrosPasajeros)
        {
            return o_daOtrosPasajeros.Listar_OtrosPasajeros(ref mensajeError,
                                                            ref listaOtrosPasajeros);
        }

        public bool Registrar_OtrosPasajeros(List<beOtrosPasajeros> listaOtrosPasajeros,
                                             ref string mensajeError)
        {
            return o_daOtrosPasajeros.Registrar_OtrosPasajeros(listaOtrosPasajeros,
                                                               ref mensajeError);
        }

    }
}
