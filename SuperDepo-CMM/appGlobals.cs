using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDepo_CMM
{
    public class appGlobals
    {
        public static User gUser;
        public static String appVersion;
        public static String appName;
        public static String appServer;
        public static String appReportFolder;
        public enum EntityTipe
        {
            Salida,
            Clientes,
            LugaresEvento,
            Productos,
            Tecnicos,
            Usuarios,
            TiposProducto,
            SalidaNoAsignada
        }

        public static string getEntityName(EntityTipe pEntityType)
        {
            String result = String.Empty;
            switch (pEntityType)
            {
                case EntityTipe.Clientes:
                    result = "Clientes";
                    break;
                case EntityTipe.LugaresEvento:
                    result = "LugaresEvento";
                    break;
                case EntityTipe.Productos:
                    result = "Productos";
                    break;
                case EntityTipe.Tecnicos:
                    result = "Tecnicos";
                    break;
                case EntityTipe.Usuarios:
                    result = "Users";
                    break;
                case EntityTipe.Salida:
                    result = "Salidas";
                    break;
                case EntityTipe.TiposProducto:
                    result = "TiposProducto";
                    break;
                case EntityTipe.SalidaNoAsignada:
                    result = "SalidaNoAsignada";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;           
        }
    }
}
