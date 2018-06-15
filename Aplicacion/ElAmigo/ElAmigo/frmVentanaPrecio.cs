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
    public partial class frmVentanaPrecio : Form
    {
        public frmVentanaPrecio()
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
            AbrirFormInPanel(new frmListarPrecio());
            btnListar.BackColor = Color.White;
            btnActualizar.BackColor = Color.FromArgb(0, 122, 204);
            btnNuevo.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmInsertarPrecio());
            btnListar.BackColor = Color.FromArgb(0, 122, 204);
            btnActualizar.BackColor = Color.FromArgb(0, 122, 204);
            btnNuevo.BackColor = Color.White;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmActualizarEliminarPrecio());
            btnListar.BackColor = Color.FromArgb(0, 122, 204);
            btnActualizar.BackColor = Color.White;
            btnNuevo.BackColor = Color.FromArgb(0, 122, 204);
        }
    }
}
