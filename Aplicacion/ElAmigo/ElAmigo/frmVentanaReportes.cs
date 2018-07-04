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
    public partial class frmVentanaReportes : Form
    {
        public frmVentanaReportes()
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

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBusquedaVenta());

            btnVentas.BackColor = Color.White;
            btnClientes.BackColor = Color.FromArgb(237, 118, 14);
            btnEmpleados.BackColor = Color.FromArgb(237, 118, 14);
            btnProductos.BackColor = Color.FromArgb(237, 118, 14);
            btnProveedores.BackColor = Color.FromArgb(237, 118, 14);
            btnStock.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBusquedaProducto());

            btnVentas.BackColor = Color.FromArgb(237, 118, 14);
            btnClientes.BackColor = Color.FromArgb(237, 118, 14);
            btnEmpleados.BackColor = Color.FromArgb(237, 118, 14);
            btnProductos.BackColor = Color.White;
            btnProveedores.BackColor = Color.FromArgb(237, 118, 14);
            btnStock.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBusquedaCliente());

            btnVentas.BackColor = Color.FromArgb(237, 118, 14);
            btnClientes.BackColor = Color.White;
            btnEmpleados.BackColor = Color.FromArgb(237, 118, 14);
            btnProductos.BackColor = Color.FromArgb(237, 118, 14);
            btnProveedores.BackColor = Color.FromArgb(237, 118, 14);
            btnStock.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBusquedaProveedor());

            btnVentas.BackColor = Color.FromArgb(237, 118, 14);
            btnClientes.BackColor = Color.FromArgb(237, 118, 14);
            btnEmpleados.BackColor = Color.FromArgb(237, 118, 14);
            btnProductos.BackColor = Color.FromArgb(237, 118, 14);
            btnProveedores.BackColor = Color.White;
            btnStock.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBusquedaEmpleado());

            btnVentas.BackColor = Color.FromArgb(237, 118, 14);
            btnClientes.BackColor = Color.FromArgb(237, 118, 14);
            btnEmpleados.BackColor = Color.White;
            btnProductos.BackColor = Color.FromArgb(237, 118, 14);
            btnProveedores.BackColor = Color.FromArgb(237, 118, 14);
            btnStock.BackColor = Color.FromArgb(237, 118, 14);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBusquedaVenta());

            btnVentas.BackColor = Color.FromArgb(237, 118, 14);
            btnClientes.BackColor = Color.FromArgb(237, 118, 14);
            btnEmpleados.BackColor = Color.FromArgb(237, 118, 14);
            btnProductos.BackColor = Color.FromArgb(237, 118, 14);
            btnProveedores.BackColor = Color.FromArgb(237, 118, 14);
            btnStock.BackColor = Color.White;
        }
    }
}
