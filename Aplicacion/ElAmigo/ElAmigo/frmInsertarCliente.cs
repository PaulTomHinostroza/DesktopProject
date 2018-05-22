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
    public partial class frmInsertarCliente : Form
    {
        public frmInsertarCliente()
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
                clsCliente nuevocliente;
                if (rbnMasculino.Checked == true)
                {
                    nuevocliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                    'M');
                }
                else
                {
                    nuevocliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                    'F');
                }

                nuevocliente.TelefonoCli = txtTelefono.Text;
                nuevocliente.RUCCli = txtRUC.Text;
                nuevocliente.EmailCli = txtEmail.Text;
                nuevocliente.InsertarCliente();
                MessageBox.Show("Cliente Registrado");
            }
            catch (Exception ErrorRegCli)
            {
                MessageBox.Show(ErrorRegCli.Message);

            }
        }
    }
}
