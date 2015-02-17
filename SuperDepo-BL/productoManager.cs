using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SuperDepo_CMM;
using SuperDepo_DB;
using SuperDepo_SL;

namespace SuperDepo_BL
{
    public class productoManager
    {
        #region Singleton ProductoManager       
        
        private productoManager()
        { 
        }

        static productoManager instance = null;

        public static productoManager getInstance() 
        {
            if (instance == null)
                instance = new productoManager();

            return instance;
        }
        #endregion

        #region Metodos Publicos

        public List<Producto> cargarProductosDisponibles(string campo, string criterio)
        {
            try
            {
                return dbProducto.getInstance().productosDisponibles(campo, criterio);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion



        public List<Producto> getAllProductos()
        {
            try
            {
                return dbProducto.getInstance().getAllProductos();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void GuardarDatos(Producto prd, bool modifyMode)
        {
            try
            {
                prd.dh = SecurityManager.getInstance().DigitoHorizontalUProducto(prd);
                dbProducto.getInstance().guardarProducto(prd, modifyMode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool validarCodigoProducto(string codProducto)
        {
            try
            {
                if (dbProducto.getInstance().getProduto(codProducto) != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataSet getEstadosProducto()
        {
            try
            {
                return dbProducto.getInstance().getEstadosProducto();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            throw new NotImplementedException();
        }

        public void elimimarProducto(String codPrd)
        {
            try
            {
                dbProducto.getInstance().EliminarProducto(codPrd);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataSet getHistorial(string codProducto)
        {
            try
            {
                return dbProducto.getInstance().getHistorial(codProducto);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public TipoProducto getTipoProducto(int idTipoProducto)
        {
            try
            {
                return dbProducto.getInstance().getTipoProducto(idTipoProducto);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable getReporteProductosDisponibles()
        {
            try
            {
                return dbProducto.getInstance().getReporteProductosDisponibles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getReporteProductosEnUso()
        {
            try
            {
                return dbProducto.getInstance().getReporteProductosEnUso();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getReporteProductosFueraServicio()
        {
            try
            {
                return dbProducto.getInstance().getReporteProductosFueraServicio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getReporteProductosEnReparacion()
        {
            try
            {
                return dbProducto.getInstance().getReporteProductosEnReparacion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void grabarDigitoHorizontal(string codigoProducto, int dh)
        {
            try
            {
                dbProducto.getInstance().grabarDigitoHorizontal(codigoProducto, dh);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void grabarDigitoVerticalProductos(int DV)
        {
            try
            {
                dbProducto.getInstance().grabarDigitoVerticalProductos(DV);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getDigitoVertical()
        {
            try
            {
                return dbProducto.getInstance().getDigitoVertical();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
