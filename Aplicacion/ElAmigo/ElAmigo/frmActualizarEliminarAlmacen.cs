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
            if (AlmacenSeleccionado.TipoAlm.ToString() == "PRINCIPAL")
            {
                rbnPrincipal.Checked = true;
            }
            else
            {
                rbnSecundario.Checked = true;
            }
                    

            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtDescripcion.Enabled = false;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnLimpiar.Enabled = true;
            rbnPrincipal.Enabled = false;
            rbnSecundario.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.TextLength==0)
            {
                MessageBox.Show("Selecciona un Dato.");
            }
            else
            {
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
                txtDescripcion.Enabled = true;
                btnGuardar.Visible = true;
                btnActualizar.Visible = false;
                btnLimpiar.Enabled = false;
                rbnPrincipal.Enabled = true;
                rbnSecundario.Enabled = true;
            }
 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                clsAlmacen nuevosDatosAlmacen;
                if (rbnPrincipal.Checked == true)
                {
                    nuevosDatosAlmacen = new clsAlmacen(txtDireccion.Text, txtTelefono.Text, "PRINCIPAL");
                }
                else
                {
                    nuevosDatosAlmacen = new clsAlmacen(txtDireccion.Text, txtTelefono.Text, "SECUNDARIO");
                }

                nuevosDatosAlmacen.DescripcionAlm = txtDescripcion.Text;
                AlmacenSeleccionado.Actualizar(nuevosDatosAlmacen);
                MessageBox.Show("Datos actualizados satisfactoriamente.");
            }
            catch (Exception ErrorRegCli)
            {
                MessageBox.Show(ErrorRegCli.Message);

            }
            

            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtDescripcion.Enabled = false;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnLimpiar.Enabled = true;
            rbnPrincipal.Enabled = false;
            rbnSecundario.Enabled = false;
            lstvDatos.Items.Clear();
            txtTexto.Clear();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtDescripcion.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtTexto.Clear();
            lstvDatos.Items.Clear();
            rbnPrincipal.Checked = false;
            rbnSecundario.Checked = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
