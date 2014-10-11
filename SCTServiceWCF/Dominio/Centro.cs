using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SCTServiceWCF.Dominio
{
    [DataContract]
    public class Centro
    {
        [DataMember]
        public int ID_CENTRO { get; set; }
        [DataMember]
        public string DESCRIPCION { get; set; }
        [DataMember]
        public int EMPRESA { get; set; }
    }
}