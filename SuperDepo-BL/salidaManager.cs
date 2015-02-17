using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class salidaManager
    {
        #region Singleton SalidaManager       
        
        private salidaManager()
        { 
        }

        static salidaManager instance = null;

        public static salidaManager getInstance() 
        {
            if (instance == null)
                instance = new salidaManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public DataSet getSalidasAbiertas(String Campo = "", String Criterio = "")
        {
            try
            {
                return dbSalida.getInstance().getSalidasAbiertas(Campo, Criterio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Salida getSalida(int idSalida)
        {
            try
            {
                return dbSalida.getInstance().getSalida(idSalida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getSalidasVigentes(String Campo = "", String Criterio = "")
        {
            try
            {
                return dbSalida.getInstance().getSalidasVigentes(Campo, Criterio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarSalida(int idSalida)
        {
            try
            {
                dbSalida.getInstance().EliminarSalida(idSalida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public Int32 Grabar(Salida Salida, bool actualizarDetalle = true)
        {
            try
            {
                return dbSalida.getInstance().Grabar(Salida, actualizarDetalle);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable getReporteSalidasVigentes()
        {
            try
            {
                return dbSalida.getInstance().getReporteSalidasVigentes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DatosRemito(Int32 idSalida, bool remitoLegal)
        {
            try
            {
                return dbSalida.getInstance().DatosRemito(idSalida, remitoLegal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object getReporteSalidasConEntrada()
        {
            try
            {
                return dbSalida.getInstance().getReporteSalidasConEntrada();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
