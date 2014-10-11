using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SCTServiceWCF.Dominio;
using SCTServiceWCF.Persistencia;

namespace SCTServiceWCF.Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ControlBoletos" en el código, en svc y en el archivo de configuración a la vez.
    public class ControlBoletos : IControlBoletos
    {

       
        public Tickets LeerTicket(string nroTicket)
        {
            Tickets returnTickets;
            returnTickets=new ControlarTicketDAO().Obtener(nroTicket );
            if (returnTickets == null)
            {
                Tickets returnTickets1 = new Tickets();
                returnTickets1.ERRNUMBER = -1;
                returnTickets1.MENSAJE = "Ticket no registrado en base de datos!!!";
                returnTickets = returnTickets1;
            }
            else if (returnTickets.FEC_REGISTRO == null)
            {
                //registrar actualizar estado
                returnTickets.FEC_REGISTRO = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                returnTickets = new ControlarTicketDAO().Modificar(returnTickets);  


                returnTickets.ERRNUMBER = 0;
                returnTickets.MENSAJE = "PUT Registrado con exito!!!";

            }
            else
            {
                returnTickets.FEC_REGISTRO = returnTickets.FEC_REGISTRO.Replace("/", "-");
                returnTickets.ERRNUMBER = -1;
                returnTickets.MENSAJE = "Ticket ya fue utilizado el: " + returnTickets.FEC_REGISTRO ;
                returnTickets.FEC_REGISTRO = "";

            }


            return returnTickets;
        }



        public Tickets ActualizarTicket(string nroTicket)
        {

            Tickets returnTickets;
            returnTickets = new ControlarTicketDAO().Obtener(nroTicket);
            returnTickets.FEC_REGISTRO = DateTime.Now.ToString("yyyyMMdd HH:mm:ss"); 
            returnTickets = new ControlarTicketDAO().Modificar(returnTickets);


            returnTickets.ERRNUMBER = 0;
            returnTickets.MENSAJE = "put Registrado con exito!!!";

            return returnTickets;
        }



        #region Miembros de IControlBoletos


        public List<Tickets> ListarTicket()
        {
            ControlarTicketDAO ct=new ControlarTicketDAO();
            return ct.ListarTodos().ToList<Tickets>() ; 
        }

        #endregion
    }
}
//810*8832

//937320922593 73 20 92 25  93 73 20

