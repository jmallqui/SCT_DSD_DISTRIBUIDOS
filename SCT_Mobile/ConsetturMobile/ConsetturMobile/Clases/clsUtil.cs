using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsetturMobile
{
    public class clsUtil
    {
        //Mensajes
        public static string TituloConfirmacion = "Confirmación";
        public static string TituloAviso = "Aviso";
        public static bool online= true;

        //Variables
        public static string rutaWS = string.Empty;
        public static Int32 tiempo = 0;

        public static string opCentro = "";
        public static short opIdCentro;
        public static string opUsuario = "";
        public static string opLoginUser = "";
        public static string opIdTx = "";
        public static short opIdVehiculo;
        public static short opIdChofer;
        public static string opCodBarrasVehiculo;
        public static string opCodBarrasChofer;
        public static string opNombreChofer;
        public static string RutaRaiz = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString());
        public static Int32 opTotalPasajero = 0;

        public static Int32 totPasajerosLeidos = 0;
        public static Int32 totPasajerosMax = 0;

        public static wsConsettur.Centros[] listaCentros;

        public static List<wsConsettur.TransaccionDetalle> wsListaTransaccDet =
            new List<wsConsettur.TransaccionDetalle>();

        public enum Sonidos
        {
            Online,
            Error,
            Offline
        };

        public static void AplicarSonido(Sonidos sonido)
        {
            clsSonido oSound;
            switch (sonido)
            {
                case Sonidos.Online:
                    oSound = new clsSonido(RutaRaiz + "\\Sonidos\\Online.wav");
                    oSound.Play();
                    break;

                case Sonidos.Error:
                    oSound = new clsSonido(RutaRaiz + "\\Sonidos\\Error.wav");
                    oSound.Play();
                    break;

                case Sonidos.Offline:
                    oSound = new clsSonido(RutaRaiz + "\\Sonidos\\Offline.wav");
                    oSound.Play();
                    break;
            }
        }

        //http://181.65.169.186/WS_SCT/WsMobile.asmx
        //Data Source=181.65.169.186;Initial Catalog=SCT;User ID=sa;Password=cst_654321

    }
}
