using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class Tecnico
    {
        public Tecnico() { }

        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Cargo { get; set; }
        public String Dni { get; set; }
        public String Telefono { get; set; }
        public int Estado { get; set; }
    }    
}
