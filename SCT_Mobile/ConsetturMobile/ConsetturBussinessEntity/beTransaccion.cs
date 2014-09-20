using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsetturBussinessEntity
{
    public class beTransaccion
    {
        public string IdTx { get; set; }
        public short IdVehiculo { get; set; }
        public short IdChofer { get; set; }
        public short IdCentro { get; set; }
        public short FlgEstado { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaUsuario { get; set; }
        public string UsuarioUpdate { get; set; }
        public DateTime FechaUpdate { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public bool FlgSubida { get; set; }
        public string CodBarrasVehiculo { get; set; }
        public string CodBarrasChofer { get; set; }
        public string NombreChofer { get; set; }
        public string UsuarioCerrado { get; set; }

        public bool FlgSincronizado { get; set; }
    }
}
