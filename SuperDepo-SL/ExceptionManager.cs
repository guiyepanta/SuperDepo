using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDepo_SL
{
    public class ExceptionManager
    {
        public static void log(String message, String StackTrace)
        {
            String ruta = "c:\\SuperDepo\\Logs\\log" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + ".log";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta,true);
            String txt = "";
            txt = DateTime.Now + "; " + message + "; " + StackTrace;
            sw.WriteLine(txt);
            sw.Close();
        }
    }
}
