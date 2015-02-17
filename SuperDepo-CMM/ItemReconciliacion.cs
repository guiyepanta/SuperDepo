using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDepo_CMM
{
    public class ItemReconciliacion
    {
        public enum tiposReconciliacion { 
            None,
            EnviarReparacion,
            SacarDeServicio,
            AsignarNuevaSalida
        }

        public ItemReconciliacion() { }

        public int Id { get; set; }
        public String DescripcionSalidad { get; set; }
        public ItemSalida ItemSalida { get; set; }        
        public int IdEntrada { get; set; }
        public String FechaRegistro { get; set; }
        public bool Consolidado { get; set; }
        public int Cantidad { get; set; }
        public int IdUser { get; set; }
        public String Observacion { get; set; }
        public int IdSalidaDestino { get; set; }
        public tiposReconciliacion  tipo { get; set; }
    }
}
