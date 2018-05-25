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
    public partial class frmInsertarVenta : Form
    {
        public frmInsertarVenta()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //auxiliar
        private int _IdProd;

        public int IdProd
        {
            get { return _IdProd; }
            set { _IdProd = value; }
        }

        private void btnBusquedaCliente_Click(object sender, EventArgs e)
        {
            frmListarClienteVenta x;
            x = new frmListarClienteVenta();
            x.ShowDialog();

            if (x.ClienteSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtDatos.Text = x.ClienteSeleccionado.NombresCli;
                txtDocIdentidad.Text = x.ClienteSeleccionado.DNICli;

            }
            txtDocIdentidad.ReadOnly = true;
            txtDatos.ReadOnly = true;
        }

        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {
            frmListarProductoMedidaPrecioVenta x;
            x = new frmListarProductoMedidaPrecioVenta();
            x.ShowDialog();

            if (x.ProductoSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtDescripcion.Text = x.ProductoSeleccionado.DescripcionProd.ToString();
                IdProd = x.ProductoSeleccionado.IdProducto;


                cmbMedida.Items.Clear();
                foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(x.ProductoSeleccionado.IdProducto))
                {
                    cmbMedida.Items.Add(ELEMENTO.DescripcionMed);
                }
            }

        }

        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked == true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";
                }

            }
        }

        private void rbnGuia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked == true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";
                }

            }
        }

        private void cmbMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProductoMedida(IdProd, cmbMedida.SelectedItem.ToString()))
            {

                txtPVenta.Text = ELEMENTO.Precio.ToString();

            }
        }
    }
}
