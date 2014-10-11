using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Messaging;
using DSD_Mobile.Clases;
using DSD_Mobile.Entidades;

namespace DSD_Mobile.Mensajeria
{
    class OffLineMsg
    {
        public mensaje EnviarControl(Tickets ticket)
        {
            try
            {
                string ruta = String.Format(System.Globalization.CultureInfo.InvariantCulture,
                            @"{0}\dsdinbox", "192.168.1.54");


                if (!MessageQueue.Exists(ruta))
                    MessageQueue.Create(ruta);
                MessageQueue cola = new MessageQueue(ruta);

                Message mensaje = new Message();

                mensaje.Label = "Nuevo Control " + ticket.COD_BARRA_TICKET;
                mensaje.Body = ticket;

                cola.Send(mensaje);
                return new mensaje() { errNumber = 0, message = "Envio exitoso" };

            }
            catch (MessageQueueException mex)
            {
                return new mensaje() { errNumber = -1, message = mex.Message };
            }
            catch (Exception ex)
            {
                return new mensaje() { errNumber = -2, message = ex.Message };
            }
        }

        public void SendToPrivateQueueDetails()
        {

            //Machine Name  

            string destination = "192.168.1.54";

            MessageQueue orderQueue = new MessageQueue(String.Format(System.Globalization.CultureInfo.InvariantCulture, @"FormatName:Direct=http://{0}/msmq/Private$/dsdinbox", destination));



            orderQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });




            try
            {

                //Sending the Message Works  

                orderQueue.Send("Hola", String.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}", "pippo-label"));

                //txtSendMsg.Text = "";

                if (orderQueue.CanRead)
                {
                    int i = 0;
                    // MessageBox.Show("You CAN REad");

                }

                else
                { int ix = 2; }
                    //It Always enters here!!!  

                   // MessageBox.Show("You CANNOT READ!!!");

                if (orderQueue.CanWrite)
                {

                    int n = 0;
                    //I can write Always enters here  
                    //MessageBox.Show("You CAN WRITE");

                }

                else
                { int a = 2; }
                    //MessageBox.Show("You CANNOT WRITE!!!");


                //This return the ERROR!   
                Message messageReceived = orderQueue.Receive(new TimeSpan(0, 0, 10));

                messageReceived.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });

                string dato = (string)messageReceived.Body;

                //  

            }

            catch (Exception err)
            {

                //MessageBox.Show(err.Message);

            }

        }
    }
}
