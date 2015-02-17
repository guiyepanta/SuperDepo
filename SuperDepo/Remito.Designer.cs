namespace SuperDepo
{
    partial class frmRemito
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlHojas = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblCantidadHojas = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHojas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ShowPrintButton = false;
            this.reportViewer.Size = new System.Drawing.Size(716, 522);
            this.reportViewer.TabIndex = 0;
            // 
            // pnlHojas
            // 
            this.pnlHojas.BackColor = System.Drawing.Color.White;
            this.pnlHojas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHojas.Controls.Add(this.btnOk);
            this.pnlHojas.Controls.Add(this.lblCantidadHojas);
            this.pnlHojas.Controls.Add(this.pictureBox1);
            this.pnlHojas.Location = new System.Drawing.Point(191, 172);
            this.pnlHojas.Name = "pnlHojas";
            this.pnlHojas.Size = new System.Drawing.Size(355, 225);
            this.pnlHojas.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(143, 193);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(81, 26);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Imprimir";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblCantidadHojas
            // 
            this.lblCantidadHojas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadHojas.Location = new System.Drawing.Point(3, 122);
            this.lblCantidadHojas.Name = "lblCantidadHojas";
            this.lblCantidadHojas.Size = new System.Drawing.Size(346, 65);
            this.lblCantidadHojas.TabIndex = 1;
            this.lblCantidadHojas.Text = "Coloque en la impresora 3 hojas para imprimir remito oficial";
            this.lblCantidadHojas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SuperDepo.Properties.Resources.impresora;
            this.pictureBox1.Location = new System.Drawing.Point(108, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 115);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmRemito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 522);
            this.Controls.Add(this.pnlHojas);
            this.Controls.Add(this.reportViewer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRemito";
            this.ShowInTaskbar = false;
            this.Text = "Remito";
            this.Load += new System.EventHandler(this.frmRemito_Load);
            this.Resize += new System.EventHandler(this.frmRemito_Resize);
            this.pnlHojas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Panel pnlHojas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCantidadHojas;
        private System.Windows.Forms.Button btnOk;
    }
}