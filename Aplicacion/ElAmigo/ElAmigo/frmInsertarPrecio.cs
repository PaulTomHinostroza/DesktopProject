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
    public partial class frmInsertarPrecio : Form
    {
        private List<clsMedida> _LasMedidas = new List<clsMedida>();

        public List<clsMedida> LasMedidas
        {
            get { return _LasMedidas; }
            set { _LasMedidas = value; }
        }

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

        public frmInsertarPrecio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmInsertarPrecio_Load(object sender, EventArgs e)
        {
            rbnDescripcion.Checked = true;
            LasMedidas.Clear();
            cmbMedida.Items.Clear();
            foreach (clsMedida elemento in clsMedida.ListarMedidaTodos())
            {
                LasMedidas.Add(elemento);
                cmbMedida.Items.Add(elemento.DescripcionMed);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                clsPrecio nuevoPrecio;
                nuevoPrecio = new clsPrecio(Convert.ToInt32(lblIdProducto.Text), LasMedidas[cmbMedida.SelectedIndex], Convert.ToDecimal(nudPrecio.Value));
                nuevoPrecio.InsertarPrecio();
                MessageBox.Show("Precio Registrado");
            }
            catch (Exception ErrorRegProd)
            {

                MessageBox.Show(ErrorRegProd.Message);
            }

            
        }

        private void lstvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvDatos.SelectedItems.Count > 0)
            {
                ProductoSeleccionado = ProductosEncontrados[lstvDatos.SelectedItems[0].Index];

                lstvPrecio.Items.Clear();
                int contador = 1;
                foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(ProductoSeleccionado.IdProducto))
                {

                    lstvPrecio.Items.Add(ELEMENTO.DescripcionMed);
                    lstvPrecio.Items[contador - 1].SubItems.Add(ELEMENTO.Precio.ToString());

                    if (contador % 2 == 0)
                    {
                        lstvPrecio.Items[contador - 1].BackColor = Color.DarkCyan;
                    }
                    contador = contador + 1;
                }

                lblIdProducto.Text = ProductoSeleccionado.IdProducto.ToString();
                txtProducto.Text = ProductoSeleccionado.DescripcionProd.ToString();
            }
      
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnDescripcion.Checked==true)
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
            if (rbnId.Checked==true)
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
