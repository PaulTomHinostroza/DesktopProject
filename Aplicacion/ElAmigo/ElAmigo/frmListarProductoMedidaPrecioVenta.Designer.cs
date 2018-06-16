namespace ElAmigo
{
    partial class frmListarProductoMedidaPrecioVenta
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
            this.lblIdMedida = new System.Windows.Forms.Label();
            this.lblIdProducto = new System.Windows.Forms.Label();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnId = new System.Windows.Forms.RadioButton();
            this.rbnDescripcion = new System.Windows.Forms.RadioButton();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.lstvDatos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.lstvPrecio = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdMedida = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCabezera = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelCabezera.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIdMedida
            // 
            this.lblIdMedida.AutoSize = true;
            this.lblIdMedida.Location = new System.Drawing.Point(367, 346);
            this.lblIdMedida.Name = "lblIdMedida";
            this.lblIdMedida.Size = new System.Drawing.Size(0, 13);
            this.lblIdMedida.TabIndex = 132;
            this.lblIdMedida.Visible = false;
            // 
            // lblIdProducto
            // 
            this.lblIdProducto.AutoSize = true;
            this.lblIdProducto.Location = new System.Drawing.Point(294, 346);
            this.lblIdProducto.Name = "lblIdProducto";
            this.lblIdProducto.Size = new System.Drawing.Size(0, 13);
            this.lblIdProducto.TabIndex = 131;
            this.lblIdProducto.Visible = false;
            // 
            // txtMedida
            // 
            this.txtMedida.Enabled = false;
            this.txtMedida.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedida.Location = new System.Drawing.Point(355, 409);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.ReadOnly = true;
            this.txtMedida.Size = new System.Drawing.Size(149, 22);
            this.txtMedida.TabIndex = 128;
            // 
            // txtProducto
            // 
            this.txtProducto.Enabled = false;
            this.txtProducto.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(355, 369);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(374, 22);
            this.txtProducto.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 126;
            this.label2.Text = "Producto:";
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Enabled = false;
            this.nudPrecio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrecio.Location = new System.Drawing.Point(355, 449);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(77, 22);
            this.nudPrecio.TabIndex = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(280, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 124;
            this.label6.Text = "Precio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(280, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 123;
            this.label8.Text = "Medida:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnId);
            this.groupBox1.Controls.Add(this.rbnDescripcion);
            this.groupBox1.Controls.Add(this.txtTexto);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 87);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Producto Por:";
            // 
            // rbnId
            // 
            this.rbnId.AutoSize = true;
            this.rbnId.Location = new System.Drawing.Point(139, 23);
            this.rbnId.Name = "rbnId";
            this.rbnId.Size = new System.Drawing.Size(37, 21);
            this.rbnId.TabIndex = 2;
            this.rbnId.Text = "Id";
            this.rbnId.UseVisualStyleBackColor = true;
            // 
            // rbnDescripcion
            // 
            this.rbnDescripcion.AutoSize = true;
            this.rbnDescripcion.Checked = true;
            this.rbnDescripcion.Location = new System.Drawing.Point(17, 23);
            this.rbnDescripcion.Name = "rbnDescripcion";
            this.rbnDescripcion.Size = new System.Drawing.Size(97, 21);
            this.rbnDescripcion.TabIndex = 1;
            this.rbnDescripcion.TabStop = true;
            this.rbnDescripcion.Text = "Descripción";
            this.rbnDescripcion.UseVisualStyleBackColor = true;
            // 
            // txtTexto
            // 
            this.txtTexto.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(17, 53);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(678, 22);
            this.txtTexto.TabIndex = 0;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // lstvDatos
            // 
            this.lstvDatos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvDatos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvDatos.FullRowSelect = true;
            this.lstvDatos.GridLines = true;
            this.lstvDatos.Location = new System.Drawing.Point(13, 104);
            this.lstvDatos.MultiSelect = false;
            this.lstvDatos.Name = "lstvDatos";
            this.lstvDatos.Size = new System.Drawing.Size(716, 228);
            this.lstvDatos.TabIndex = 120;
            this.lstvDatos.UseCompatibleStateImageBehavior = false;
            this.lstvDatos.View = System.Windows.Forms.View.Details;
            this.lstvDatos.SelectedIndexChanged += new System.EventHandler(this.lstvDatos_SelectedIndexChanged);
            this.lstvDatos.DoubleClick += new System.EventHandler(this.lstvDatos_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 48;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descripción";
            this.columnHeader2.Width = 648;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 119;
            this.label4.Text = "Precio";
            // 
            // lstvPrecio
            // 
            this.lstvPrecio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.IdMedida});
            this.lstvPrecio.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lstvPrecio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvPrecio.FullRowSelect = true;
            this.lstvPrecio.GridLines = true;
            this.lstvPrecio.Location = new System.Drawing.Point(13, 372);
            this.lstvPrecio.MultiSelect = false;
            this.lstvPrecio.Name = "lstvPrecio";
            this.lstvPrecio.Size = new System.Drawing.Size(250, 117);
            this.lstvPrecio.TabIndex = 118;
            this.lstvPrecio.UseCompatibleStateImageBehavior = false;
            this.lstvPrecio.View = System.Windows.Forms.View.Details;
            this.lstvPrecio.SelectedIndexChanged += new System.EventHandler(this.lstvPrecio_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Medida";
            this.columnHeader5.Width = 109;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Precio";
            this.columnHeader6.Width = 135;
            // 
            // IdMedida
            // 
            this.IdMedida.Text = "IdMedida";
            this.IdMedida.Width = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(629, 508);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 116;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 23);
            this.label3.TabIndex = 115;
            this.label3.Text = "LISTADO DE PRODUCTO-MEDIDA-PRECIO";
            // 
            // panelCabezera
            // 
            this.panelCabezera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelCabezera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCabezera.Controls.Add(this.label3);
            this.panelCabezera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabezera.Location = new System.Drawing.Point(0, 0);
            this.panelCabezera.Name = "panelCabezera";
            this.panelCabezera.Size = new System.Drawing.Size(745, 40);
            this.panelCabezera.TabIndex = 133;
            this.panelCabezera.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelCabezera_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.lblIdMedida);
            this.panel1.Controls.Add(this.lstvPrecio);
            this.panel1.Controls.Add(this.lblIdProducto);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMedida);
            this.panel1.Controls.Add(this.lstvDatos);
            this.panel1.Controls.Add(this.txtProducto);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nudPrecio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 560);
            this.panel1.TabIndex = 134;
            // 
            // frmListarProductoMedidaPrecioVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(745, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCabezera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListarProductoMedidaPrecioVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListarProductoMedidaPrecioVenta";
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelCabezera.ResumeLayout(false);
            this.panelCabezera.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIdMedida;
        private System.Windows.Forms.Label lblIdProducto;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnId;
        private System.Windows.Forms.RadioButton rbnDescripcion;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.ListView lstvDatos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lstvPrecio;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader IdMedida;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelCabezera;
        private System.Windows.Forms.Panel panel1;
    }
}