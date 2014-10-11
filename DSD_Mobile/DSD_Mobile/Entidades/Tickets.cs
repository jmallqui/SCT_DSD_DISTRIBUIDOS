using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CodeBetter.Json;

namespace DSD_Mobile.Clases
{
    [SerializeIncludingBase]
    public class Tickets
    {

        private string _COD_BARRA_TICKET;
        private string _NOM_TARIFA;
        private string _FEC_REGISTRO;
        private string _PUNTO_VENTA;
        private string _MENSAJE;
        private int _ERRNUMBER; 



        public string COD_BARRA_TICKET {
            get { return _COD_BARRA_TICKET; }
            set { _COD_BARRA_TICKET = value; }
        }

      
        public string NOM_TARIFA
        {
            get { return _NOM_TARIFA; }
            set { _NOM_TARIFA  = value; }
        }

      
        public string FEC_REGISTRO
        {
            get { return _FEC_REGISTRO ; }
            set { _FEC_REGISTRO  = value; }
        }

      

        public string PUNTO_VENTA
        {
            get { return _PUNTO_VENTA ; }
            set { _PUNTO_VENTA  = value; }
        }

        public string MENSAJE
        {
            get { return _MENSAJE; }
            set { _MENSAJE = value; }
        }
        public int ERRNUMBER
        {
            get { return _ERRNUMBER; }
            set { _ERRNUMBER = value; }
        }
    }
}
