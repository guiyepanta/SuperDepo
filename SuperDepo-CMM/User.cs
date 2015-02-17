using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDepo_CMM
{
    public class User
    {
        public User() { }

        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Dni { get; set; }
        public String Telefono { get; set; }
        public List<Modulo> Accesos { get; set; }
        public int dh { get; set; } // dijito horizontal                
    }    
}
