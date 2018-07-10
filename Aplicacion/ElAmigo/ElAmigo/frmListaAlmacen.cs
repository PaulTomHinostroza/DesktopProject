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
    public partial class frmListaAlmacen : Form
    {
        private List<clsAlmacen> _AlmacenesEncontrados = new List<clsAlmacen>();

        public List<clsAlmacen> AlmacenesEncontrados
        {
            get { return _AlmacenesEncontrados; }
            set { _AlmacenesEncontrados = value; }
        }

        public frmListaAlmacen()
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
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TipoAlm.ToString());
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
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TipoAlm.ToString());
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmListaAlmacen_Load(object sender, EventArgs e)
        {
            btnMostrarTodos.PerformClick();
        }

        private void rbnDireccion_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnId_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void BotonBuscar()
        {
            if (rbnDireccion.Checked == true)
            {
                btnBuscar.Visible = false;
            }
            else
            {
                btnBuscar.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbnId.Checked == true)
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
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TipoAlm.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionAlm.ToString());

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
                MessageBox.Show("Ingrese un código correcto");
            }
            
        }
    }
}
