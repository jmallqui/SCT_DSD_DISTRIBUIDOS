using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SCTServiceWCF.Dominio
{
    [DataContract]
    public class Tickets
    {

        [DataMember ]
        public string COD_BARRA_TICKET { get; set; }
        [DataMember]
        public string  NOM_TARIFA { get; set; }
        
        [DataMember]
        public string FEC_REGISTRO { get; set; }
               
        [DataMember]
        public string PUNTO_VENTA { get; set; }
        [DataMember]
        public string MENSAJE { get; set; }
        [DataMember]
        public int ERRNUMBER { get; set; }

                
         
                    
                                                                                                                                                                                                                                                            
        
    }
}