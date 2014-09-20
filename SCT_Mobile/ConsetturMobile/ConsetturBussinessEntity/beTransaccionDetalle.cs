using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsetturBussinessEntity
{
    public class beTransaccionDetalle
    {
        public string IdTx { get; set; }
        public string CodBaraTicket { get; set; }
        public short NumLectura { get; set; }
        public string Obs { get; set; }
        public string TipoTarifa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaUpdate { get; set; }
        public string UsuarioUpdate { get; set; }
        public DateTime FechaAnulado { get; set; }
        public string UsuarioAnulado { get; set; }
        public bool FlgSubida { get; set; }
    }
}
