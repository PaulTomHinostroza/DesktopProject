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
    public partial class frmListarProductoMedidaPrecioVenta : Form
    {
        //mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private clsProducto _ProductoSeleccionado;

        public clsProducto ProductoSeleccionado
        {
            get { return _ProductoSeleccionado; }
            set { _ProductoSeleccionado = value; }
        }

        private clsPrecio _PrecioSeleccionado;

        public clsPrecio PrecioSeleccionado
        {
            get { return _PrecioSeleccionado; }
            set { _PrecioSeleccionado = value; }
        }

        private List<clsProducto> _ProductosEncontrados = new List<clsProducto>();

        public List<clsProducto> ProductosEncontrados
        {
            get { return _ProductosEncontrados; }
            set { _ProductosEncontrados = value; }
        }

        private List<clsPrecio> _PreciosEncontrados = new List<clsPrecio>();

        public List<clsPrecio> PreciosEncontrados
        {
            get { return _PreciosEncontrados; }
            set { _PreciosEncontrados = value; }
        }

        public frmListarProductoMedidaPrecioVenta()
        {
            InitializeComponent();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnDescripcion.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    ProductosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProducto ELEMENTO in clsProducto.ListarProductoPorDescripcionVenta(txtTexto.Text))
                    {
                        ProductosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProducto.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionProd);

                        if (contador % 2 == 0)
                        {
                            lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                        }
                        contador = contador + 1;
                    }

                }
                else
                {
                    lstvDatos.Items.Clear();
                }
            }
            if (rbnId.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    ProductosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProducto ELEMENTO in clsProducto.ListarProductoPorIdVenta(Convert.ToInt32(txtTexto.Text)))
                    {
                        ProductosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProducto.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionProd);

                        if (contador % 2 == 0)
                        {
                            lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                        }
                        contador = contador + 1;
                    }

                }
                else
                {
                    lstvDatos.Items.Clear();
                }
            }
        }

        private void lstvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvDatos.SelectedItems.Count > 0)
            {
                ProductoSeleccionado = ProductosEncontrados[lstvDatos.SelectedItems[0].Index];

                PreciosEncontrados.Clear();
                lstvPrecio.Items.Clear();
                int contador = 1;
                foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(ProductoSeleccionado.IdProducto))
                {
                    PreciosEncontrados.Add(ELEMENTO);
                    lstvPrecio.Items.Add(ELEMENTO.DescripcionMed);
                    lstvPrecio.Items[contador - 1].SubItems.Add(ELEMENTO.Precio.ToString());
                    lstvPrecio.Items[contador - 1].SubItems.Add(ELEMENTO.IdMedidaInt.ToString());

                    if (contador % 2 == 0)
                    {
                        lstvPrecio.Items[contador - 1].BackColor = Color.DarkCyan;
                    }
                    contador = contador + 1;
                }
            }

            lblIdProducto.Text = ProductoSeleccionado.IdProducto.ToString();
            txtProducto.Text = ProductoSeleccionado.DescripcionProd.ToString();
            nudPrecio.Value = 0;
            txtMedida.Clear();
        }

        private void lstvPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvPrecio.SelectedItems.Count > 0)
            {
                PrecioSeleccionado = PreciosEncontrados[lstvPrecio.SelectedItems[0].Index];
            }

            lblIdMedida.Text = PrecioSeleccionado.IdMedidaInt.ToString();
            txtMedida.Text = PrecioSeleccionado.DescripcionMed.ToString();
            nudPrecio.Value = PrecioSeleccionado.Precio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstvDatos_DoubleClick(object sender, EventArgs e)
        {
            ProductoSeleccionado = ProductosEncontrados[lstvDatos.SelectedItems[0].Index];
            Close();
        }

        private void panelCabezera_MouseDown(object sender, MouseEventArgs e)
        {
            //mover el formulario
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



    }
}
