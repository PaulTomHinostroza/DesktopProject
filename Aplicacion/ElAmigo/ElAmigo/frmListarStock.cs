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
    public partial class frmListarStock : Form
    {
        private List<clsProducto> _ProductosEncontrados = new List<clsProducto>();

        public List<clsProducto> ProductosEncontrados
        {
            get { return _ProductosEncontrados; }
            set { _ProductosEncontrados = value; }
        }

        private clsProducto _ProductoSeleccionado;

        public clsProducto ProductoSeleccionado
        {
            get { return _ProductoSeleccionado; }
            set { _ProductoSeleccionado = value; }
        }

        public frmListarStock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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
                    foreach (clsProducto ELEMENTO in clsProducto.ListarProductoPorDescripcion(txtTexto.Text))
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
                    foreach (clsProducto ELEMENTO in clsProducto.ListarProductoPorId(Convert.ToInt32(txtTexto.Text)))
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

                lstvCantidad.Items.Clear();
                int contador = 1;
                foreach (clsStock ELEMENTO in clsStock.ListarStockPorProducto(ProductoSeleccionado.IdProducto))
                {

                    lstvCantidad.Items.Add(ELEMENTO.DescripcionAlmacen.ToString());
                    lstvCantidad.Items[contador - 1].SubItems.Add(ELEMENTO.TipoAlm.ToString());
                    lstvCantidad.Items[contador - 1].SubItems.Add(ELEMENTO.CantidadST.ToString());
                    lstvCantidad.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionMedida.ToString());

                    if (contador % 2 == 0)
                    {
                        lstvCantidad.Items[contador - 1].BackColor = Color.DarkCyan;
                    }
                    contador = contador + 1;
                }
            }
        }

        private void frmListarStock_Load(object sender, EventArgs e)
        {
            ProductosEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsProducto ELEMENTO in clsProducto.ListarProductoTodos())
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
    }
}
