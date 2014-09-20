using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsetturBussinessEntity
{
    public class beTransaccDetalleVarios
    {
        public string IdTx { get; set; }
        public short IdVarios { get; set; }
        public string DescPasajero { get; set; }
        public short Cantidad { get; set; }
        public string Obs { get; set; }
        public bool FlgSubida { get; set; }

        public short IdCentro { get; set; }
        public short IdVehiculo { get; set; }
        public short IdChofer { get; set; }
        public string Usuario { get; set; }

    }
}
