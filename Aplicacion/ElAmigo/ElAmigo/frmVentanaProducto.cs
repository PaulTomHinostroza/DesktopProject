using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElAmigo
{
    public partial class frmVentanaProducto : Form
    {
        public frmVentanaProducto()
        {
            InitializeComponent();
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmListarProducto());
            btnListar.BackColor = Color.White;
            btnActualizar.BackColor = Color.FromArgb(237, 118, 14);
            btnNuevo.BackColor = Color.FromArgb(237, 118, 14);
            btnUnidadesMedida.BackColor = Color.FromArgb(237, 118, 14);
            btnPrecio.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmInsertarProducto());
            btnNuevo.BackColor = Color.White;
            btnListar.BackColor = Color.FromArgb(237, 118, 14);
            btnActualizar.BackColor = Color.FromArgb(237, 118, 14);
            btnUnidadesMedida.BackColor = Color.FromArgb(237, 118, 14);
            btnPrecio.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmActualizarEliminarProducto());
            btnNuevo.BackColor = Color.FromArgb(237, 118, 14);
            btnListar.BackColor = Color.FromArgb(237, 118, 14);
            btnActualizar.BackColor = Color.White;
            btnUnidadesMedida.BackColor = Color.FromArgb(237, 118, 14);
            btnPrecio.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmVentanaPrecio());
            btnNuevo.BackColor = Color.FromArgb(237, 118, 14);
            btnListar.BackColor = Color.FromArgb(237, 118, 14);
            btnActualizar.BackColor = Color.FromArgb(237, 118, 14);
            btnUnidadesMedida.BackColor = Color.FromArgb(237, 118, 14);
            btnPrecio.BackColor = Color.White;
        }

        private void btnUnidadesMedida_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmVentanaMedida());
            btnNuevo.BackColor = Color.FromArgb(237, 118, 14);
            btnListar.BackColor = Color.FromArgb(237, 118, 14);
            btnActualizar.BackColor = Color.FromArgb(237, 118, 14);
            btnUnidadesMedida.BackColor = Color.White;
            btnPrecio.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void frmVentanaProducto_Load(object sender, EventArgs e)
        {
            btnListar.PerformClick();
        }
        
    }
}
