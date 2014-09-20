using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ConsetturMobile
{
    public class clsSonido
    {
        [System.Runtime.InteropServices.DllImport("CoreDll.dll", EntryPoint = "PlaySound")]
        public static extern int WCE_PlaySound(string szSound, IntPtr hMod, int flags);

        [System.Runtime.InteropServices.DllImport("CoreDll.dll", EntryPoint = "PlaySound")]
        public static extern int WCE_PlaySoundBytes(byte[] szSound, IntPtr hMod, int flags);

        //Construir el objeto Sound para reproducir datos de sonido desde el archivo especificado.
        string m_fileName;
        public clsSonido(string fileName)
        {
            m_fileName = fileName;
        }

        private enum Flags
        {
            SND_SYNC = 0,            //Play synchronously (default) 
            SND_ASYNC = 1,           //Play asynchronously 
            SND_NODEFAULT = 2,       //Silence (!default) if sound not found  
            SND_MEMORY = 4,          //PszSound points to a memory file 
            SND_LOOP = 8,            //Loop the sound until next sndPlaySound 
            SND_NOSTOP = 16,         //Don't stop any currently playing sound 
            SND_NOWAIT = 8192,       //Don't wait if the driver is busy
            SND_ALIAS = 65536,       //Name is a registry alias 
            SND_ALIAS_ID = 1114112,  //Alias is a predefined ID
            SND_FILENAME = 131072,   //Name is file name 
            SND_RESOURCE = 262148    //Name is resource name or atom 
        }

        private byte[] m_soundBytes = null;
        public void Play()
        {
            if (!(m_fileName == null))
            {
                WCE_PlaySound(m_fileName, IntPtr.Zero,(int)((Flags.SND_ASYNC | Flags.SND_FILENAME)));
            }
            else
            {
                WCE_PlaySoundBytes(m_soundBytes, IntPtr.Zero, (int)((Flags.SND_ASYNC | Flags.SND_MEMORY)));
            }
        }
    }
}




