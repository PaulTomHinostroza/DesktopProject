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
    public partial class frmVentanaAlmacen : Form
    {
        public frmVentanaAlmacen()
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmInsertarAlmacen());
            btnNuevo.BackColor = Color.White;
            btnActualizar.BackColor = Color.FromArgb(237, 118, 14);
            btnListar.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmActualizarEliminarAlmacen());
            btnNuevo.BackColor = Color.FromArgb(237, 118, 14);
            btnActualizar.BackColor = Color.White;
            btnListar.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmListaAlmacen());
            btnNuevo.BackColor = Color.FromArgb(237, 118, 14);
            btnActualizar.BackColor = Color.FromArgb(237, 118, 14);
            btnListar.BackColor = Color.White;
        }

        private void frmVentanaAlmacen_Load(object sender, EventArgs e)
        {
            btnListar.PerformClick();
        }
    }
}
