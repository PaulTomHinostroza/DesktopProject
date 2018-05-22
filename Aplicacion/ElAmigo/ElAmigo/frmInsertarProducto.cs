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
    public partial class frmInsertarProducto : Form
    {
        private clsProducto _ProductoSeleccionado;

        public clsProducto ProductoSeleccionado
        {
            get { return _ProductoSeleccionado; }
            set { _ProductoSeleccionado = value; }
        }

        private List<clsProducto> _ProductosEncontrados = new List<clsProducto>();

        public List<clsProducto> ProductosEncontrados
        {
            get { return _ProductosEncontrados; }
            set { _ProductosEncontrados = value; }
        }

        public frmInsertarProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                clsProducto nuevoProducto;
                nuevoProducto = new clsProducto(txtDescripcionRegistro.Text);
                nuevoProducto.InsertarProducto();
                MessageBox.Show("Producto Registrado");
            }
            catch (Exception ErrorRegProd)
            {

                MessageBox.Show(ErrorRegProd.Message);
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcionRegistro.Text = txtDescripcion.Text;

            if (txtDescripcion.Text.Length >= 3)
            {
                ProductosEncontrados.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsProducto ELEMENTO in clsProducto.ListarProductoPorDescripcion(txtDescripcion.Text))
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
