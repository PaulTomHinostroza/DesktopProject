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
    public partial class frmListarProducto : Form
    {
        private List<clsProducto> _ProductosEncontrados = new List<clsProducto>();

        public List<clsProducto> ProductosEncontrados
        {
            get { return _ProductosEncontrados; }
            set { _ProductosEncontrados = value; }
        }

        public frmListarProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
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



    }
}
