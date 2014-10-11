using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SCTServiceWCF.Dominio
{
    [DataContract]
    public class Mensaje
    {
        [DataMember] 
        public int ErrNumber { get; set; }
        [DataMember]
        public string mensaje { get; set; }
    }
}