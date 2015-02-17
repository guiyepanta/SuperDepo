using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace UserControls
{
    [ToolboxItem(true)]
    public class Etiqueta: System.Windows.Forms.Label 
    {
        public Etiqueta()
        { 
        
        }

        public void Limpiar()
        {
            this.Text = "";
        }

    }
}
