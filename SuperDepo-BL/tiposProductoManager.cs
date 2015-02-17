using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class tiposProductoManager
    {
        #region Singleton tecnicoManager       
        
        private tiposProductoManager()
        { 
        }

        static tiposProductoManager instance = null;

        public static tiposProductoManager getInstance() 
        {
            if (instance == null)
                instance = new tiposProductoManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public List<TipoProducto> listaTiposProductos()
        {
            try
            {
                return dbTiposProducto.getInstance().listaTiposProducto();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #endregion

        public void GuardarDatos(TipoProducto tipo)
        {
            try
            {
                dbTiposProducto.getInstance().GuardarDatos(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
