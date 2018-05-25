namespace ElAmigo
{
    partial class frmListarClienteVenta
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
            this.lstvDatos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnDNI = new System.Windows.Forms.RadioButton();
            this.rbnId = new System.Windows.Forms.RadioButton();
            this.rbnApellidos = new System.Windows.Forms.RadioButton();
            this.rbnNombres = new System.Windows.Forms.RadioButton();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvDatos
            // 
            this.lstvDatos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader8});
            this.lstvDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvDatos.FullRowSelect = true;
            this.lstvDatos.GridLines = true;
            this.lstvDatos.Location = new System.Drawing.Point(7, 129);
            this.lstvDatos.MultiSelect = false;
            this.lstvDatos.Name = "lstvDatos";
            this.lstvDatos.Size = new System.Drawing.Size(1283, 430);
            this.lstvDatos.TabIndex = 132;
            this.lstvDatos.UseCompatibleStateImageBehavior = false;
            this.lstvDatos.View = System.Windows.Forms.View.Details;
            this.lstvDatos.DoubleClick += new System.EventHandler(this.lstvDatos_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 48;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombres";
            this.columnHeader2.Width = 204;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Apellidos";
            this.columnHeader3.Width = 301;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "DNI";
            this.columnHeader4.Width = 108;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Teléfono";
            this.columnHeader5.Width = 115;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Género";
            this.columnHeader6.Width = 64;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Email";
            this.columnHeader7.Width = 143;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Dirección";
            this.columnHeader9.Width = 163;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "RUC";
            this.columnHeader10.Width = 93;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Fecha Inscripcion";
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodos.Location = new System.Drawing.Point(744, 69);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(128, 35);
            this.btnMostrarTodos.TabIndex = 131;
            this.btnMostrarTodos.Text = "Mostrar Todos";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(1189, 580);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(99, 35);
            this.btnCancelar.TabIndex = 130;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnDNI);
            this.groupBox1.Controls.Add(this.rbnId);
            this.groupBox1.Controls.Add(this.rbnApellidos);
            this.groupBox1.Controls.Add(this.rbnNombres);
            this.groupBox1.Controls.Add(this.txtTexto);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 87);
            this.groupBox1.TabIndex = 129;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por:";
            // 
            // rbnDNI
            // 
            this.rbnDNI.AutoSize = true;
            this.rbnDNI.Location = new System.Drawing.Point(241, 23);
            this.rbnDNI.Name = "rbnDNI";
            this.rbnDNI.Size = new System.Drawing.Size(51, 22);
            this.rbnDNI.TabIndex = 4;
            this.rbnDNI.TabStop = true;
            this.rbnDNI.Text = "DNI";
            this.rbnDNI.UseVisualStyleBackColor = true;
            // 
            // rbnId
            // 
            this.rbnId.AutoSize = true;
            this.rbnId.Location = new System.Drawing.Point(198, 23);
            this.rbnId.Name = "rbnId";
            this.rbnId.Size = new System.Drawing.Size(37, 22);
            this.rbnId.TabIndex = 3;
            this.rbnId.TabStop = true;
            this.rbnId.Text = "Id";
            this.rbnId.UseVisualStyleBackColor = true;
            // 
            // rbnApellidos
            // 
            this.rbnApellidos.AutoSize = true;
            this.rbnApellidos.Location = new System.Drawing.Point(111, 23);
            this.rbnApellidos.Name = "rbnApellidos";
            this.rbnApellidos.Size = new System.Drawing.Size(85, 22);
            this.rbnApellidos.TabIndex = 2;
            this.rbnApellidos.TabStop = true;
            this.rbnApellidos.Text = "Apellidos";
            this.rbnApellidos.UseVisualStyleBackColor = true;
            // 
            // rbnNombres
            // 
            this.rbnNombres.AutoSize = true;
            this.rbnNombres.Checked = true;
            this.rbnNombres.Location = new System.Drawing.Point(17, 23);
            this.rbnNombres.Name = "rbnNombres";
            this.rbnNombres.Size = new System.Drawing.Size(88, 22);
            this.rbnNombres.TabIndex = 1;
            this.rbnNombres.TabStop = true;
            this.rbnNombres.Text = "Nombres";
            this.rbnNombres.UseVisualStyleBackColor = true;
            // 
            // txtTexto
            // 
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(17, 53);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(666, 24);
            this.txtTexto.TabIndex = 0;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 24);
            this.label3.TabIndex = 128;
            this.label3.Text = "Listado de Clientes";
            // 
            // frmListarClienteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 628);
            this.Controls.Add(this.lstvDatos);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Name = "frmListarClienteVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListarClienteVenta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstvDatos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnDNI;
        private System.Windows.Forms.RadioButton rbnId;
        private System.Windows.Forms.RadioButton rbnApellidos;
        private System.Windows.Forms.RadioButton rbnNombres;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label3;
    }
}