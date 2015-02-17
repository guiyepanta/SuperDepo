using System;
using System.Reflection;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperDepo.ControlesUsuario
{
    public class ImageManager
    {
        public static Bitmap ObtenerImagen(Form pFormulario, string pRutaArchivo)
        {
            Assembly asm = pFormulario.GetType().Assembly;
            Stream stmImagen = asm.GetManifestResourceStream(asm.GetName().Name + "." + pRutaArchivo);
            if( stmImagen != null )
            {
                Bitmap bmpImagen = new Bitmap(stmImagen);
                stmImagen.Close();
                return bmpImagen;
            }
            else
                return null;
        }

        public Bitmap ObtenerImagen(string pRutaArchivo)
        {
            Assembly asm = this.GetType().Assembly;
            Stream stmImagen = asm.GetManifestResourceStream(asm.GetName().Name + "." + pRutaArchivo);
            if( stmImagen != null )
            {
                Bitmap bmpImagen = new Bitmap(stmImagen);
                stmImagen.Close();
                return bmpImagen;
            }
            else
                return null;
        }

        public static Bitmap ObtenerImagen(Assembly asm, string pRutaArchivo)
        {
            Stream stmImagen = asm.GetManifestResourceStream(asm.GetName().Name + "." + pRutaArchivo);
            if (stmImagen != null)
            {
                Bitmap bmpImagen = new Bitmap(stmImagen);
                stmImagen.Close();
                return bmpImagen;
            }
            else
                return null;
        }
        
        public static Bitmap ObtenerImagen(string pstrAssembly, string pRutaArchivo)
        {
            Assembly asm = System.Reflection.Assembly.LoadFile(pstrAssembly);
            Stream stmImagen = asm.GetManifestResourceStream(asm.GetName().Name + "." + pRutaArchivo);
            if (stmImagen != null)
            {
                Bitmap bmpImagen = new Bitmap(stmImagen);
                stmImagen.Close();
                return bmpImagen;
            }
            else
                return null;
        }
    }
}
