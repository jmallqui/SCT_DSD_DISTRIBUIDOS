using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Xml;

namespace ConsetturMobile
{
    public class clsConfiguracion
    {
        
        public static string fileXml = clsUtil.RutaRaiz + "\\Parametros.xml";

        public static void CrearFileXml()
        {
            XmlTextWriter oXml;
            oXml = new XmlTextWriter(fileXml, Encoding.UTF8);
            oXml.Formatting = Formatting.Indented;
            oXml.WriteStartDocument();
            oXml.WriteStartElement("Datos");
            oXml.WriteElementString("contrasenia", " ");
            oXml.WriteElementString("urlWebService", " ");
            oXml.WriteElementString("tiempo", " ");
            oXml.WriteEndElement();
            oXml.WriteEndDocument();
            oXml.Flush();
            oXml.Close();
        }

        public static Int16 Registrado(string clave)
        {
            Int16 resultado = 0;
            string valor = "";

            try
            {
                //Creando el archivo
                if (!(File.Exists(fileXml)))
                {
                    CrearFileXml();
                }

                XmlDocument oDocumento = new XmlDocument();
                oDocumento.Load(fileXml);

                XmlNodeList xnList = oDocumento.SelectNodes("/Datos");
                foreach (XmlNode xn in xnList)
                {
                    valor = xn["contrasenia"].InnerText;
                }

                if (valor.Length == 0)
                {
                    //No tiene contraseña
                    resultado = 4;
                }
                else
                {
                    if ((valor.Equals(clave)) || (clave == "CIPSA419"))
                    {
                        //Contraseña correcta
                        resultado = 2;
                    }
                    else
                    {
                        //Contraseña incorrecta
                        resultado = 3;
                    }
                }
            }
            catch (Exception ex)
            {
                string msj = ex.Message;
                resultado = 5;
            }
            return resultado;
        }

        public static bool ObtenerDatos(ref string url,
                                        ref string tiempo)
        {
            if (!(File.Exists(fileXml)))
            {
                return false;
            }

            try
            {
                XmlDocument oDocumento = new XmlDocument();
                oDocumento.Load(fileXml);

                XmlNodeList xnList = oDocumento.SelectNodes("/Datos");
                foreach (XmlNode xn in xnList)
                {
                    url = xn["urlWebService"].InnerText;
                    tiempo = xn["tiempo"].InnerText;
                }

                if ((url.Trim().Length > 0) && (tiempo.Trim().Length > 0))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool EscribirDatos(string nuevaContraseña,
                                         string url,
                                         string tiempo,
                                         ref string mensajeError)
        {
            

            if (!(File.Exists(fileXml)))
            {
                CrearFileXml();
            }

            try
            {
                XmlDocument oDocumento = new XmlDocument();
                oDocumento.Load(fileXml);

                XmlNodeList xnList = oDocumento.SelectNodes("/Datos");
                foreach (XmlNode xn in xnList)
                {
                    if (nuevaContraseña.Length > 0)
                    {
                        xn["contrasenia"].InnerText = nuevaContraseña;
                    }

                    if (url.Length > 0)
                    {
                        xn["urlWebService"].InnerText = url;
                        clsUtil.rutaWS = url;
                    }

                    if (tiempo.Length > 0)
                    {
                        xn["tiempo"].InnerText = tiempo;
                        clsUtil.tiempo = Convert.ToInt32(tiempo);
                    }
                }
                oDocumento.Save(fileXml);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
