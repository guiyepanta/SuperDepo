using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace SuperDepo_CMM.appUtils
{
    /// <summary>
    /// Summary description for cadena.
    /// </summary>
    public class StringUtils
    {
        static Byte[] IV =  { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static string gSumarValores(string pstrValor1, string pstrValor2)
        {
            string lstrSuma = "0";
            if (pstrValor1 != "" || pstrValor2 != "")
            {
                if (pstrValor1 != "")
                {
                    lstrSuma = pstrValor1;
                }
                if (pstrValor2 != "")
                {
                    lstrSuma = (Convert.ToDecimal(lstrSuma) + Convert.ToDecimal(pstrValor2)).ToString();
                }
            }
            return (lstrSuma);
        }

        public static string gGenerarPassword(int pintLongi)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[10];
            rng.GetBytes(buff);
            string lstrPass;
            lstrPass = Convert.ToBase64String(buff).ToString().Substring(1, pintLongi);
            lstrPass = lstrPass.Replace("/", "a");
            lstrPass = lstrPass.Replace("+", "b");
            lstrPass = lstrPass.Replace("-", "c");
            lstrPass = lstrPass.Replace("=", "d");
            return (lstrPass);
        }

        public static string gFormatFecha2DB(object pstrFecha)
        {
            if (pstrFecha == DBNull.Value)
                return ("NULL");
            else
                return gFormatFecha2DB((DateTime)pstrFecha);
        }

        public static string gFormatFecha2DB(DateTime pstrFecha)
        {
            return "'" + pstrFecha.ToString("MM/dd/yyyy") + "'";
        }

        public static string gFormatFecha(DateTime pstrFecha, string pstrCultureName)
        {
            // pstrCultureName: formato de fecha a mostrar.
            //	 []          04/15/2003 20:30:40
            // 	 [en-US]     4/15/2003 8:30:40 PM
            //   [es-AR]     15/04/2003 08:30:40 p.m.
            // 	 [fr-FR]     15/04/2003 20:30:40
            // 	 [hi-IN]     15-04-2003 20:30:40
            //	 [ja-JP]     2003/04/15 20:30:40
            //   [nl-NL]     15-4-2003 20:30:40
            //   [ru-RU]     15.04.2003 20:30:40
            //   [ur-PK]     15/04/2003 8:30:40 PM
            CultureInfo culture = new CultureInfo(pstrCultureName);
            string lstrFecha = Convert.ToString(pstrFecha, culture);
            lstrFecha = lstrFecha.Substring(0, 10);
            return (lstrFecha);
        }
        public static string gFormatMonto(string pstrMonto, string pstrCultureName)
        {
            // pstrCultureName: formato de fecha a mostrar.
            //	 []          04/15/2003 20:30:40
            // 	 [en-US]     4/15/2003 8:30:40 PM
            //   [es-AR]     15/04/2003 08:30:40 p.m.
            // 	 [fr-FR]     15/04/2003 20:30:40
            // 	 [hi-IN]     15-04-2003 20:30:40
            //	 [ja-JP]     2003/04/15 20:30:40
            //   [nl-NL]     15-4-2003 20:30:40
            //   [ru-RU]     15.04.2003 20:30:40
            //   [ur-PK]     15/04/2003 8:30:40 PM
            CultureInfo culture = new CultureInfo(pstrCultureName);
            string lstrMonto = Convert.ToString(pstrMonto, culture);
            //lstrMonto = lstrMonto.Substring(0,10);
            return (lstrMonto);
        }
        public static int gFormatNumero(string pstrCade)
        {
            if (pstrCade == null || pstrCade == "")
                return (0);
            else
                return (Convert.ToInt32(pstrCade));
        }
        public static string gFormatCadena(string pstrCade)
        {
            if (pstrCade == null)
            {
                pstrCade = "";
                return (pstrCade);
            }
            pstrCade = pstrCade.Trim();
            pstrCade = pstrCade.Replace("&nbsp;", "");
            return (pstrCade);
        }
        public static string gFormatCadenaEntreParentesis(string pstrCade)
        {
            if (pstrCade == null)
            {
                pstrCade = "";
                return (pstrCade);
            }
            pstrCade = pstrCade.Trim();
            pstrCade = "(" + pstrCade + ")";
            return (pstrCade);
        }

        public static string gFormatFechaString(string pstrFecha, string pstrFormat)
        {
            string lstrAux = pstrFecha;
            switch (pstrFormat)
            {
                case "yyyy/mm/dd":
                    {
                        System.IFormatProvider format = new System.Globalization.CultureInfo("fr-FR", true);
                        DateTime datFech = System.DateTime.Parse(lstrAux, format, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        lstrAux = datFech.Year.ToString() + "/" + datFech.Month.ToString() + "/" + datFech.Day.ToString();
                        break;
                    }
                case "Int32":
                    {
                        double dFecha;
                        System.IFormatProvider format = new System.Globalization.CultureInfo("fr-FR", true);
                        DateTime datFech = System.DateTime.Parse(lstrAux, format, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        dFecha = datFech.ToOADate();
                        lstrAux = dFecha.ToString();
                        break;
                    }
            }
            return (lstrAux);
        }

        public static string gFormatRestarFechaString(string pstrFecha, int pintAnioMenos)
        {
            string lstrAux = pstrFecha;
            string lstrAnio;
            System.IFormatProvider format = new System.Globalization.CultureInfo("fr-FR", true);
            DateTime datFech = System.DateTime.Parse(lstrAux, format, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            lstrAnio = Convert.ToString(Convert.ToInt32(datFech.Year.ToString()) - pintAnioMenos);
            if (Convert.ToString(datFech.Month).Length == 1 && Convert.ToString(datFech.Day).Length == 1)
                lstrAux = lstrAnio + "/0" + datFech.Month.ToString() + "/0" + datFech.Day.ToString();
            else if (Convert.ToString(datFech.Month).Length > 1 && Convert.ToString(datFech.Day).Length == 1)
                lstrAux = lstrAnio + "/" + datFech.Month.ToString() + "/0" + datFech.Day.ToString();
            else if (Convert.ToString(datFech.Month).Length > 1 && Convert.ToString(datFech.Day).Length > 1)
                lstrAux = lstrAnio + "/" + datFech.Month.ToString() + "/" + datFech.Day.ToString();
            else if (Convert.ToString(datFech.Month).Length == 1 && Convert.ToString(datFech.Day).Length > 1)
                lstrAux = lstrAnio + "/0" + datFech.Month.ToString() + "/" + datFech.Day.ToString();
            
        
            return (lstrAux);
        }

        public static string CrLf()
        {
            byte[] Bytes;
            Bytes = new byte[2];
            Bytes[0] = 13;
            Bytes[1] = 10;
            return (System.Text.Encoding.ASCII.GetString(Bytes));
        }

        private static Byte[] mKey(string pstrKey)
        {
            return (Encoding.UTF8.GetBytes(pstrKey));
        }

        public static string gEncriptar(string Valor, string pKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(Valor);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(mKey(pKey), IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return (Convert.ToBase64String(ms.ToArray()));
            }
            catch (Exception e)
            {
                return (e.Message);
            }

        }
        
        public static string gDesencriptar(string Valor, string pKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Convert.FromBase64String(Valor);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(mKey(pKey), IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return (encoding.GetString(ms.ToArray()));
            }
            catch (Exception e)
            {
                return (e.Message);
            }

        }        
    }
    
    
    public class FormatUtils
    {
        static Byte[] IV =  { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        public static string gSumarValores(string pstrValor1, string pstrValor2)
        {
            string lstrSuma = "0";
            if (pstrValor1 != "" || pstrValor2 != "")
            {
                if (pstrValor1 != "")
                {
                    lstrSuma = pstrValor1;
                }
                if (pstrValor2 != "")
                {
                    lstrSuma = (Convert.ToDecimal(lstrSuma) + Convert.ToDecimal(pstrValor2)).ToString();
                }
            }
            return (lstrSuma);
        }

        public static string gGenerarPassword(int pintLongi)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[10];
            rng.GetBytes(buff);
            string lstrPass;
            lstrPass = Convert.ToBase64String(buff).ToString().Substring(1, pintLongi);
            lstrPass = lstrPass.Replace("/", "a");
            lstrPass = lstrPass.Replace("+", "b");
            lstrPass = lstrPass.Replace("-", "c");
            lstrPass = lstrPass.Replace("=", "d");
            return (lstrPass);
        }

        public static string gFormatFecha2DB(object pstrFecha)
        {
            if (pstrFecha == DBNull.Value)
                return ("NULL");
            else
                return gFormatFecha2DB((DateTime)pstrFecha);
        }

        public static string gFormatFecha2DB(DateTime pstrFecha)
        {
            return "'" + pstrFecha.ToString("MM/dd/yyyy") + "'";
        }

        public static string gFormatFecha(DateTime pstrFecha, string pstrCultureName)
        {
            // pstrCultureName: formato de fecha a mostrar.
            //	 []          04/15/2003 20:30:40
            // 	 [en-US]     4/15/2003 8:30:40 PM
            //   [es-AR]     15/04/2003 08:30:40 p.m.
            // 	 [fr-FR]     15/04/2003 20:30:40
            // 	 [hi-IN]     15-04-2003 20:30:40
            //	 [ja-JP]     2003/04/15 20:30:40
            //   [nl-NL]     15-4-2003 20:30:40
            //   [ru-RU]     15.04.2003 20:30:40
            //   [ur-PK]     15/04/2003 8:30:40 PM
            CultureInfo culture = new CultureInfo(pstrCultureName);
            string lstrFecha = Convert.ToString(pstrFecha, culture);
            lstrFecha = lstrFecha.Substring(0, 10);
            return (lstrFecha);
        }
        public static string gFormatMonto(string pstrMonto, string pstrCultureName)
        {
            // pstrCultureName: formato de fecha a mostrar.
            //	 []          04/15/2003 20:30:40
            // 	 [en-US]     4/15/2003 8:30:40 PM
            //   [es-AR]     15/04/2003 08:30:40 p.m.
            // 	 [fr-FR]     15/04/2003 20:30:40
            // 	 [hi-IN]     15-04-2003 20:30:40
            //	 [ja-JP]     2003/04/15 20:30:40
            //   [nl-NL]     15-4-2003 20:30:40
            //   [ru-RU]     15.04.2003 20:30:40
            //   [ur-PK]     15/04/2003 8:30:40 PM
            CultureInfo culture = new CultureInfo(pstrCultureName);
            string lstrMonto = Convert.ToString(pstrMonto, culture);
            //lstrMonto = lstrMonto.Substring(0,10);
            return (lstrMonto);
        }
        public static string gFormatCadena(string pstrCade)
        {
            if (pstrCade == null)
            {
                pstrCade = "";
                return (pstrCade);
            }
            pstrCade = pstrCade.Trim();
            pstrCade = pstrCade.Replace("&nbsp;", "");
            return (pstrCade);
        }
        public static bool gFormatBolean(string pstrCade)
        {
            if (pstrCade == null || pstrCade == "")
            {
                return (false);
            }
            return (Convert.ToBoolean(pstrCade));
        }
        public static string gFormatCadenaEntreParentesis(string pstrCade)
        {
            if (pstrCade == null)
            {
                pstrCade = "";
                return (pstrCade);
            }
            pstrCade = pstrCade.Trim();
            pstrCade = "(" + pstrCade + ")";
            return (pstrCade);
        }

        public static string gFormatFechaString(string pstrFecha, string pstrFormat)
        {
            string lstrAux = pstrFecha;
            switch (pstrFormat)
            {
                case "mm/dd/yyyy":
                    {
                        System.IFormatProvider format = new System.Globalization.CultureInfo("fr-FR", true);
                        DateTime datFech = System.DateTime.Parse(lstrAux, format, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        lstrAux = datFech.Month.ToString() + "/" + datFech.Day.ToString() + "/" + datFech.Year.ToString();
                        break;
                    }
                case "Int32":
                    {
                        double dFecha;
                        System.IFormatProvider format = new System.Globalization.CultureInfo("fr-FR", true);
                        DateTime datFech = System.DateTime.Parse(lstrAux, format, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                        dFecha = datFech.ToOADate();
                        lstrAux = dFecha.ToString();
                        break;
                    }
            }
            return (lstrAux);
        }

        public static object gFormatFechaDateTime(string pstrFecha)
        {
            if (pstrFecha == "")
            {
                return (DBNull.Value);
            }
            else
            {
                System.IFormatProvider format = new System.Globalization.CultureInfo("ES-AR", true);
                DateTime datFech = System.DateTime.Parse(pstrFecha, format, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                return (datFech);
            }
        }

        public static string CrLf()
        {
            byte[] Bytes;
            Bytes = new byte[2];
            Bytes[0] = 13;
            Bytes[1] = 10;
            return (System.Text.Encoding.ASCII.GetString(Bytes));
        }

        private static Byte[] mKey(string pstrKey)
        {
            return (Encoding.UTF8.GetBytes(pstrKey));
        }

        public static string gEncriptar(string Valor, string pKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(Valor);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(mKey(pKey), IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return (Convert.ToBase64String(ms.ToArray()));
            }
            catch (Exception e)
            {
                return (e.Message);
            }

        }

        public static string gDesencriptar(string Valor, string pKey)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Convert.FromBase64String(Valor);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(mKey(pKey), IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return (encoding.GetString(ms.ToArray()));
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }

        public static bool IsDecimal(string expression)
        {
            if (expression == null || expression == "") { return true; }

            try
            {
                decimal numero = decimal.Parse(expression);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }
        
        public static bool IsNumber(string expression)
        {
            if (expression == null || expression == "") { return true; }

            try
            {
                int numero = int.Parse(expression);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }

        public static bool IsDate(string expression)
        {
            if (expression == null || expression == "") { return true; }

            try
            {
                DateTime dateTime = DateTime.Parse(expression);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }

    }

}
