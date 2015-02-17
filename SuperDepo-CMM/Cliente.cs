using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class Cliente
    {
        public Cliente() { }

        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Contacto { get; set; }
        public String telContacto { get; set; }
        public String telCelular { get; set; }
        public String Direccion { get; set; }
        public String CodigoPostal { get; set; }
        public String Localidad { get; set; }
        public String Cuil { get; set; }
        public String Condicion { get; set; }
        public String Email { get; set; }
        public String Observaciones { get; set; }                
    }    
}
