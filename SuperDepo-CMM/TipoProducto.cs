using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class TipoProducto
    {
        public TipoProducto() { }

        public int Id { get; set; }
        public String tipo { get; set; }
        public bool exigeCantidad { get; set; }
        public bool agruparEnReportes { get; set; }
    }    
}
