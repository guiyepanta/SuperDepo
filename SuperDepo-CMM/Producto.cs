using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDepo_CMM
{
    public class Producto
    {
        public Producto() { }

        public String CodigoProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public String TipoProducto { get; set; }
        public bool TipoExigeCantidad { get; set; }
        public String Descripcion { get; set; }
        public String CategoriaProducto { get; set; }
        public String MarcaProducto { get; set; }
        public String ModeloProducto { get; set; }
        public String SerieProducto { get; set; }
        public int Horas { get; set; }
        public String Peso { get; set; }
        public String Medidas { get; set; }
        public String Observacion { get; set; }
        public int Cantidad { get; set; }
        public int idEstado { get; set; }
        public String Estado { get; set; }
        public int dh { get; set; } 
    }
}
