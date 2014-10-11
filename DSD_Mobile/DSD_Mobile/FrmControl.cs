using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using System.Net;
using System.IO;
using CodeBetter.Json;
using DSD_Mobile.Clases;
using DSD_Mobile.Mensajeria;
using DSD_Mobile.Entidades;
namespace DSD_Mobile.Formulario
{
    public partial class frmControl : Form
    {
        public frmControl()
        {
            InitializeComponent();
        }
        //
        void buscarTicket()
        {
            try
            {
                string uploadUrl = "http://192.168.1.54/SCTServiceWCF/Servicios/ControlBoletos.svc/Controles/" + txtCodbarra.Text;
                HttpWebRequest addRequest = (HttpWebRequest)WebRequest.Create(uploadUrl);
                addRequest.Method = "GET";
                addRequest.ContentType = "application/json";
                addRequest.Timeout = 10000;
                addRequest.KeepAlive = true;
                //addRequest.ContentLength = 0;

                HttpWebResponse res2 = (HttpWebResponse)addRequest.GetResponse();
                StreamReader reader2 = new StreamReader(res2.GetResponseStream());
                string tkJson = reader2.ReadToEnd();
                tkJson = tkJson.Replace("null", "\"\"");
                Tickets tks = Converter.Deserialize<Tickets>(tkJson, "_");


                if (tks.ERRNUMBER == -1)
                {
                    this.BackColor = Color.Red;
                    txtMensajes.ForeColor = Color.Red;
                    txtTarifa.Text = tks.NOM_TARIFA;
                    txtMensajes.Text = tks.MENSAJE;
                }
                else if (tks.ERRNUMBER == 2)
                {
                    this.BackColor = Color.White;
                    txtMensajes.ForeColor = Color.Black;

                    //actualiza
                    string uploadUrlPut = "http://192.168.1.54/SCTServiceWCF/Servicios/ControlBoletos.svc/Controles/Actualizar/" + txtCodbarra.Text;
                    HttpWebRequest addRequestPut = (HttpWebRequest)WebRequest.Create(uploadUrlPut);
                    addRequestPut.Method = "PUT";
                    addRequestPut.ContentType = "application/json";
                    //addRequestPut.ContentLength = 0;

                    HttpWebResponse res2Put = (HttpWebResponse)addRequestPut.GetResponse();
                    StreamReader reader2Put = new StreamReader(res2Put.GetResponseStream());
                    string tkJsonPut = reader2Put.ReadToEnd();
                    tkJsonPut = tkJsonPut.Replace("null", "\"\"");
                    Tickets tksPut = Converter.Deserialize<Tickets>(tkJsonPut, "_");
                    txtTarifa.Text = tksPut.NOM_TARIFA;
                    txtMensajes.Text = tksPut.MENSAJE;


                }
                else
                {
                    txtTarifa.Text = tks.NOM_TARIFA;
                    txtMensajes.Text = tks.MENSAJE;
                }
                


                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodbarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           if (e.KeyChar == 13)
            {
                Cursor.Current = Cursors.WaitCursor;
                buscarTicket();
                Cursor.Current = Cursors.Default ;
                txtCodbarra.SelectAll();
                txtCodbarra.Focus();
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            OffLineMsg omsg = new OffLineMsg();

            Tickets tkt = new Tickets() { COD_BARRA_TICKET = txtCodbarra.Text };
           omsg.SendToPrivateQueueDetails();
            mensaje ms= omsg.EnviarControl(tkt);
            MessageBox.Show (ms.message); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}