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
using ConsetturMobile.Clases;
using System.Net;
using System.IO;
using CodeBetter.Json;
namespace ConsetturMobile.Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //
        void buscarTicket()
        {
            try
            {
                string uploadUrl = "http://172.18.1.3/SCTServiceWCF/Servicios/ControlBoletos.svc/Control/" + txtCodbarra.Text;
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
                }
                else
                {
                    this.BackColor = Color.White ;
                    txtMensajes.ForeColor = Color.Black ;

                }

                txtTarifa.Text = tks.NOM_TARIFA ;
                txtMensajes.Text = tks.MENSAJE  ;

                

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

        
    }
}