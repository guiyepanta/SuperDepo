using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class tecnicoManager
    {
        #region Singleton tecnicoManager       
        
        private tecnicoManager()
        { 
        }

        static tecnicoManager instance = null;

        public static tecnicoManager getInstance() 
        {
            if (instance == null)
                instance = new tecnicoManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public List<Tecnico> listaTecnicos()
        {
            try
            {
                return dbTecnico.getInstance().listaTecnicos();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #endregion

        public void GuardarDatos(Tecnico tec)
        {
            try
            {
                dbTecnico.getInstance().GuardarDatos(tec);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
