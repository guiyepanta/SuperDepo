using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SuperDepo_CMM;
using SuperDepo_BL;
using SuperDepo_SL;
using System.Linq;

namespace SuperDepo.ControlesABM
{
    public partial class desingEntrada : UserControl
    {
        #region Variables
        Entrada mEntrada;
        Salida mSalida;
        List<ItemSalida> mListItems;

        #endregion

        #region Propiedades

        #endregion

        public desingEntrada()
        {
            InitializeComponent();
        }
        public desingEntrada(Entrada Entrada)
        {
            InitializeComponent();
            mEntrada = Entrada;
        }               
       
        #region Motodos privados

        private void FillDatosSalida(int idSalida)
        {
            mSalida = salidaManager.getInstance().getSalida(idSalida);
            mListItems = mSalida.Items;
            this.txtCliente.Text = mSalida.Cliente.Nombre;
            this.txtCliente.Tag = mSalida.Cliente.Id;
            this.txtLugarEvento.Text = mSalida.lugarEvento.Establecimiento;
            this.txtLugarEvento.Tag = mSalida.lugarEvento.Id;
            this.txtContacto.Text = mSalida.Contacto;
            this.txtFechaArmado.Text = mSalida.FechaArmado;
            this.txtFechaDesarme.Text = mSalida.FechaDesarme;
            this.txtTelefono.Text = mSalida.TelefonoSalida;
            this.txtCelular.Text = mSalida.CelularSalida;
            this.txtObservaciones.Text = mSalida.Observacion;
            if (this.mEntrada == null)
            {
                if (mSalida.Items != null)
                    this.FillItemsSalidas(mSalida.Items);
                if (mSalida.Tecnicos != null)
                    this.FillDatosTecnicos(mSalida.Tecnicos);
            }
        }

