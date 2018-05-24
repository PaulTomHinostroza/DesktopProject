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
    public partial class frmActualizarEliminarAlmacen : Form
    {

        private List<clsAlmacen> _AlmacenesEncontrados = new List<clsAlmacen>();

        public List<clsAlmacen> AlmacenesEncontrados
        {
            get { return _AlmacenesEncontrados; }
            set { _AlmacenesEncontrados = value; }
        }

        private clsAlmacen _AlmacenSeleccionado;

        public clsAlmacen AlmacenSeleccionado
        {
            get { return _AlmacenSeleccionado; }
            set { _AlmacenSeleccionado = value; }
        }

        public frmActualizarEliminarAlmacen()
        {
            InitializeComponent();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            AlmacenesEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenTodos())
            {
                AlmacenesEncontrados.Add(ELEMENTO);
                lstvDatos.Items.Add(ELEMENTO.IdAlmacen.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionAlm.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoAlm.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionAlm.ToString());

                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }
                contador = contador + 1;

            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnDireccion.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    AlmacenesEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenPorDireccion(txtTexto.Text))
                    {
                        AlmacenesEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdAlmacen.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionAlm.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoAlm.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionAlm.ToString());

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
                    AlmacenesEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenPorId(Convert.ToInt32(txtTexto.Text)))
                    {
                        AlmacenesEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdAlmacen.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionAlm.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoAlm.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionAlm.ToString());

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
                AlmacenSeleccionado = AlmacenesEncontrados[lstvDatos.SelectedItems[0].Index];

            }

            txtId.Text = AlmacenSeleccionado.IdAlmacen.ToString();
            txtDireccion.Text = AlmacenSeleccionado.DireccionAlm.ToString();
            txtTelefono.Text = AlmacenSeleccionado.TelefonoAlm.ToString();
            txtDescripcion.Text = AlmacenSeleccionado.DescripcionAlm.ToString();

            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtDescripcion.Enabled = false;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnLimpiar.Enabled = true;
        }



    }
}
