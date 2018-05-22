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
    public partial class frmVentanaAdministrador : Form
    {
        public frmVentanaAdministrador()
        {
            InitializeComponent();
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MOSTRAR EL FORMULARIO
            frmInsertarProducto x;
            x = new frmInsertarProducto();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarProducto x;
            x = new frmListarProducto();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarProducto x;
            x = new frmActualizarEliminarProducto();
            x.ShowDialog();
        }

        private void insertarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmInsertarEmpleado x;
            x = new frmInsertarEmpleado();
            x.ShowDialog();
        }

        private void insertarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmInsertarCliente x;
            x = new frmInsertarCliente();
            x.ShowDialog();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsertarPrecio x;
            x = new frmInsertarPrecio();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarPrecio x;
            x = new frmActualizarEliminarPrecio();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListarPrecio x;
            x = new frmListarPrecio();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmActualizarStock x;
            x = new frmActualizarStock();
            x.ShowDialog();
        }

        private void insertarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInsertarStock x;
            x = new frmInsertarStock();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmListarStock x;
            x = new frmListarStock();
            x.ShowDialog();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInsertarMedida x;
            x = new frmInsertarMedida();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarMedida x;
            x = new frmActualizarEliminarMedida();
            x.ShowDialog();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListarMedida x;
            x = new frmListarMedida();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarEmpleado x;
            x = new frmActualizarEliminarEmpleado();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmListarEmpleado x;
            x = new frmListarEmpleado();
            x.ShowDialog();
        }

        private void insertarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmInsertarCargo x;
            x = new frmInsertarCargo();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarCargo x;
            x = new frmActualizarEliminarCargo();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmListarCargo x;
            x = new frmListarCargo();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarCliente x;
            x = new frmActualizarEliminarCliente();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmListarCliente x;
            x = new frmListarCliente();
            x.ShowDialog();
        }

        private void insertarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmInsertarAlmacen x;
            x = new frmInsertarAlmacen();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarAlmacen x;
            x = new frmActualizarEliminarAlmacen();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmListaAlmacen x;
            x = new frmListaAlmacen();
            x.ShowDialog();
        }

        private void insertarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmInsertarProveedor x;
            x = new frmInsertarProveedor();
            x.ShowDialog();
        }

        private void actualizarToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmActualizarEliminarProveedor x;
            x = new frmActualizarEliminarProveedor();
            x.ShowDialog();
        }

        private void listarToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmListarProveedor x;
            x = new frmListarProveedor();
            x.ShowDialog();
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsertarVenta x;
            x = new frmInsertarVenta();
            x.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
