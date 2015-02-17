using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class LugarEvento
    {
        public LugarEvento() { }

        public int Id { get; set; }
        public String Establecimiento { get; set; }
        public String Direccion { get; set; }
        public int Estado { get; set; }               
    }    
}
