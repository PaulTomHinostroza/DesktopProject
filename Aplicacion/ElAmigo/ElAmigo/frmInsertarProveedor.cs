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
    public partial class frmInsertarProveedor : Form
    {
        public frmInsertarProveedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                clsProveedor nuevoProveedor;
                nuevoProveedor = new clsProveedor(txtNombres.Text,txtNombreContacto.Text,txtCelularContacto.Text,txtTelefono.Text);
                nuevoProveedor.DireccionProv = txtDireccion.Text;
                nuevoProveedor.EmailProv = txtEmail.Text;
                nuevoProveedor.NroCuentaProv = txtNroCuenta.Text;
                nuevoProveedor.InsertarProveedor();
                MessageBox.Show("Proveedor Registrado");
            }
            catch (Exception ErrorRegProd)
            {

                MessageBox.Show(ErrorRegProd.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombres.Clear();
            txtCelularContacto.Clear();
            txtNombreContacto.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtNroCuenta.Clear();
        }
    }
}