        private void FillItemsSalidas(List<ItemSalida> lstItems)
        {
            foreach (ItemSalida itmS in lstItems)
            {
                ListViewItem item = new ListViewItem();
                item.Text = itmS.Producto.CodigoProducto;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, itmS.Producto.TipoProducto));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, itmS.Producto.Descripcion));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, itmS.Cantidad.ToString()));
                item.Tag = itmS;
                item.Selected = false;
                this.lstItemsSalida.Items.Add(item);
            }
        }

        private void FillDatosTecnicos(List<Tecnico> listTecnicos)
        {
            foreach (Tecnico tec in listTecnicos)
            {
                ListViewItem item = new ListViewItem();
                item.Text = tec.Nombre;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, tec.Cargo));
                item.Tag = tec;
                item.Selected = false;
                lstTecnicosSalida.Items.Add(item);                
            }
        }

        private void CargarItemSalida(ItemSalida item)
        {
            Producto prd = item.Producto;
            
            DataGridViewRow dgRow = new DataGridViewRow();
            DataGridViewCell cellCod = new DataGridViewTextBoxCell();
            DataGridViewCell cellTipo = new DataGridViewTextBoxCell();
            DataGridViewCell cellDesc = new DataGridViewTextBoxCell();
            DataGridViewCell cellMarca = new DataGridViewTextBoxCell();
            DataGridViewCell cellModelo = new DataGridViewTextBoxCell();
            DataGridViewCell cellSerie = new DataGridViewTextBoxCell();
            DataGridViewCell cellCant = new DataGridViewTextBoxCell();

            cellCod.Tag = item;
            cellCod.Value = prd.CodigoProducto;
            cellTipo.Value = prd.TipoProducto;
            cellDesc.Value = prd.Descripcion;
            cellMarca.Value = prd.MarcaProducto;
            cellModelo.Value = prd.ModeloProducto;
            cellSerie.Value = prd.SerieProducto;
            cellCant.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            cellCant.Value = item.Cantidad;

            dgRow.Cells.Add(cellCod);
            dgRow.Cells.Add(cellTipo);
            dgRow.Cells.Add(cellDesc);
            dgRow.Cells.Add(cellMarca);
            dgRow.Cells.Add(cellModelo);
            dgRow.Cells.Add(cellSerie);
            dgRow.Cells.Add(cellCant);

            grdDetalleSalida.Rows.Add(dgRow);
        }

        private void filtrarProducto(string campo, string criterio)
        {
            if (criterio == "")
            {
                var qAll = from item in mListItems
                           orderby item.Producto.Descripcion
                           select item;

                this.fillListaProductos(qAll);
            }
            else
                switch (campo)
                {
                    case "Codigo":
                        var qCod = from item in mListItems
                                   where (item.Producto.CodigoProducto.ToUpper().StartsWith(criterio.ToUpper()))
                                   orderby item.Producto.Descripcion
                                   select item;
                        this.fillListaProductos(qCod);
                        break;
                    case "Descripcion":
                        var qDes = from item in mListItems
                                   where (item.Producto.Descripcion.ToUpper().StartsWith(criterio.ToUpper()))
                                   orderby item.Producto.Descripcion
                                   select item;

                        this.fillListaProductos(qDes);
                        break;
                    case "Tipo Producto":
                        var qTipo = from item in mListItems
                                    where (item.Producto.TipoProducto.ToUpper().StartsWith(criterio.ToUpper()))
                                    orderby item.Producto.Descripcion
                                    select item;

                        this.fillListaProductos(qTipo);
                        break;
                    default:
                        break;
                }
        }

        private void fillListaProductos(IOrderedEnumerable<ItemSalida> q)
        {
            foreach (ItemSalida item in q)
            {
                ListViewItem lstItem = new ListViewItem();
                lstItem.Text = item.Producto.CodigoProducto;
                lstItem.SubItems.Add(new ListViewItem.ListViewSubItem(lstItem, item.Producto.Descripcion));
                lstItem.SubItems.Add(new ListViewItem.ListViewSubItem(lstItem, item.Cantidad.ToString()));
                lstItem.Tag = item;
                lstItem.Selected = false;
                this.lstItemsSalida.Items.Add(lstItem);
            }
        }

        private Int32 grabarEntrada(bool Terminada)
        {
            if (mEntrada == null)
                mEntrada = new Entrada();

            if (this.ValidarDatos())
            {
                mEntrada.Cliente = mSalida.Cliente;
                mEntrada.Salida = mSalida;
                mEntrada.Usuario = appGlobals.gUser;
                mEntrada.Observacion = "";
                mEntrada.FechaEntrada = DateTime.Now.ToLongDateString();
                mEntrada.Observacion = this.txtObservaciones.Text;
                mEntrada.Items = this.obtenerListaItems();
                mEntrada.Cerrada = Terminada;
                mEntrada.Tecnicos = this.getTecnicos();
                mEntrada.Id = entradaManager.getInstance().grabar(mEntrada);
            }
            return mEntrada.Id;
        }

        private bool ValidarDatos()
        {
            if (this.selSalida.EntityId == 0)
            {
                MessageBox.Show("Debe seleccionar una Salida.", "atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            if (this.lstTecnicosEntrada.Items.Count <= 0)
            {
                MessageBox.Show("Debe indicar tecnicos que realizaron la Entrada.", "atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;;
        }

        private List<ItemSalida> obtenerListaItems()
        {
            List<ItemSalida> lstItem = new List<ItemSalida>();

            foreach (DataGridViewRow row in this.grdDetalleSalida.Rows)
            {
                ItemSalida item = (ItemSalida)row.Cells[0].Tag;
                item.Cantidad = Convert.ToInt32(row.Cells[6].Value);
                lstItem.Add(item);
            }

            return lstItem;
        }

        private List<Tecnico> getTecnicos()
        {
            List<Tecnico> lstTec = new List<Tecnico>();
            foreach (ListViewItem item in this.lstTecnicosEntrada.Items)
            {
                lstTec.Add((Tecnico)item.Tag);
            }

            return lstTec;
        }

        private void enviarReconciliarProductos(Int32 idEntrada)
        {
            List<ItemSalida> lstItems = new List<ItemSalida>();
            foreach (ListViewItem item in this.lstItemsSalida.Items)
            {
                ItemSalida iSalida = (ItemSalida)item.Tag;
                lstItems.Add(iSalida);
            }

            frmAddReconciliacion frmRecon = new frmAddReconciliacion(lstItems, idEntrada);
            frmRecon.ShowInTaskbar = false;
            frmRecon.StartPosition = FormStartPosition.CenterScreen;
            frmRecon.ShowDialog();
        }

        private void FillEntrada()
        {
            this.selSalida.AssignEntity = this.mEntrada.Salida.Id;
            this.txtObservaciones.Text = this.mEntrada.Observacion;
            foreach (ItemSalida item in this.mEntrada.Items)
            {
                this.CargarItemSalida(item);
            }
            this.FillProductoForEdit();
        }

        private void FillProductoForEdit()
        {
            bool Existe = false;
            mListItems = new List<ItemSalida>();
            foreach (ItemSalida item in this.mEntrada.Salida.Items)
            {
                Existe = false;
                foreach (DataGridViewRow row in this.grdDetalleSalida.Rows)
                {
                    ItemSalida itemEdit = (ItemSalida)row.Cells[0].Tag;
                    if (itemEdit.Producto.CodigoProducto == item.Producto.CodigoProducto)
                    {
                        Existe = true;
                        if (itemEdit.Cantidad != item.Cantidad)
                        { 
                            item.Cantidad = item.Cantidad - itemEdit.Cantidad;
                            mListItems.Add(item);
                            break;
                        }                      
                    }
                }
                if (!Existe)
                    mListItems.Add(item);
            }
            this.filtrarProducto("", "");
        }

        private bool ItemExist(ItemSalida item)
        {
            
            return false;
        }

        private void cargarTecnicos()
        {
            List<Tecnico> lstTec = new List<Tecnico>();
            lstTec = tecnicoManager.getInstance().listaTecnicos();

            var dicTecs = new Dictionary<Tecnico, String>();

            foreach (Tecnico tec in lstTec)
            {
                dicTecs.Add(tec, tec.Nombre);
            }

            cmbOperadores.DataSource = new BindingSource(dicTecs, null);
            cmbOperadores.ValueMember = "Key";
            cmbOperadores.DisplayMember = "Value";
        }

        private void CargarTecnico(Tecnico tec)
        {
            ListViewItem it = new ListViewItem();
            it.Tag = tec;
            it.Text = tec.Nombre;
            it.Selected = false;
            it.SubItems.Add(new ListViewItem.ListViewSubItem(it, tec.Cargo));
            lstTecnicosEntrada.Items.Add(it);
        }

        #endregion

        #region Eventos Controles

        private void desingEntrada_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.mEntrada != null)
                {
                    this.FillEntrada();
                }
                this.cargarTecnicos();
                this.cmbFilterField.SelectedIndex = 0;
                this.lblOwner.Text = appGlobals.gUser.LastName + ", " + appGlobals.gUser.Name;
                this.txtFechaEntrada.Text = DateTime.Now.ToString("dd/MM/yyyy") + " - " + DateTime.Now.ToShortTimeString();
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }        
        
        private void selSalida_EntityIdChanged()
        {
            try
            {
                this.FillDatosSalida(this.selSalida.EntityId);
                this.grpDetalle.Enabled = true;
                this.btnLimpiar.Enabled = true;
                this.btnTerminar.Enabled = true;
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstItemsSalida_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ItemSalida itemOld = (ItemSalida)this.lstItemsSalida.SelectedItems[0].Tag;
                ItemSalida item = ((ItemSalida)this.lstItemsSalida.SelectedItems[0].Tag).Clone();

                if (item.Producto.TipoExigeCantidad)
                {
                    ControlesUsuario.inputBox iBox = new ControlesUsuario.inputBox();
                    iBox.Message = "Ingrese una Cantidad";
                    if (iBox.ShowDialog() == DialogResult.OK)
                        item.Cantidad = Convert.ToInt32(iBox.Value);
                    iBox.Dispose();

                    if (itemOld.Cantidad > item.Cantidad)
                    {
                        this.mListItems.Remove(itemOld);
                        itemOld.Cantidad = itemOld.Cantidad - item.Cantidad;
                        ListViewItem itemView = new ListViewItem();
                        itemView.Text = itemOld.Producto.CodigoProducto;
                        itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Producto.TipoProducto));
                        itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Producto.Descripcion));
                        itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Cantidad.ToString()));
                        itemView.Tag = itemOld;
                        itemView.ForeColor = Color.Red;
                        itemView.Selected = false;
                        this.lstItemsSalida.SelectedItems[0].Remove();
                        this.lstItemsSalida.Items.Add(itemView);
                        this.mListItems.Add(itemOld);
                    }
                    else if (itemOld.Cantidad == item.Cantidad)
                    {
                        this.lstItemsSalida.SelectedItems[0].Remove();
                        this.mListItems.Remove(itemOld);
                    }
                }
                else
                {
                    this.lstItemsSalida.SelectedItems[0].Remove();
                    this.mListItems.Remove(itemOld);
                }
                this.CargarItemSalida(item);
                this.txtTextSearch.Text = "";
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (this.lstItemsSalida.Items.Count == 1)
                    {
                        ItemSalida itemOld = (ItemSalida)this.lstItemsSalida.Items[0].Tag;
                        ItemSalida item = ((ItemSalida)this.lstItemsSalida.Items[0].Tag).Clone();

                        if (item.Producto.TipoExigeCantidad)
                        {
                            ControlesUsuario.inputBox iBox = new ControlesUsuario.inputBox();
                            iBox.Message = "Ingrese una Cantidad";
                            if (iBox.ShowDialog() == DialogResult.OK)
                                item.Cantidad = Convert.ToInt32(iBox.Value);
                            iBox.Dispose();

                            if (itemOld.Cantidad > item.Cantidad)
                            {
                                this.mListItems.Remove(itemOld);
                                itemOld.Cantidad = itemOld.Cantidad - item.Cantidad;
                                ListViewItem itemView = new ListViewItem();
                                itemView.Text = itemOld.Producto.CodigoProducto;
                                itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Producto.Descripcion));
                                itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Cantidad.ToString()));
                                itemView.Tag = itemOld;
                                itemView.ForeColor = Color.Red;
                                itemView.Selected = false;
                                this.lstItemsSalida.Items[0].Remove();
                                this.lstItemsSalida.Items.Add(itemView);
                                this.mListItems.Add(itemOld);
                            }
                            else if (itemOld.Cantidad == item.Cantidad)
                            {
                                this.lstItemsSalida.Items[0].Remove();
                                this.mListItems.Remove(itemOld);
                            }
                        }
                        else
                        {
                            this.lstItemsSalida.Items[0].Remove();
                            this.mListItems.Remove(itemOld);
                        }
                        this.CargarItemSalida(item);
                        this.txtTextSearch.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void txtTextSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.lstItemsSalida.Items.Clear();
                this.filtrarProducto(cmbFilterField.Text, txtTextSearch.Text);                
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (this.selSalida.EntityId != 0)
            {
                if (MessageBox.Show("Hay datos sin guardar.\r¿Desea salir de todas formas?", "Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.cerrarPantalla();
                }
            }
            else
                this.cerrarPantalla();
        }

        private void cerrarPantalla()
        {
            contentEntradas cEntreda = new contentEntradas();
            cEntreda.Dock = DockStyle.Fill;
            cEntreda.Parent = this.Parent;
            cEntreda.BringToFront();
            ((Panel)this.Parent).Controls.Add(cEntreda);
            ((Panel)this.Parent).Controls.Remove(this);
        }

        private void lstItemsSalida_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && this.lstItemsSalida.SelectedItems.Count > 0)
                { 
                    ItemSalida itemOld = (ItemSalida)this.lstItemsSalida.SelectedItems[0].Tag;
                    ItemSalida item = ((ItemSalida)this.lstItemsSalida.SelectedItems[0].Tag).Clone();

                    if (item.Producto.TipoExigeCantidad)
                    {
                        ControlesUsuario.inputBox iBox = new ControlesUsuario.inputBox();
                        iBox.Message = "Ingrese una Cantidad";
                        if (iBox.ShowDialog() == DialogResult.OK)
                            item.Cantidad = Convert.ToInt32(iBox.Value);
                        iBox.Dispose();

                        if (itemOld.Cantidad > item.Cantidad)
                        {

                            this.mListItems.Remove(itemOld);
                            itemOld.Cantidad = itemOld.Cantidad - item.Cantidad;
                            ListViewItem itemView = new ListViewItem();
                            itemView.Text = itemOld.Producto.CodigoProducto;
                            itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Producto.TipoProducto));
                            itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Producto.Descripcion));
                            itemView.SubItems.Add(new ListViewItem.ListViewSubItem(itemView, itemOld.Cantidad.ToString()));
                            itemView.Tag = itemOld;
                            itemView.ForeColor = Color.Red;
                            itemView.Selected = false;
                            this.lstItemsSalida.SelectedItems[0].Remove();
                            this.lstItemsSalida.Items.Add(itemView);
                            this.mListItems.Add(itemOld);
                        }
                        else if (itemOld.Cantidad == item.Cantidad)
                        {
                            this.lstItemsSalida.SelectedItems[0].Remove();
                            this.mListItems.Remove(itemOld);
                        }
                    }
                    else
                    {
                        this.lstItemsSalida.SelectedItems[0].Remove();
                        this.mListItems.Remove(itemOld);
                    }
                    this.CargarItemSalida(item);
                    this.txtTextSearch.Text = "";
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            Int32 idEntrada;
            try
            {
                if (this.lstItemsSalida.Items.Count > 0)
                {
                    if (MessageBox.Show("Quedan productos sin ingresar\r¿Desea dar por Terminada la Entrada de todas formas?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        idEntrada = this.grabarEntrada(true);
                        this.enviarReconciliarProductos(idEntrada);
                        entradaManager.getInstance().terminar(idEntrada);
                    }
                }
                else
                {
                    idEntrada = this.grabarEntrada(true);
                    entradaManager.getInstance().terminar(idEntrada);
                }
                this.btnSalir.PerformClick();
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstTecnicosEntrada_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo hitTestInfo = this.lstTecnicosEntrada.HitTest(e.X, e.Y);
                if (hitTestInfo.Item != null)
                {
                    //show the context menu strip
                    mnuCtxQuitar.Show(this.lstTecnicosEntrada, e.X, e.Y);
                }
            }

        }

        private void mnuCtxQuitar_Click(object sender, EventArgs e)
        {
            if (this.lstTecnicosEntrada.SelectedItems.Count > 0)
            {
                this.lstTecnicosEntrada.SelectedItems[0].Remove();
            }
        }

        private void btnAddOperador_Click(object sender, EventArgs e)
        {
            if (this.cmbOperadores.SelectedValue != null)
            {
                Tecnico tec = (Tecnico)this.cmbOperadores.SelectedValue;
                this.CargarTecnico(tec);
            }
        }
        #endregion                 

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if ((this.Width - this.splitContainer1.SplitterDistance) < 330)
                splitContainer1.SplitterDistance = this.Width - 330;
            else if (splitContainer1.SplitterDistance <= 570)
                splitContainer1.SplitterDistance = 570;
        }
    }
}
