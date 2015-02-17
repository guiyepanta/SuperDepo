using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class lugaresEventoManager
    {
        #region Singleton lugaresEventoManager       
        
        private lugaresEventoManager()
        { 
        }

        static lugaresEventoManager instance = null;

        public static lugaresEventoManager getInstance() 
        {
            if (instance == null)
                instance = new lugaresEventoManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public List<LugarEvento> listaLugaresEnvento()
        {
            try
            {
                return dbLugarEvento.getInstance().listaLugaresEvento();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void GuardarDatos(LugarEvento l)
        {
            try
            {
                dbLugarEvento.getInstance().guardarDatos(l);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LugarEvento getLugarEvento(int value)
        {
            try
            {
                return dbLugarEvento.getInstance().getLugarEvento(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public void elimimarLugarEvento(int p)
        {
            throw new NotImplementedException();
        }
    }
}
