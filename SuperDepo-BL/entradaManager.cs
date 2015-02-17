using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class entradaManager
    {
        #region Singleton entradaManager       
        
        private entradaManager()
        { 
        }

        static entradaManager instance = null;

        public static entradaManager getInstance() 
        {
            if (instance == null)
                instance = new entradaManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public Entrada getEntrada(Int32 idEntrada)
        {
            try
            {
                Entrada en = new Entrada();
                en = dbEntrada.getInstance().getEntrada(idEntrada);
                en.Salida = dbSalida.getInstance().getSalida(en.Salida.Id);
                en.Cliente = dbCliente.getInstance().getCliente(en.Cliente.Id);
                en.Usuario = dbUser.getInstance().getUsers(en.Usuario.Id);
                en.Items = dbEntrada.getInstance().getItemsEntrada(idEntrada);
                return en;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getEntradasAbiertas(string campo, string criterio)
        {
            try
            {
                return dbEntrada.getInstance().getEntradasAbiertas(campo, criterio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getEntradasCerradas()
        {
            try
            {
                return dbEntrada.getInstance().getEntradasCerradas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int grabar(Entrada ent)
        {
            try
            {
                return dbEntrada.getInstance().grabar(ent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void terminar(Int32 idEntrada)
        {
            try
            {
                dbEntrada.getInstance().terminar(idEntrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddReconciliacion(List<ItemReconciliacion> lstItems, int idEntrada)
        {
            try
            {
                dbEntrada.getInstance().AddReconciliacion(lstItems, idEntrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemReconciliacion> getItemsReconciliacion()
        {
            try
            {
                return dbEntrada.getInstance().getItemsReconciliacion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void reconciliar(ItemReconciliacion item)
        {
            try
            {
                dbEntrada.getInstance().reconciliar(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
