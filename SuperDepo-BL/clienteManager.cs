using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class clienteManager
    {
        #region Singleton clienteManager

        private clienteManager()
        { 
        }

        static clienteManager instance = null;

        public static clienteManager getInstance() 
        {
            if (instance == null)
                instance = new clienteManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public List<Cliente> listaClientes()
        {
            try
            {
                return dbCliente.getInstance().listaClientes();
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        public void GuardarDatos(Cliente cl)
        {
            try
            {
                dbCliente.getInstance().GuardarDatos(cl);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        
        #endregion        
    
        public Cliente getCliente(int value)
        {
            try
            {
                return dbCliente.getInstance().getCliente(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
