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
    public partial class frmActualizarEliminarProducto : Form
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

        public frmActualizarEliminarProducto()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion2.TextLength == 0)
            {
                MessageBox.Show("Selecciona un dato.");
            }
            else 
            {
                txtDescripcion2.Enabled = true;
                btnGuardar.Visible = true;
            }
            
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Crear un objeto de la clase clsProducto que tenga
            //  los nuevos datos
            clsProducto nuevoProducto;
            nuevoProducto = new clsProducto(txtDescripcion2.Text);
            ProductoSeleccionado.Actualizar(nuevoProducto);
            MessageBox.Show("Datos actualizados satisfactoriamente.");

            //Bloquear todo
            txtDescripcion2.Enabled = false;
            txtDescripcion2.Clear();
            txtId.Clear();
            btnGuardar.Visible = false;
            txtTexto.Clear();

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
            
        }

        private void lstvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = ProductoSeleccionado.IdProducto.ToString();
            txtDescripcion2.Text = ProductoSeleccionado.DescripcionProd.ToString();
        }

        private void lstvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvDatos.SelectedItems.Count > 0)
            {
                ProductoSeleccionado = ProductosEncontrados[lstvDatos.SelectedItems[0].Index];

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion2.Clear();
            txtId.Clear();
            txtTexto.Clear();

        }

        private void rbnDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnId_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void BotonBuscar()
        {
            if (rbnId.Checked == true)
            {
                btnBuscar.Visible = true;
            }
            else
            {
                btnBuscar.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbnId.Checked == true)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese un código correcto.");
            }
            
        }

    }
}
