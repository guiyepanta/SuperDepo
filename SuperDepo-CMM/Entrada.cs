using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class Entrada
    {
        public Entrada() { }

        public int Id { get; set; }
        public Salida Salida { get; set; }
        public Cliente Cliente { get; set; }
        public String Observacion { get; set; }
        public User Usuario { get; set; }
        public String FechaEntrada { get; set; }
        public List<ItemSalida> Items { get; set; }
        public bool Cerrada { get; set; }
        public List<Tecnico> Tecnicos { get; set; }
    }    
}
