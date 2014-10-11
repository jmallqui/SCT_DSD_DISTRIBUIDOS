using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SCTServiceWCF.Dominio
{
    [DataContract]
    public class Vehiculo
    {
        [DataMember]
        public int ID_VEHICULO { get; set; }
        [DataMember]
        public string PLACA { get; set; }
        [DataMember]
        public string MODELO { get; set; }
        [DataMember]
        public string MARCA { get; set; }
        [DataMember]
        public string ANNIO_FABRICACION { get; set; }
        [DataMember]
        public string NRO_UNIDAD { get; set; }
        [DataMember]
        public int ID_EMPRESA { get; set; }
        [DataMember]
        public int FLAG_ANULA { get; set; }
    }
}
