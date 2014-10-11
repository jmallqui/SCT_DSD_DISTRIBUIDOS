using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SCTServiceWCF.Dominio
{
    [DataContract]
    public class Empresa
    {   //    ID_EMPRESA
        //EMPRESA
        //RUC
        //TELEFONO
        //DIRECCION        
        [DataMember]
        public int ID_EMPRESA { get; set; }
        [DataMember]
        public string EMPRESA { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string TELEFONO { get; set; }
        [DataMember]
        public string DIRECCION { get; set; }
        [DataMember]
        public Empresa LISTA { get; set; }


    }
}