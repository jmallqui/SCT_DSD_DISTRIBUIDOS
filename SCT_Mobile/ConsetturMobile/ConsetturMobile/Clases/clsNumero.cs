using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Globalization;

namespace ConsetturMobile
{
    public class ClsNumero
    {
        private bool punto_decimal;
        private int num_decimales = 0;
        private int posicion_Cursor = 0;
        private int seleccion_Cursor = 0;
        private Int16 num_enteros = 8;
        string[] serie = new string[] { Convert.ToInt32(0).ToString(), Convert.ToInt32(1).ToString(), Convert.ToInt32(2).ToString() ,
         Convert.ToInt32(3).ToString(), Convert.ToInt32(4).ToString(), Convert.ToInt32(5).ToString(), Convert.ToInt32(6).ToString(),
         Convert.ToInt32(7).ToString(), Convert.ToInt32(8).ToString(), Convert.ToInt32(9).ToString()};
        public int PosicionCursor
        {
            get { return posicion_Cursor; }
            set { posicion_Cursor = value; }
        }
        public int SeleccionCursor
        {
            get { return seleccion_Cursor; }
            set { seleccion_Cursor = value; }
        }
        public int NumDecimales
        {
            get { return num_decimales; }
            set { num_decimales = value; }
        }
        public Int16 NumEnteros
        {
            get { return num_enteros; }
            set { num_enteros = value; }
        }

        public bool esNumero(string num, int KeyAscii)
        {
            NumberFormatInfo MiFormato = new CultureInfo(CultureInfo.CurrentCulture.ToString(), false).NumberFormat;
            string punto = MiFormato.NumberDecimalSeparator;
            if (num_decimales == 0)
            {
                if ("0123456789".IndexOf(Convert.ToChar(KeyAscii)) == -1 && KeyAscii != 8)
                {
                    //MessageBeep(0);                 
                    return true;
                }
                if (num.Length >= num_enteros && KeyAscii != 8)
                {
                    //Interaction.Beep();
                    if (num.Length >= num_enteros && seleccion_Cursor == 0)
                        return true;
                    ///''''''''Richard
                }
            }
            else
            {
                if (num.IndexOf(punto) == 0)
                {
                    punto_decimal = false;
                    ///''' Richard
                    ///''
                }
                else if (num.IndexOf(punto) == num_enteros + 1)
                {
                    if (seleccion_Cursor == 0)
                    {
                        if (posicion_Cursor < num_enteros + 1 && KeyAscii != 8 && num.Length - num.IndexOf(punto) <= num_decimales)
                            return true;
                        ///''''''
                    }
                    punto_decimal = true;
                    if (num.Length - num.IndexOf(punto) == num_decimales && KeyAscii != 8)
                    {
                        if (posicion_Cursor >= num.IndexOf(punto) && seleccion_Cursor == 0)
                            return true;
                        //If posicion_Cursor >= InStr(num, punto) Then Return True
                    }

                    ///'' Richard
                }
                else
                {
                    punto_decimal = true;
                    if (num.Length - num.IndexOf(punto) == num_decimales && KeyAscii != 8)
                    {
                        if (posicion_Cursor >= num.IndexOf(punto) && seleccion_Cursor == 0)
                            return true;
                        // Richard
                    }
                }
                if (Convert.ToChar(KeyAscii).Equals(punto) && punto_decimal == true)
                {
                    //Interaction.Beep();
                    return true;
                }
                if (("0123456789" + punto).IndexOf(Convert.ToChar(KeyAscii)) == -1 && KeyAscii != 8)
                {
                    //Interaction.Beep();
                    return true;
                }
                if (Convert.ToChar(KeyAscii).Equals(punto) && punto_decimal == false)
                {
                    punto_decimal = false;
                }
                if (num.Length >= num_enteros && !Convert.ToChar(KeyAscii).Equals(punto) && punto_decimal == false && KeyAscii != 8)
                {
                    //Interaction.Beep();
                    if (seleccion_Cursor == 0)
                        return true;
                }
            }
            return false;
        }
        public bool esNumeroReal(string num, int KeyAscii)
        {
            NumberFormatInfo MiFormato = new CultureInfo(CultureInfo.CurrentCulture.ToString(), false).NumberFormat;
            string punto = MiFormato.NumberDecimalSeparator;
            if (num_decimales == 0)
            {
                if ("-0123456789".IndexOf(Convert.ToChar(KeyAscii)) == -1 && KeyAscii != 8)
                {
                    //Interaction.Beep();
                    return true;
                }
                if (num.Length >= num_enteros && KeyAscii != 8)
                {
                    //Interaction.Beep();
                    if (num.Length >= num_enteros && seleccion_Cursor == 0)
                        return true;
                    ///''''''''Richard
                }
            }
            else
            {
                if (num.IndexOf(punto) == 0)
                {
                    punto_decimal = false;
                    ///''' Richard
                    ///''
                }
                else if (num.IndexOf(punto) == num_enteros + 1)
                {
                    if (seleccion_Cursor == 0)
                    {
                        if (posicion_Cursor < num_enteros + 1 && KeyAscii != 8 && num.Length - num.IndexOf(punto) <= num_decimales)
                            return true;
                        ///''''''
                    }
                    punto_decimal = true;
                    if (num.Length - num.IndexOf(punto) == num_decimales && KeyAscii != 8)
                    {
                        if (posicion_Cursor >= num.IndexOf(punto) && seleccion_Cursor == 0)
                            return true;
                        //If posicion_Cursor >= InStr(num, punto) Then Return True
                    }

                    ///'' Richard
                }
                else
                {
                    punto_decimal = true;
                    if (num.Length - num.IndexOf(punto) == num_decimales && KeyAscii != 8)
                    {
                        if (posicion_Cursor >= num.IndexOf(punto) && seleccion_Cursor == 0)
                            return true;
                        // Richard
                    }
                }
                if (Convert.ToChar(KeyAscii).Equals(punto) && punto_decimal == true)
                {
                    //Interaction.Beep();
                    return true;
                }
                if (("-0123456789" + punto).IndexOf(Convert.ToChar(KeyAscii)) == -1 && KeyAscii != 8)
                {
                    //Interaction.Beep();
                    return true;
                }
                if (Convert.ToChar(KeyAscii).Equals(punto) && punto_decimal == false)
                {
                    punto_decimal = false;
                }
                if (num.Length >= num_enteros && !Convert.ToChar(KeyAscii).Equals(punto) && punto_decimal == false && KeyAscii != 8)
                {
                    //Interaction.Beep();
                    if (seleccion_Cursor == 0)
                        return true;
                }
            }
            return false;
        }


    }
}


