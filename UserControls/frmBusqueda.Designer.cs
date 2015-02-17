namespace UserControls
{
    partial class frmBusqueda
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
            if( disposing && ( components != null ) )
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new UserControls.Boton();
            this.btnCancelar = new UserControls.Boton();
            this.lblFiltro = new UserControls.Etiqueta();
            this.lblTitulo = new UserControls.Etiqueta();
            this.panel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.lblFiltro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 32);
            this.panel1.TabIndex = 1;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(58, 7);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(279, 20);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSeleccionar);
            this.pnlBottom.Controls.Add(this.btnCancelar);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 269);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(425, 35);
            this.pnlBottom.TabIndex = 2;
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrilla.Location = new System.Drawing.Point(0, 58);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.RowHeadersVisible = false;
            this.dgvGrilla.RowHeadersWidth = 35;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(425, 211);
            this.dgvGrilla.TabIndex = 3;
            this.dgvGrilla.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellDoubleClick);
            this.dgvGrilla.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellContentDoubleClick);
            this.dgvGrilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellClick);
            this.dgvGrilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellContentClick);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnSeleccionar.FocusRectangleEnabled = false;
            this.btnSeleccionar.Image = null;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.ImageBorderColor = System.Drawing.Color.Chocolate;
            this.btnSeleccionar.ImageBorderEnabled = false;
            this.btnSeleccionar.ImageDropShadow = false;
            this.btnSeleccionar.ImageFocused = null;
            this.btnSeleccionar.ImageInactive = null;
            this.btnSeleccionar.ImageMouseOver = null;
            this.btnSeleccionar.ImageNormal = null;
            this.btnSeleccionar.ImagePressed = null;
            this.btnSeleccionar.InnerBorderColor = System.Drawing.Color.LightGray;
            this.btnSeleccionar.InnerBorderColor_Focus = System.Drawing.Color.LightBlue;
            this.btnSeleccionar.InnerBorderColor_MouseOver = System.Drawing.Color.Gold;
            this.btnSeleccionar.Location = new System.Drawing.Point(279, 6);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.OffsetPressedContent = true;
            this.btnSeleccionar.RutaImagen = "";
            this.btnSeleccionar.Size = new System.Drawing.Size(73, 23);
            this.btnSeleccionar.StretchImage = false;
            this.btnSeleccionar.TabIndex = 1;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionar.TextDropShadow = true;
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnCancelar.FocusRectangleEnabled = false;
            this.btnCancelar.Image = null;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageBorderColor = System.Drawing.Color.Chocolate;
            this.btnCancelar.ImageBorderEnabled = false;
            this.btnCancelar.ImageDropShadow = false;
            this.btnCancelar.ImageFocused = null;
            this.btnCancelar.ImageInactive = null;
            this.btnCancelar.ImageMouseOver = null;
            this.btnCancelar.ImageNormal = null;
            this.btnCancelar.ImagePressed = null;
            this.btnCancelar.InnerBorderColor = System.Drawing.Color.LightGray;
            this.btnCancelar.InnerBorderColor_Focus = System.Drawing.Color.LightBlue;
            this.btnCancelar.InnerBorderColor_MouseOver = System.Drawing.Color.Gold;
            this.btnCancelar.Location = new System.Drawing.Point(358, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OffsetPressedContent = true;
            this.btnCancelar.RutaImagen = "";
            this.btnCancelar.Size = new System.Drawing.Size(60, 23);
            this.btnCancelar.StretchImage = false;
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextDropShadow = true;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.Location = new System.Drawing.Point(12, 4);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(48, 23);
            this.lblFiltro.TabIndex = 0;
            this.lblFiltro.Text = "Criterio:";
            this.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(425, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Seleccione el registro de la lista";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBusqueda
            // 
            this.ClientSize = new System.Drawing.Size(425, 304);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda";
            this.Load += new System.EventHandler(this.frm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Etiqueta lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlBottom;
        private UserControls.Boton btnSeleccionar;
        private Boton btnCancelar;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.TextBox txtFiltro;
        private Etiqueta lblFiltro;
      
    }
}