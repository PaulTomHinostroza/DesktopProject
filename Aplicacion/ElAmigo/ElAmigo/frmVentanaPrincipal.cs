using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ElAmigo
{
    public partial class frmVentanaPrincipal : Form
    {
        public frmVentanaPrincipal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnSlider_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width==250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count>0)
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
            AbrirFormInPanel(new frmInsertarVenta());

            btnVentas.BackColor = Color.FromArgb(45,45,48);
            btnProductos.BackColor = Color.FromArgb(0, 122, 204);
            btnClientes.BackColor = Color.FromArgb(0, 122, 204);
            btnEmpleados.BackColor = Color.FromArgb(0, 122, 204);
            btnProveedores.BackColor = Color.FromArgb(0, 122, 204);
            btnAlmacen.BackColor = Color.FromArgb(0, 122, 204);
            btnReportes.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            btnVentas.BackColor = Color.FromArgb(0, 122, 204);
            btnProductos.BackColor = Color.FromArgb(0, 122, 204);
            btnClientes.BackColor = Color.FromArgb(45,45,48);
            btnEmpleados.BackColor = Color.FromArgb(0, 122, 204);
            btnProveedores.BackColor = Color.FromArgb(0, 122, 204);
            btnAlmacen.BackColor = Color.FromArgb(0, 122, 204);
            btnReportes.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmVentanaProducto());

            btnProductos.BackColor = Color.FromArgb(45,45,48);
            btnVentas.BackColor = Color.FromArgb(0, 122, 204);
            btnClientes.BackColor = Color.FromArgb(0, 122, 204);
            btnEmpleados.BackColor = Color.FromArgb(0, 122, 204);
            btnProveedores.BackColor = Color.FromArgb(0, 122, 204);
            btnAlmacen.BackColor = Color.FromArgb(0, 122, 204);
            btnReportes.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            btnProductos.BackColor = Color.FromArgb(0, 122, 204);
            btnVentas.BackColor = Color.FromArgb(0, 122, 204);
            btnClientes.BackColor = Color.FromArgb(0, 122, 204);
            btnEmpleados.BackColor = Color.FromArgb(0, 122, 204);
            btnProveedores.BackColor = Color.FromArgb(45, 45, 48);
            btnAlmacen.BackColor = Color.FromArgb(0, 122, 204);
            btnReportes.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            btnProductos.BackColor = Color.FromArgb(0, 122, 204);
            btnVentas.BackColor = Color.FromArgb(0, 122, 204);
            btnClientes.BackColor = Color.FromArgb(0, 122, 204);
            btnEmpleados.BackColor = Color.FromArgb(45, 45, 48);
            btnProveedores.BackColor = Color.FromArgb(0, 122, 204);
            btnAlmacen.BackColor = Color.FromArgb(0, 122, 204);
            btnReportes.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            btnProductos.BackColor = Color.FromArgb(0, 122, 204);
            btnVentas.BackColor = Color.FromArgb(0, 122, 204);
            btnClientes.BackColor = Color.FromArgb(0, 122, 204);
            btnEmpleados.BackColor = Color.FromArgb(0, 122, 204);
            btnProveedores.BackColor = Color.FromArgb(0, 122, 204);
            btnAlmacen.BackColor = Color.FromArgb(45,45,48);
            btnReportes.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            btnProductos.BackColor = Color.FromArgb(0, 122, 204);
            btnVentas.BackColor = Color.FromArgb(0, 122, 204);
            btnClientes.BackColor = Color.FromArgb(0, 122, 204);
            btnEmpleados.BackColor = Color.FromArgb(0, 122, 204);
            btnProveedores.BackColor = Color.FromArgb(0, 122, 204);
            btnAlmacen.BackColor = Color.FromArgb(0, 122, 204);
            btnReportes.BackColor = Color.FromArgb(45, 45, 48);
        }
    }
}
