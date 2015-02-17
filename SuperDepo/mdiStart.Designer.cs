namespace SuperDepo
{
    partial class mdiStart
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIngreso = new System.Windows.Forms.ToolStripMenuItem();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalidas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEntradas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLugares = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTiposProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTecnicos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.sbServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnEntradas = new System.Windows.Forms.Button();
            this.btnconsolidar = new System.Windows.Forms.Button();
            this.btnInformes = new System.Windows.Forms.Button();
            this.btnSalidas = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.entidadesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIngreso});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // mnuIngreso
            // 
            this.mnuIngreso.Name = "mnuIngreso";
            this.mnuIngreso.Size = new System.Drawing.Size(126, 22);
            this.mnuIngreso.Text = "Ingresar";
            this.mnuIngreso.Click += new System.EventHandler(this.mnuIngreso_Click);
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalidas,
            this.mnuEntradas,
            this.toolStripSeparator1,
            this.mnuClientes,
            this.mnuLugares,
            this.mnuProductos,
            this.mnuTiposProducto,
            this.mnuTecnicos,
            this.mnuUsuarios});
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            this.entidadesToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.entidadesToolStripMenuItem.Text = "AMB Entidades";
            // 
            // mnuSalidas
            // 
            this.mnuSalidas.Enabled = false;
            this.mnuSalidas.Name = "mnuSalidas";
            this.mnuSalidas.Size = new System.Drawing.Size(156, 22);
            this.mnuSalidas.Text = "Salidas";
            this.mnuSalidas.Click += new System.EventHandler(this.mnuSalidas_Click);
            // 
            // mnuEntradas
            // 
            this.mnuEntradas.Enabled = false;
            this.mnuEntradas.Name = "mnuEntradas";
            this.mnuEntradas.Size = new System.Drawing.Size(156, 22);
            this.mnuEntradas.Text = "Entradas";
            this.mnuEntradas.Click += new System.EventHandler(this.mnuEntradas_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // mnuClientes
            // 
            this.mnuClientes.Enabled = false;
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Size = new System.Drawing.Size(156, 22);
            this.mnuClientes.Text = "Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            // 
            // mnuLugares
            // 
            this.mnuLugares.Enabled = false;
            this.mnuLugares.Name = "mnuLugares";
            this.mnuLugares.Size = new System.Drawing.Size(156, 22);
            this.mnuLugares.Text = "Lugar Evento";
            this.mnuLugares.Click += new System.EventHandler(this.mnuLugares_Click);
            // 
            // mnuProductos
            // 
            this.mnuProductos.Enabled = false;
            this.mnuProductos.Name = "mnuProductos";
            this.mnuProductos.Size = new System.Drawing.Size(156, 22);
            this.mnuProductos.Text = "Productos";
            this.mnuProductos.Click += new System.EventHandler(this.mnuProductos_Click);
            // 
            // mnuTiposProducto
            // 
            this.mnuTiposProducto.Name = "mnuTiposProducto";
            this.mnuTiposProducto.Size = new System.Drawing.Size(156, 22);
            this.mnuTiposProducto.Text = "Tipos Producto";
            this.mnuTiposProducto.Click += new System.EventHandler(this.mnuTiposProducto_Click);
            // 
            // mnuTecnicos
            // 
            this.mnuTecnicos.Enabled = false;
            this.mnuTecnicos.Name = "mnuTecnicos";
            this.mnuTecnicos.Size = new System.Drawing.Size(156, 22);
            this.mnuTecnicos.Text = "Tecnicos";
            this.mnuTecnicos.Click += new System.EventHandler(this.mnuTecnicos_Click);
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Enabled = false;
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(156, 22);
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbServer,
            this.sbUser});
            this.statusBar.Location = new System.Drawing.Point(0, 441);
            this.statusBar.Name = "statusBar";
            this.statusBar.ShowItemToolTips = true;
            this.statusBar.Size = new System.Drawing.Size(1028, 25);
            this.statusBar.TabIndex = 16;
            // 
            // sbServer
            // 
            this.sbServer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sbServer.Image = global::SuperDepo.Properties.Resources.Server;
            this.sbServer.Name = "sbServer";
            this.sbServer.Size = new System.Drawing.Size(20, 20);
            this.sbServer.ToolTipText = "Servidor";
            // 
            // sbUser
            // 
            this.sbUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.sbUser.Image = global::SuperDepo.Properties.Resources.User;
            this.sbUser.Name = "sbUser";
            this.sbUser.Size = new System.Drawing.Size(20, 20);
            this.sbUser.ToolTipText = "Usuario";
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlContent.Location = new System.Drawing.Point(1, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1025, 359);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnEntradas);
            this.pnlMenu.Controls.Add(this.btnconsolidar);
            this.pnlMenu.Controls.Add(this.btnInformes);
            this.pnlMenu.Controls.Add(this.btnSalidas);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenu.Location = new System.Drawing.Point(0, 386);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1028, 55);
            this.pnlMenu.TabIndex = 18;
            // 
            // btnEntradas
            // 
            this.btnEntradas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEntradas.Enabled = false;
            this.btnEntradas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntradas.Location = new System.Drawing.Point(139, 4);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(125, 44);
            this.btnEntradas.TabIndex = 1;
            this.btnEntradas.Text = "&Entradas";
            this.btnEntradas.UseVisualStyleBackColor = false;
            this.btnEntradas.Click += new System.EventHandler(this.btnEntradas_Click);
            // 
            // btnconsolidar
            // 
            this.btnconsolidar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnconsolidar.Enabled = false;
            this.btnconsolidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconsolidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconsolidar.Location = new System.Drawing.Point(407, 4);
            this.btnconsolidar.Name = "btnconsolidar";
            this.btnconsolidar.Size = new System.Drawing.Size(125, 44);
            this.btnconsolidar.TabIndex = 3;
            this.btnconsolidar.Text = "&Consolidar";
            this.btnconsolidar.UseVisualStyleBackColor = false;
            this.btnconsolidar.Click += new System.EventHandler(this.btnconsolidar_Click);
            // 
            // btnInformes
            // 
            this.btnInformes.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnInformes.Enabled = false;
            this.btnInformes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformes.Location = new System.Drawing.Point(273, 4);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(125, 44);
            this.btnInformes.TabIndex = 2;
            this.btnInformes.Text = "&Informes";
            this.btnInformes.UseVisualStyleBackColor = false;
            this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
            // 
            // btnSalidas
            // 
            this.btnSalidas.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSalidas.Enabled = false;
            this.btnSalidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalidas.Location = new System.Drawing.Point(5, 4);
            this.btnSalidas.Name = "btnSalidas";
            this.btnSalidas.Size = new System.Drawing.Size(125, 44);
            this.btnSalidas.TabIndex = 0;
            this.btnSalidas.Text = "&Salidas";
            this.btnSalidas.UseVisualStyleBackColor = false;
            this.btnSalidas.Click += new System.EventHandler(this.btnSalidas_Click);
            // 
            // mdiStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 466);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1022, 500);
            this.Name = "mdiStart";
            this.Text = "SuperDepo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mdiStart_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuIngreso;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSalidas;
        private System.Windows.Forms.ToolStripMenuItem mnuEntradas;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuLugares;
        private System.Windows.Forms.ToolStripMenuItem mnuTecnicos;
        private System.Windows.Forms.ToolStripMenuItem mnuProductos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.Button btnSalidas;
        private System.Windows.Forms.ToolStripStatusLabel sbServer;
        private System.Windows.Forms.ToolStripStatusLabel sbUser;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Button btnconsolidar;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuTiposProducto;


    }
}

