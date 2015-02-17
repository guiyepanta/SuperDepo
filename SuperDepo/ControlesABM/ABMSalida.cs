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
    public partial class ABMSalida : UserControl
    {
        private List<Producto> mlstPrd;
        bool toyCargado = false;
        public ABMSalida()
        {
            InitializeComponent();
        }

        public int IdSalida { get; set; }

        private void ABMSalida_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IdSalida != 0)
                {
                    this.cargarSalida();
                    this.btnImprimir.Enabled = true;
                }
                
                this.habilitarDetalle(this.comprobarCampos());

                this.lblOwner.Tag = appGlobals.gUser;
                this.lblOwner.Text = appGlobals.gUser.LastName + ", " + appGlobals.gUser.Name;
                this.selFechaArmado.SeletedDate = DateTime.Now;
                this.selFechaDesarme.SeletedDate = DateTime.Now;
                this.cmbFilterField.SelectedIndex = 0;
                this.cargarTiposProductos();
                this.cargarProductosDisponibles("", "");
                this.cargarTecnicos();
            }
            catch (Exception ex)
            {
                toyCargado = false;
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarTiposProductos()
        {
            toyCargado = true;
            System.Data.DataSet ds = new DataSet();
            ds = selectEntityManager.getInstance().getDatos(appGlobals.EntityTipe.TiposProducto);
            this.cmbTipoProductoFilter.DataSource = ds.Tables[0].DefaultView;
            this.cmbTipoProductoFilter.DisplayMember = "Descripcion";
            this.cmbTipoProductoFilter.ValueMember = "codigo";
            toyCargado = false;
        }
        #region Motodos privados

        private void cargarSalida()
        {
            Salida sl = new Salida();

            sl = salidaManager.getInstance().getSalida(this.IdSalida);

            this.grpSalida.Tag = sl;
            this.selClientes.AssignEntity = sl.Cliente.Id;
            this.selLugarEvento.AssignEntity = sl.lugarEvento.Id;
            this.txtContacto.Text = sl.Contacto;
            this.txtCelular.Text = sl.CelularSalida;
            this.txtTelefono.Text = sl.TelefonoSalida;
            this.selFechaArmado.SeletedDate = Convert.ToDateTime(sl.FechaArmado);
            this.selFechaDesarme.SeletedDate =Convert.ToDateTime(sl.FechaDesarme);

            if (sl.Items != null)
                foreach (ItemSalida iSa in sl.Items)
                {
                    this.CargarItemSalida(iSa);                
                }

            if (sl.Tecnicos != null)
                foreach (Tecnico tec in sl.Tecnicos)
                {
                    this.CargarTecnico(tec);    
                }
        }

        private void CargarTecnico(Tecnico tec)
        {
            ListViewItem it = new ListViewItem();
            it.Tag = tec;
            it.Text = tec.Nombre;
            it.Selected = false;
            it.SubItems.Add(new ListViewItem.ListViewSubItem(it, tec.Cargo));
            lstTecnicos.Items.Add(it);
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
        
        private void cargarProductosDisponibles(String campo, String criterio)
        {
            try
            {
                this.lstProductos.Items.Clear();
                mlstPrd = new List<Producto>();
                mlstPrd = productoManager.getInstance().cargarProductosDisponibles(campo, criterio);

                filtrarProductoDisponibles(campo, criterio);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show(ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ImprimirBorrador(Salida salida)
        {
            if (MessageBox.Show("La salida ya fue Remitida, estas por imprimir un borrador\r\n¿Deseas continuar?","Atención!",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                this.ImprimirRemito(salida);
        }

        private void ImprimirRemito(Salida salida)
        {
            this.pnlTipoRemito.Visible = true;
            this.pnlTipoRemito.Left = (this.grpSalida.Width / 2) - (this.pnlTipoRemito.Width / 2);
            this.pnlTipoRemito.Top = (this.grpSalida.Height / 2) - (this.pnlTipoRemito.Height / 2);            
        }

        private void filtrarProductoDisponibles(string campo, string criterio)
        {
            if (criterio == "")
            {
                var qAll = from p in mlstPrd
                           orderby p.Descripcion
                           select p;

                this.fillListaProductos(qAll);
            }
            else
                switch (campo)
                {
                    case "Codigo":
                        var qCod = from p in mlstPrd
                               where (p.CodigoProducto.ToUpper().StartsWith(criterio.ToUpper()))
                               orderby p.Descripcion
                               select p;

                        this.fillListaProductos(qCod);
                        break;
                    case "Descripcion":
                        var qDes = from p in mlstPrd
                               where (p.Descripcion.ToUpper().StartsWith(criterio.ToUpper()))
                               orderby p.Descripcion
                               select p;

                        this.fillListaProductos(qDes);
                        break;
                    case "Tipo Producto":
                        var qTipo = from p in mlstPrd
                               where (p.TipoProducto.ToUpper().StartsWith(criterio.ToUpper()))
                               orderby p.Descripcion
                               select p;

                        this.fillListaProductos(qTipo);
                        break;
                    default:
                        break;
                }
        }

        private void fillListaProductos(IOrderedEnumerable<Producto> q)
        {
            foreach (Producto pr in q)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pr.CodigoProducto;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, pr.TipoProducto));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, pr.Descripcion));
                item.Tag = pr;
                item.Selected = false;
                lstProductos.Items.Add(item);
            }
        }       
        
        private List<Tecnico> getTecnicos()
        {
            List<Tecnico> lstTec = new List<Tecnico>();
            foreach (ListViewItem item in this.lstTecnicos.Items)
            {
                lstTec.Add((Tecnico)item.Tag);                
            }

            return lstTec;
        }

        private List<ItemSalida> getItemsSalidas()
        {
            List<ItemSalida> lstItems = new List<ItemSalida>();

            foreach (DataGridViewRow row in this.grdDetalleSalida.Rows)
            {
                ItemSalida iSda = new ItemSalida();

                iSda.Id = 0;
                iSda.Return = false;
                iSda.Producto = new Producto();
                iSda.Producto.CodigoProducto = row.Cells[0].Value.ToString();
                iSda.Cantidad = Convert.ToInt32(row.Cells[6].Value);
                lstItems.Add(iSda);
            }

            return lstItems;
        }

        private void CargarItemSalida(ItemSalida itemS)
        {
            if (!this.yaExisteItem(itemS))
            {
                Producto prd = itemS.Producto;
                DataGridViewRow dgRow = new DataGridViewRow();
                DataGridViewCell cellCod = new DataGridViewTextBoxCell();
                DataGridViewCell cellTipo = new DataGridViewTextBoxCell();
                DataGridViewCell cellDesc = new DataGridViewTextBoxCell();
                DataGridViewCell cellMarca = new DataGridViewTextBoxCell();
                DataGridViewCell cellModelo = new DataGridViewTextBoxCell();
                DataGridViewCell cellSerie = new DataGridViewTextBoxCell();
                DataGridViewCell cellCant = new DataGridViewTextBoxCell();
                DataGridViewCell cellDelete = new DataGridViewButtonCell();

                cellCod.Tag = prd;
                cellCod.Value = prd.CodigoProducto;
                cellTipo.Value = prd.TipoProducto;
                cellDesc.Value = prd.Descripcion;
                cellMarca.Value = prd.MarcaProducto;
                cellModelo.Value = prd.ModeloProducto;
                cellSerie.Value = prd.SerieProducto;

                cellCant.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (itemS.Cantidad == 0)
                    if (prd.TipoExigeCantidad)
                    {
                        ControlesUsuario.inputBox iBox = new ControlesUsuario.inputBox();
                        iBox.Message = "Ingrese Cantidad para: " + prd.Descripcion;
                        if (iBox.ShowDialog() == DialogResult.OK)
                            cellCant.Value = iBox.Value;
                        iBox.Dispose();
                    }
                    else
                        cellCant.Value = 1;
                else
                    cellCant.Value = itemS.Cantidad;

                cellDelete.Value = "X";
                cellDelete.Style.ForeColor = Color.Red;

                dgRow.Cells.Add(cellCod);
                dgRow.Cells.Add(cellTipo);
                dgRow.Cells.Add(cellDesc);
                dgRow.Cells.Add(cellMarca);
                dgRow.Cells.Add(cellModelo);
                dgRow.Cells.Add(cellSerie);
                dgRow.Cells.Add(cellCant);
                dgRow.Cells.Add(cellDelete);

                this.grdDetalleSalida.Rows.Add(dgRow);
            }
        }

        private bool yaExisteItem(ItemSalida itemS)
        {
            foreach (DataGridViewRow dgRow in this.grdDetalleSalida.Rows)
            {
                if (dgRow.Cells[0].Value.ToString() == itemS.Producto.CodigoProducto)
                    return true;
            }
            return false;
        }

        private void LimpiarTodo()
        {
            this.IdSalida = 0;
            this.txtCelular.Text = "";
            this.txtContacto.Text = "";
            this.selFechaArmado.SeletedDate = DateTime.Now;
            this.selFechaDesarme.SeletedDate = DateTime.Now;
            this.txtTelefono.Text = "";
            this.txtTextSearch.Text = "";
            this.selClientes.limpiarTodo();
            this.selLugarEvento.limpiarTodo();
            this.btnActualizarProductos.PerformClick();
            this.lstTecnicos.Items.Clear();
            this.grdDetalleSalida.Rows.Clear();
            this.btnGuardar.Enabled = false;
        }

        #endregion

        #region Eventos Controles

        private void txtTextSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.lstProductos.Items.Clear();
                this.filtrarProductoDisponibles(cmbFilterField.Text, txtTextSearch.Text);                
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.LimpiarTodo();
            contentSalidas cSalidas = new contentSalidas();
            cSalidas.Dock = DockStyle.Fill;
            cSalidas.Parent = this.Parent;
            cSalidas.BringToFront();
            ((Panel)this.Parent).Controls.Add(cSalidas);
            ((Panel)this.Parent).Controls.Remove(this);
        }
        private void btnActualizarProductos_Click(object sender, EventArgs e)
        {
            this.cargarProductosDisponibles("", "");
        }

        private void btnAddOperador_Click(object sender, EventArgs e)
        {
            if (this.cmbOperadores.SelectedValue != null)
            {
                this.btnGuardar.Enabled = true;
                Tecnico tec = (Tecnico)this.cmbOperadores.SelectedValue;
                this.CargarTecnico(tec);
            }
        }

        private void btnNewOperador_Click(object sender, EventArgs e)
        {

        }

        private void grdDetalleSalida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                grdDetalleSalida.Rows.RemoveAt(e.RowIndex);
                this.habilitarDetalle(this.comprobarCampos());
                this.btnGuardar.Enabled = true;
            }

        }

        private void lstProductos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.btnGuardar.Enabled = true;
                Producto prd = (Producto)this.lstProductos.SelectedItems[0].Tag;
                ItemSalida itemS = new ItemSalida();
                itemS.Producto = prd;
                this.CargarItemSalida(itemS);
            }
            catch (Exception ex)
            {
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        private void lstTecnicos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewHitTestInfo hitTestInfo = this.lstTecnicos.HitTest(e.X,e.Y);
                if (hitTestInfo.Item != null)
                {
                    //show the context menu strip
                    mnuCtxQuitar.Show(this.lstTecnicos, e.X,e.Y);
                }
            }

        }

        private void mnuCtxQuitar_Click(object sender, EventArgs e)
        {
            if (this.lstTecnicos.SelectedItems.Count > 0)
            {
                this.lstTecnicos.SelectedItems[0].Remove();
            }
        }
 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnGuardar.Enabled = false;
                if (this.ValidarSalida())
                {
                    Salida Salida = new Salida();
                    Salida.Id = this.IdSalida;
                    Salida.Cliente = new Cliente();
                    Salida.Cliente.Id = this.selClientes.EntityId;
                    Salida.Contacto = this.txtContacto.Text;
                    Salida.CelularSalida = this.txtCelular.Text;
                    Salida.TelefonoSalida = this.txtTelefono.Text;
                    Salida.FechaArmado = this.selFechaArmado.SeletedDate.ToLongDateString();
                    Salida.FechaDesarme = this.selFechaDesarme.SeletedDate.ToLongDateString();
                    Salida.lugarEvento = new LugarEvento();
                    Salida.lugarEvento.Id = this.selLugarEvento.EntityId;
                    Salida.Observacion = "";
                    Salida.remitida = false;
                    Salida.Usuario = appGlobals.gUser;
                    Salida.Items = new List<ItemSalida>();
                    Salida.Items = this.getItemsSalidas();
                    Salida.Tecnicos = new List<Tecnico>();
                    Salida.Tecnicos = this.getTecnicos();

                    IdSalida = salidaManager.getInstance().Grabar(Salida);
                    Salida.Id = IdSalida;
                    this.grpSalida.Tag = Salida;

                    this.btnImprimir.Enabled = true;
                }
                else
                    MessageBox.Show("Faltan datos por completar.", "atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.btnGuardar.Enabled = true;
                ExceptionManager.log(ex.Message, ex.StackTrace);
                MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarSalida()
        {
            if (!comprobarCamposObligatorios())
                return false;

            if (grdDetalleSalida.Rows.Count <= 0)
                return false;

            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }
        
        private void selClientes_EntityIdChanged()
        {
            this.btnGuardar.Enabled = true;
            Cliente cl = new Cliente();

            cl = clienteManager.getInstance().getCliente(selClientes.EntityId);
            this.txtContacto.Text = cl.Contacto;
            this.txtCelular.Text = cl.telCelular;
            this.txtTelefono.Text = cl.telContacto;
            this.habilitarDetalle(this.comprobarCampos());
        }

        private void habilitarDetalle(bool habilitar)
        {
            this.grpDetalle.Enabled = habilitar;            
        }

        private bool comprobarCamposObligatorios()
        {
            if (this.selClientes.EntityId != 0
                && this.selLugarEvento.EntityId != 0
                && this.selFechaArmado.SeletedDate.Date != null
                && this.selFechaArmado.SeletedDate.Date <= this.selFechaDesarme.SeletedDate.Date
                && this.txtContacto.Text != ""
                && this.txtTelefono.Text != ""
                && this.lstTecnicos.Items.Count > 0)
            {
                return true;
            }

            return false;
        }

        private bool comprobarCampos()
        {
            if (this.selClientes.EntityId != 0
                && this.selLugarEvento.EntityId != 0
                && this.selFechaArmado.SeletedDate.Date != null
                && this.selFechaArmado.SeletedDate.Date <= this.selFechaDesarme.SeletedDate.Date
                && this.txtContacto.Text != ""
                && this.txtTelefono.Text != "")
            {
                return true;
            }

            return false;
        }

        private void selLugarEvento_EntityIdChanged()
        {
            this.btnGuardar.Enabled = true;
            this.habilitarDetalle(this.comprobarCampos());
        }

        private void txtContacto_TextChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
            this.habilitarDetalle(this.comprobarCampos());
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
            this.habilitarDetalle(this.comprobarCampos());
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
        }

        private void txtFechaArmado_TextChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
        }

        private void txtFechaDesarme_TextChanged(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
        }
        #endregion         

        private void lstProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.lstProductos.SelectedItems.Count > 0)
            {
                try
                {
                    this.btnGuardar.Enabled = true;
                    foreach (ListViewItem  item in this.lstProductos.SelectedItems)
                    {
                        Producto prd = (Producto)item.Tag;
                        ItemSalida itemS = new ItemSalida();
                        itemS.Producto = prd;
                        this.CargarItemSalida(itemS);    
                    }                    
                }
                catch (Exception ex)
                {
                    ExceptionManager.log(ex.Message, ex.StackTrace);
                    MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }             
            }
        }

        private void selFechaArmado_SelectDateChanged()
        {
            this.habilitarDetalle(this.comprobarCampos());
        }

        private void selFechaDesarme_SelectDateChanged()
        {
            this.habilitarDetalle(this.comprobarCampos());
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnResumido.Text = "Remito Legal";
                Salida sl = (Salida)grpSalida.Tag;          
                if (sl.remitida)
                { 
                    this.ImprimirBorrador(sl);
                }
                else
                {
                    this.ImprimirRemito(sl);
                }
            }
            catch (Exception ex)
            {
                    ExceptionManager.log(ex.Message, ex.StackTrace);
                    MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnResumido_Click(object sender, EventArgs e)
        {
            try
            {
                Salida sl = (Salida)grpSalida.Tag;
                    
                if (this.btnResumido.Text.ToUpper() == "REMITO LEGAL")
                {
                    //Remito Legal
                    frmRemito remitoLegal = new frmRemito();
                    remitoLegal.Salida = sl;
                    remitoLegal.RemitoLegal = true;
                    remitoLegal.StartPosition = FormStartPosition.CenterParent;
                    remitoLegal.ShowDialog();
                    remitoLegal.Dispose();

                    this.btnResumido.Text = "Imprimir Detalle";
                }
                else
                {
                    //Remito Detalle
                    frmRemito remito = new frmRemito();
                    remito.Salida = sl;
                    remito.RemitoLegal = false;
                    remito.StartPosition = FormStartPosition.CenterParent;
                    remito.ShowDialog();

                    this.btnResumido.Text = "Remito Legal";

                    this.pnlTipoRemito.Visible = false;
                }
            }
            catch (Exception ex)
            {
                    ExceptionManager.log(ex.Message, ex.StackTrace);
                    MessageBox.Show("Error:\r\n" + ex.Message, "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnCerrarPanelImprimir_Click(object sender, EventArgs e)
        {
            this.pnlTipoRemito.Visible = false;
        }

        private void txtTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (this.lstProductos.Items.Count == 1)
                {
                    Producto prd = (Producto)this.lstProductos.Items[0].Tag;
                    ItemSalida itemS = new ItemSalida();
                    itemS.Producto = prd;
                    this.CargarItemSalida(itemS);
                }
        }

        private void cmbFilterField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterField.Text == "Tipo Producto")
            {
                this.txtTextSearch.Visible = false;
                this.cmbTipoProductoFilter.Visible = true;
                this.cmbTipoProductoFilter.BringToFront();
            }
            else
            {
                this.txtTextSearch.Visible = true;
                this.cmbTipoProductoFilter.Visible = false;
                this.txtTextSearch.BringToFront();
            }
        }

        private void cmbTipoProductoFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!toyCargado)
            {
                this.lstProductos.Items.Clear();
                this.filtrarProductoDisponibles(this.cmbFilterField.Text, this.cmbTipoProductoFilter.Text);
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if ((this.Width - this.splitContainer1.SplitterDistance) < 320)
                splitContainer1.SplitterDistance = this.Width - 320;
            else if (splitContainer1.SplitterDistance <= 450)
                splitContainer1.SplitterDistance = 450;    
        }
    }
}
