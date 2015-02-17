using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class Salida
    {
        public Salida() { }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public String Contacto { get; set; }
        public String CelularSalida { get; set; }
        public String TelefonoSalida { get; set; }
        public LugarEvento lugarEvento { get; set; }
        public String FechaArmado { get; set; }
        public String FechaDesarme { get; set; }
        public String Observacion { get; set; }
        public User Usuario { get; set; }
        public List<ItemSalida> Items { get; set; }
        public List<Tecnico> Tecnicos { get; set; }
        public bool remitida { get; set; }
    }    
}
