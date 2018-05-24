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
    public partial class frmActualizarEliminarProveedor : Form
    {
        private List<clsProveedor> _ProveedoresEncontrados = new List<clsProveedor>();

        public List<clsProveedor> ProveedoresEncontrados
        {
            get { return _ProveedoresEncontrados; }
            set { _ProveedoresEncontrados = value; }
        }

        private clsProveedor _ProveedorSeleccionado;

        public clsProveedor ProveedorSeleccionado
        {
            get { return _ProveedorSeleccionado; }
            set { _ProveedorSeleccionado = value; }
        }

        public frmActualizarEliminarProveedor()
        {
            InitializeComponent();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ProveedoresEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsProveedor ELEMENTO in clsProveedor.ListarProveedorTodos())
            {
                ProveedoresEncontrados.Add(ELEMENTO);
                lstvDatos.Items.Add(ELEMENTO.IdProveedor.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreRazonProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NroCuentaProv.ToString());

                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }
                contador = contador + 1;
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnNombres.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    ProveedoresEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProveedor ELEMENTO in clsProveedor.ListarProveedorPorNombre(txtTexto.Text))
                    {
                        ProveedoresEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProveedor.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreRazonProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NroCuentaProv.ToString());

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
                    ProveedoresEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProveedor ELEMENTO in clsProveedor.ListarProveedorPorId(Convert.ToInt32(txtTexto.Text)))
                    {
                        ProveedoresEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProveedor.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreRazonProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NroCuentaProv.ToString());

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
                ProveedorSeleccionado = ProveedoresEncontrados[lstvDatos.SelectedItems[0].Index];

            }

            txtId.Text = ProveedorSeleccionado.IdProveedor.ToString();
            txtNombres.Text = ProveedorSeleccionado.NombreRazonProv.ToString();
            txtDireccion.Text = ProveedorSeleccionado.DireccionProv.ToString();
            txtTelefono.Text = ProveedorSeleccionado.TelefonoProv.ToString();
            txtEmail.Text = ProveedorSeleccionado.EmailProv.ToString();
            txtNroCuenta.Text = ProveedorSeleccionado.NroCuentaProv.ToString();


            //deshabilitar texbox

            txtNombres.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;
            txtNroCuenta.Enabled = false;
            txtTelefono.Enabled = false;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnLimpiar.Enabled = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.TextLength == 0)
            {
                MessageBox.Show("Selecciona un Dato.");
            }
            else
            {
                txtNombres.Enabled = true;
                txtDireccion.Enabled = true;
                txtEmail.Enabled = true;
                txtTelefono.Enabled = true;
                txtNroCuenta.Enabled = true;
                btnGuardar.Visible = true;
                btnActualizar.Visible = false;
                btnLimpiar.Enabled = false;
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsProveedor nuevosDatosProveedor;
            nuevosDatosProveedor = new clsProveedor(txtNombres.Text, txtTelefono.Text);
            nuevosDatosProveedor.DireccionProv = txtDireccion.Text;
            nuevosDatosProveedor.EmailProv = txtEmail.Text;
            nuevosDatosProveedor.NroCuentaProv = txtNroCuenta.Text;
            ProveedorSeleccionado.Actualizar(nuevosDatosProveedor);
            MessageBox.Show("Datos actualizados satisfactoriamente.");

            //Bloquear todo
            txtNombres.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtNroCuenta.Enabled = false;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            btnLimpiar.Enabled = true;
            txtTexto.Clear();
            lstvDatos.Items.Clear();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            txtId.Clear();
            txtNombres.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtNroCuenta.Clear();
            txtEmail.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }






    }
}
