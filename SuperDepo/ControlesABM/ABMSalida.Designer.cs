namespace SuperDepo.ControlesABM
{
    partial class ABMSalida
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnuCtxQuitar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmdQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpSalida = new System.Windows.Forms.GroupBox();
            this.selClientes = new SuperDepo.ControlesUsuario.SelectEntity();
            this.selFechaArmado = new SuperDepo.ControlesUsuario.SelectDate();
            this.selLugarEvento = new SuperDepo.ControlesUsuario.SelectEntity();
            this.selFechaDesarme = new SuperDepo.ControlesUsuario.SelectDate();
            this.pnlTipoRemito = new System.Windows.Forms.Panel();
            this.btnCerrarPanelImprimir = new System.Windows.Forms.Button();
            this.btnResumido = new System.Windows.Forms.Button();
            this.lblCantidadHojas = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblLugarEvento = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.grdDetalleSalida = new System.Windows.Forms.DataGridView();
            this.codigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroSerieProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblTituloContent = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblShadowTitle = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.txtTextSearch = new System.Windows.Forms.TextBox();
            this.cmbTipoProductoFilter = new System.Windows.Forms.ComboBox();
            this.btnActualizarProductos = new System.Windows.Forms.Button();
            this.btnNewOperador = new System.Windows.Forms.Button();
            this.btnAddOperador = new System.Windows.Forms.Button();
            this.cmbOperadores = new System.Windows.Forms.ComboBox();
            this.lstTecnicos = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstProductos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFilterField = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mnuCtxQuitar.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpSalida.SuspendLayout();
            this.pnlTipoRemito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalleSalida)).BeginInit();
            this.grpDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuCtxQuitar
            // 
            this.mnuCtxQuitar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdQuitar});
            this.mnuCtxQuitar.Name = "mnuCtxQuitar";
            this.mnuCtxQuitar.Size = new System.Drawing.Size(116, 26);
            this.mnuCtxQuitar.Text = "Quitar Tecnico";
            this.mnuCtxQuitar.Click += new System.EventHandler(this.mnuCtxQuitar_Click);
            // 
            // cmdQuitar
            // 
            this.cmdQuitar.Image = global::SuperDepo.Properties.Resources.Add;
            this.cmdQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuitar.Name = "cmdQuitar";
            this.cmdQuitar.Size = new System.Drawing.Size(115, 22);
            this.cmdQuitar.Text = "Quitar";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpSalida);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloContent);
            this.splitContainer1.Panel1.Controls.Add(this.lblOwner);
            this.splitContainer1.Panel1.Controls.Add(this.lblShadowTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSalir);
            this.splitContainer1.Panel2.Controls.Add(this.btnImprimir);
            this.splitContainer1.Panel2.Controls.Add(this.btnLimpiar);
            this.splitContainer1.Panel2.Controls.Add(this.btnGuardar);
            this.splitContainer1.Panel2.Controls.Add(this.grpDetalle);
            this.splitContainer1.Size = new System.Drawing.Size(1069, 558);
            this.splitContainer1.SplitterDistance = 746;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // grpSalida
            // 
            this.grpSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSalida.Controls.Add(this.selClientes);
            this.grpSalida.Controls.Add(this.selFechaArmado);
            this.grpSalida.Controls.Add(this.selLugarEvento);
            this.grpSalida.Controls.Add(this.selFechaDesarme);
            this.grpSalida.Controls.Add(this.pnlTipoRemito);
            this.grpSalida.Controls.Add(this.textBox1);
            this.grpSalida.Controls.Add(this.label7);
            this.grpSalida.Controls.Add(this.label2);
            this.grpSalida.Controls.Add(this.txtCelular);
            this.grpSalida.Controls.Add(this.label1);
            this.grpSalida.Controls.Add(this.lblCelular);
            this.grpSalida.Controls.Add(this.txtTelefono);
            this.grpSalida.Controls.Add(this.lblTelefono);
            this.grpSalida.Controls.Add(this.lblLugarEvento);
            this.grpSalida.Controls.Add(this.txtContacto);
            this.grpSalida.Controls.Add(this.lblContacto);
            this.grpSalida.Controls.Add(this.lblCliente);
            this.grpSalida.Controls.Add(this.grdDetalleSalida);
            this.grpSalida.Location = new System.Drawing.Point(4, 49);
            this.grpSalida.Name = "grpSalida";
            this.grpSalida.Size = new System.Drawing.Size(741, 506);
            this.grpSalida.TabIndex = 3;
            this.grpSalida.TabStop = false;
            // 
            // selClientes
            // 
            this.selClientes.BackColor = System.Drawing.Color.Silver;
            this.selClientes.deltaWidth = 0;
            this.selClientes.DescriptionBackColor = System.Drawing.Color.White;
            this.selClientes.EntityId = 0;
            this.selClientes.EntityType = SuperDepo_CMM.appGlobals.EntityTipe.Clientes;
            this.selClientes.Location = new System.Drawing.Point(89, 14);
            this.selClientes.Name = "selClientes";
            this.selClientes.ShowBotonNew = true;
            this.selClientes.Size = new System.Drawing.Size(302, 21);
            this.selClientes.TabIndex = 1;
            this.selClientes.EntityIdChanged += new SuperDepo.ControlesUsuario.SelectEntity.EntityIdEventHandler(this.selClientes_EntityIdChanged);
            // 
            // selFechaArmado
            // 
            this.selFechaArmado.BackColor = System.Drawing.Color.Silver;
            this.selFechaArmado.Location = new System.Drawing.Point(471, 41);
            this.selFechaArmado.Name = "selFechaArmado";
            this.selFechaArmado.SeletedDate = new System.DateTime(2012, 9, 6, 0, 0, 0, 0);
            this.selFechaArmado.Size = new System.Drawing.Size(210, 22);
            this.selFechaArmado.TabIndex = 11;
            this.selFechaArmado.SelectDateChanged += new SuperDepo.ControlesUsuario.SelectDate.SelectDateEventHandler(this.selFechaArmado_SelectDateChanged);
            // 
            // selLugarEvento
            // 
            this.selLugarEvento.BackColor = System.Drawing.Color.Silver;
            this.selLugarEvento.deltaWidth = 0;
            this.selLugarEvento.DescriptionBackColor = System.Drawing.Color.White;
            this.selLugarEvento.EntityId = 0;
            this.selLugarEvento.EntityType = SuperDepo_CMM.appGlobals.EntityTipe.LugaresEvento;
            this.selLugarEvento.Location = new System.Drawing.Point(89, 42);
            this.selLugarEvento.Name = "selLugarEvento";
            this.selLugarEvento.ShowBotonNew = true;
            this.selLugarEvento.Size = new System.Drawing.Size(302, 21);
            this.selLugarEvento.TabIndex = 3;
            this.selLugarEvento.EntityIdChanged += new SuperDepo.ControlesUsuario.SelectEntity.EntityIdEventHandler(this.selLugarEvento_EntityIdChanged);
            // 
            // selFechaDesarme
            // 
            this.selFechaDesarme.BackColor = System.Drawing.Color.Silver;
            this.selFechaDesarme.Location = new System.Drawing.Point(471, 69);
            this.selFechaDesarme.Name = "selFechaDesarme";
            this.selFechaDesarme.SeletedDate = new System.DateTime(2012, 9, 6, 0, 0, 0, 0);
            this.selFechaDesarme.Size = new System.Drawing.Size(210, 22);
            this.selFechaDesarme.TabIndex = 13;
            this.selFechaDesarme.SelectDateChanged += new SuperDepo.ControlesUsuario.SelectDate.SelectDateEventHandler(this.selFechaDesarme_SelectDateChanged);
            // 
            // pnlTipoRemito
            // 
            this.pnlTipoRemito.BackColor = System.Drawing.Color.White;
            this.pnlTipoRemito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipoRemito.Controls.Add(this.btnCerrarPanelImprimir);
            this.pnlTipoRemito.Controls.Add(this.btnResumido);
            this.pnlTipoRemito.Controls.Add(this.lblCantidadHojas);
            this.pnlTipoRemito.Controls.Add(this.pictureBox1);
            this.pnlTipoRemito.Location = new System.Drawing.Point(173, 139);
            this.pnlTipoRemito.Name = "pnlTipoRemito";
            this.pnlTipoRemito.Size = new System.Drawing.Size(355, 225);
            this.pnlTipoRemito.TabIndex = 17;
            this.pnlTipoRemito.Visible = false;
            // 
            // btnCerrarPanelImprimir
            // 
            this.btnCerrarPanelImprimir.BackColor = System.Drawing.Color.Red;
            this.btnCerrarPanelImprimir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPanelImprimir.ForeColor = System.Drawing.Color.White;
            this.btnCerrarPanelImprimir.Location = new System.Drawing.Point(328, 1);
            this.btnCerrarPanelImprimir.Name = "btnCerrarPanelImprimir";
            this.btnCerrarPanelImprimir.Size = new System.Drawing.Size(24, 23);
            this.btnCerrarPanelImprimir.TabIndex = 0;
            this.btnCerrarPanelImprimir.Text = "X";
            this.btnCerrarPanelImprimir.UseVisualStyleBackColor = false;
            this.btnCerrarPanelImprimir.Click += new System.EventHandler(this.btnCerrarPanelImprimir_Click);
            // 
            // btnResumido
            // 
            this.btnResumido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnResumido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResumido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumido.Location = new System.Drawing.Point(108, 190);
            this.btnResumido.Name = "btnResumido";
            this.btnResumido.Size = new System.Drawing.Size(150, 26);
            this.btnResumido.TabIndex = 2;
            this.btnResumido.Text = "Remito legal";
            this.btnResumido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnResumido.UseVisualStyleBackColor = false;
            this.btnResumido.Click += new System.EventHandler(this.btnResumido_Click);
            // 
            // lblCantidadHojas
            // 
            this.lblCantidadHojas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadHojas.Location = new System.Drawing.Point(3, 136);
            this.lblCantidadHojas.Name = "lblCantidadHojas";
            this.lblCantidadHojas.Size = new System.Drawing.Size(346, 51);
            this.lblCantidadHojas.TabIndex = 1;
            this.lblCantidadHojas.Text = "Seleccione tipo de Remito a imprimir";
            this.lblCantidadHojas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SuperDepo.Properties.Resources.impresora;
            this.pictureBox1.Location = new System.Drawing.Point(108, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 115);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(87, 470);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(649, 32);
            this.textBox1.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 470);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "Observaciones:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(396, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "F. Desarme:";
            // 
            // txtCelular
            // 
            this.txtCelular.BackColor = System.Drawing.Color.White;
            this.txtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelular.Location = new System.Drawing.Point(471, 11);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(145, 21);
            this.txtCelular.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "F. Armado:";
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelular.Location = new System.Drawing.Point(396, 14);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(49, 15);
            this.lblCelular.TabIndex = 8;
            this.lblCelular.Text = "Celular:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(89, 94);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(209, 21);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(6, 97);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(58, 15);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblLugarEvento
            // 
            this.lblLugarEvento.AutoSize = true;
            this.lblLugarEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLugarEvento.Location = new System.Drawing.Point(5, 42);
            this.lblLugarEvento.Name = "lblLugarEvento";
            this.lblLugarEvento.Size = new System.Drawing.Size(82, 15);
            this.lblLugarEvento.TabIndex = 2;
            this.lblLugarEvento.Text = "Lugar Evento:";
            // 
            // txtContacto
            // 
            this.txtContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContacto.Location = new System.Drawing.Point(89, 68);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(209, 21);
            this.txtContacto.TabIndex = 5;
            this.txtContacto.TextChanged += new System.EventHandler(this.txtContacto_TextChanged);
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacto.Location = new System.Drawing.Point(6, 71);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(58, 15);
            this.lblContacto.TabIndex = 4;
            this.lblContacto.Text = "Contacto:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(5, 14);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(48, 15);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // grdDetalleSalida
            // 
            this.grdDetalleSalida.AllowUserToAddRows = false;
            this.grdDetalleSalida.AllowUserToDeleteRows = false;
            this.grdDetalleSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetalleSalida.BackgroundColor = System.Drawing.Color.White;
            this.grdDetalleSalida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDetalleSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetalleSalida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigoProducto,
            this.tipoProducto,
            this.DescripProducto,
            this.marcaProducto,
            this.modeloProducto,
            this.nroSerieProducto,
            this.colCantidad,
            this.colDelete});
            this.grdDetalleSalida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdDetalleSalida.Location = new System.Drawing.Point(3, 125);
            this.grdDetalleSalida.MultiSelect = false;
            this.grdDetalleSalida.Name = "grdDetalleSalida";
            this.grdDetalleSalida.ReadOnly = true;
            this.grdDetalleSalida.RowHeadersVisible = false;
            this.grdDetalleSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDetalleSalida.ShowEditingIcon = false;
            this.grdDetalleSalida.Size = new System.Drawing.Size(732, 342);
            this.grdDetalleSalida.TabIndex = 14;
            this.grdDetalleSalida.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDetalleSalida_CellContentClick);
            // 
            // codigoProducto
            // 
            this.codigoProducto.HeaderText = "Codigo";
            this.codigoProducto.Name = "codigoProducto";
            this.codigoProducto.ReadOnly = true;
            this.codigoProducto.Width = 70;
            // 
            // tipoProducto
            // 
            this.tipoProducto.HeaderText = "Tipo";
            this.tipoProducto.Name = "tipoProducto";
            this.tipoProducto.ReadOnly = true;
            this.tipoProducto.Width = 120;
            // 
            // DescripProducto
            // 
            this.DescripProducto.HeaderText = "Descripcion";
            this.DescripProducto.Name = "DescripProducto";
            this.DescripProducto.ReadOnly = true;
            this.DescripProducto.Width = 150;
            // 
            // marcaProducto
            // 
            this.marcaProducto.HeaderText = "Marca";
            this.marcaProducto.Name = "marcaProducto";
            this.marcaProducto.ReadOnly = true;
            // 
            // modeloProducto
            // 
            this.modeloProducto.HeaderText = "Modelo";
            this.modeloProducto.Name = "modeloProducto";
            this.modeloProducto.ReadOnly = true;
            // 
            // nroSerieProducto
            // 
            this.nroSerieProducto.HeaderText = "Nro Serie";
            this.nroSerieProducto.Name = "nroSerieProducto";
            this.nroSerieProducto.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.Text = "";
            this.colDelete.Width = 32;
            // 
            // lblTituloContent
            // 
            this.lblTituloContent.AutoSize = true;
            this.lblTituloContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblTituloContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTituloContent.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloContent.Location = new System.Drawing.Point(4, 8);
            this.lblTituloContent.Name = "lblTituloContent";
            this.lblTituloContent.Size = new System.Drawing.Size(218, 34);
            this.lblTituloContent.TabIndex = 0;
            this.lblTituloContent.Text = "NUEVA SALIDA";
            // 
            // lblOwner
            // 
            this.lblOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOwner.BackColor = System.Drawing.Color.White;
            this.lblOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOwner.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwner.Location = new System.Drawing.Point(527, 21);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(216, 25);
            this.lblOwner.TabIndex = 2;
            this.lblOwner.Text = "label2";
            this.lblOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShadowTitle
            // 
            this.lblShadowTitle.BackColor = System.Drawing.Color.Silver;
            this.lblShadowTitle.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShadowTitle.Location = new System.Drawing.Point(8, 12);
            this.lblShadowTitle.Name = "lblShadowTitle";
            this.lblShadowTitle.Size = new System.Drawing.Size(218, 34);
            this.lblShadowTitle.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(262, 525);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(52, 29);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(76, 525);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(108, 29);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir Remito";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(198, 525);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(60, 29);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(7, 525);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(65, 29);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grpDetalle
            // 
            this.grpDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetalle.Controls.Add(this.txtTextSearch);
            this.grpDetalle.Controls.Add(this.cmbTipoProductoFilter);
            this.grpDetalle.Controls.Add(this.btnActualizarProductos);
            this.grpDetalle.Controls.Add(this.btnNewOperador);
            this.grpDetalle.Controls.Add(this.btnAddOperador);
            this.grpDetalle.Controls.Add(this.cmbOperadores);
            this.grpDetalle.Controls.Add(this.lstTecnicos);
            this.grpDetalle.Controls.Add(this.lstProductos);
            this.grpDetalle.Controls.Add(this.label5);
            this.grpDetalle.Controls.Add(this.label6);
            this.grpDetalle.Controls.Add(this.cmbFilterField);
            this.grpDetalle.Controls.Add(this.label3);
            this.grpDetalle.Controls.Add(this.label4);
            this.grpDetalle.Enabled = false;
            this.grpDetalle.Location = new System.Drawing.Point(2, -2);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(312, 521);
            this.grpDetalle.TabIndex = 0;
            this.grpDetalle.TabStop = false;
            // 
            // txtTextSearch
            // 
            this.txtTextSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTextSearch.ForeColor = System.Drawing.Color.Black;
            this.txtTextSearch.Location = new System.Drawing.Point(123, 37);
            this.txtTextSearch.Name = "txtTextSearch";
            this.txtTextSearch.Size = new System.Drawing.Size(186, 21);
            this.txtTextSearch.TabIndex = 3;
            this.txtTextSearch.TextChanged += new System.EventHandler(this.txtTextSearch_TextChanged);
            // 
            // cmbTipoProductoFilter
            // 
            this.cmbTipoProductoFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoProductoFilter.FormattingEnabled = true;
            this.cmbTipoProductoFilter.Location = new System.Drawing.Point(123, 36);
            this.cmbTipoProductoFilter.Name = "cmbTipoProductoFilter";
            this.cmbTipoProductoFilter.Size = new System.Drawing.Size(186, 22);
            this.cmbTipoProductoFilter.TabIndex = 4;
            this.cmbTipoProductoFilter.Visible = false;
            this.cmbTipoProductoFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProductoFilter_SelectedIndexChanged);
            // 
            // btnActualizarProductos
            // 
            this.btnActualizarProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizarProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnActualizarProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarProductos.Location = new System.Drawing.Point(252, 12);
            this.btnActualizarProductos.Name = "btnActualizarProductos";
            this.btnActualizarProductos.Size = new System.Drawing.Size(57, 22);
            this.btnActualizarProductos.TabIndex = 19;
            this.btnActualizarProductos.Text = "Refresh";
            this.btnActualizarProductos.UseVisualStyleBackColor = false;
            this.btnActualizarProductos.Click += new System.EventHandler(this.btnActualizarProductos_Click);
            // 
            // btnNewOperador
            // 
            this.btnNewOperador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewOperador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNewOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOperador.Location = new System.Drawing.Point(267, 282);
            this.btnNewOperador.Name = "btnNewOperador";
            this.btnNewOperador.Size = new System.Drawing.Size(40, 22);
            this.btnNewOperador.TabIndex = 10;
            this.btnNewOperador.Text = "New";
            this.btnNewOperador.UseVisualStyleBackColor = false;
            this.btnNewOperador.Click += new System.EventHandler(this.btnNewOperador_Click);
            // 
            // btnAddOperador
            // 
            this.btnAddOperador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOperador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAddOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOperador.Location = new System.Drawing.Point(221, 282);
            this.btnAddOperador.Name = "btnAddOperador";
            this.btnAddOperador.Size = new System.Drawing.Size(40, 22);
            this.btnAddOperador.TabIndex = 9;
            this.btnAddOperador.Text = "Add";
            this.btnAddOperador.UseVisualStyleBackColor = false;
            this.btnAddOperador.Click += new System.EventHandler(this.btnAddOperador_Click);
            // 
            // cmbOperadores
            // 
            this.cmbOperadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOperadores.FormattingEnabled = true;
            this.cmbOperadores.Location = new System.Drawing.Point(4, 282);
            this.cmbOperadores.Name = "cmbOperadores";
            this.cmbOperadores.Size = new System.Drawing.Size(211, 22);
            this.cmbOperadores.TabIndex = 8;
            // 
            // lstTecnicos
            // 
            this.lstTecnicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTecnicos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lstTecnicos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTecnicos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lstTecnicos.FullRowSelect = true;
            this.lstTecnicos.Location = new System.Drawing.Point(4, 307);
            this.lstTecnicos.MultiSelect = false;
            this.lstTecnicos.Name = "lstTecnicos";
            this.lstTecnicos.Size = new System.Drawing.Size(305, 208);
            this.lstTecnicos.TabIndex = 11;
            this.lstTecnicos.UseCompatibleStateImageBehavior = false;
            this.lstTecnicos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Operador";
            this.columnHeader3.Width = 157;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Cargo";
            this.columnHeader4.Width = 128;
            // 
            // lstProductos
            // 
            this.lstProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lstProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstProductos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2});
            this.lstProductos.FullRowSelect = true;
            this.lstProductos.Location = new System.Drawing.Point(4, 67);
            this.lstProductos.Name = "lstProductos";
            this.lstProductos.Size = new System.Drawing.Size(305, 188);
            this.lstProductos.TabIndex = 5;
            this.lstProductos.UseCompatibleStateImageBehavior = false;
            this.lstProductos.View = System.Windows.Forms.View.Details;
            this.lstProductos.DoubleClick += new System.EventHandler(this.lstProductos_DoubleClick);
            this.lstProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstProductos_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Codigo";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tipo";
            this.columnHeader5.Width = 88;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripción";
            this.columnHeader2.Width = 210;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "INSTALACION/SOPORTE:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 19);
            this.label6.TabIndex = 7;
            // 
            // cmbFilterField
            // 
            this.cmbFilterField.FormattingEnabled = true;
            this.cmbFilterField.Items.AddRange(new object[] {
            "Codigo",
            "Tipo Producto",
            "Descripcion"});
            this.cmbFilterField.Location = new System.Drawing.Point(4, 37);
            this.cmbFilterField.Name = "cmbFilterField";
            this.cmbFilterField.Size = new System.Drawing.Size(117, 22);
            this.cmbFilterField.TabIndex = 2;
            this.cmbFilterField.SelectedIndexChanged += new System.EventHandler(this.cmbFilterField_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "BUSCAR PRODUCTO POR:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 19);
            this.label4.TabIndex = 1;
            // 
            // ABMSalida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ABMSalida";
            this.Size = new System.Drawing.Size(1069, 558);
            this.Load += new System.EventHandler(this.ABMSalida_Load);
            this.mnuCtxQuitar.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.grpSalida.ResumeLayout(false);
            this.grpSalida.PerformLayout();
            this.pnlTipoRemito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalleSalida)).EndInit();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuCtxQuitar;
        private System.Windows.Forms.ToolStripMenuItem cmdQuitar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpSalida;
        //private ControlesUsuario.SelectEntity selClientes;
        //private ControlesUsuario.SelectEntity selLugarEvento;
        private System.Windows.Forms.Panel pnlTipoRemito;
        private System.Windows.Forms.Button btnCerrarPanelImprimir;
        private System.Windows.Forms.Button btnResumido;
        private System.Windows.Forms.Label lblCantidadHojas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblLugarEvento;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridView grdDetalleSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroSerieProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.Label lblTituloContent;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblShadowTitle;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.TextBox txtTextSearch;
        private System.Windows.Forms.ComboBox cmbTipoProductoFilter;
        private System.Windows.Forms.Button btnActualizarProductos;
        private System.Windows.Forms.Button btnNewOperador;
        private System.Windows.Forms.Button btnAddOperador;
        private System.Windows.Forms.ComboBox cmbOperadores;
        private System.Windows.Forms.ListView lstTecnicos;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lstProductos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFilterField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ControlesUsuario.SelectDate selFechaArmado;
        private ControlesUsuario.SelectDate selFechaDesarme;
        private ControlesUsuario.SelectEntity selClientes;
        private ControlesUsuario.SelectEntity selLugarEvento;
    }
}
