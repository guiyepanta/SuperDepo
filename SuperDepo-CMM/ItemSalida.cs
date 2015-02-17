using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class ItemSalida
    {
        public ItemSalida() { }

        public int Id { get; set; }
        public int IdSalida { get; set; }
        public Producto Producto { get; set; }
        public String Observacion { get; set; }
        public bool Return { get; set; }
        public int Cantidad { get; set; }

        public ItemSalida Clone()
        {
            ItemSalida Clon = new ItemSalida();

            Clon.Id = this.Id;
            Clon.IdSalida = this.IdSalida;
            Clon.Producto = this.Producto;
            Clon.Observacion = this.Observacion;
            Clon.Return = this.Return;
            Clon.Cantidad = this.Cantidad;

            return Clon; 
        }
    }    
}
