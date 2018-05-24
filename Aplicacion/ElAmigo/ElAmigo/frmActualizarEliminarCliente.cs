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
    public partial class frmActualizarEliminarCliente : Form
    {

        private List<clsCliente> _ClientesEncontrados = new List<clsCliente>();

        public List<clsCliente> ClientesEncontrados
        {
            get { return _ClientesEncontrados; }
            set { _ClientesEncontrados = value; }
        }

        private clsCliente _ClienteSeleccionado;

        public clsCliente ClienteSeleccionado
        {
            get { return _ClienteSeleccionado; }
            set { _ClienteSeleccionado = value; }
        }

        public frmActualizarEliminarCliente()
        {
            InitializeComponent();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ClientesEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsCliente ELEMENTO in clsCliente.ListarClienteTodos())
            {

                ClientesEncontrados.Add(ELEMENTO);
                lstvDatos.Items.Add(ELEMENTO.IdCliente.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
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
                    ClientesEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsCliente ELEMENTO in clsCliente.ListarClientePorNombres(txtTexto.Text))
                    {

                        ClientesEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdCliente.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
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

            if (rbnApellidos.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    ClientesEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsCliente ELEMENTO in clsCliente.ListarClientePorApellidos(txtTexto.Text))
                    {

                        ClientesEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdCliente.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
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
                    ClientesEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsCliente ELEMENTO in clsCliente.ListarClientePorId(Convert.ToInt32(txtTexto.Text)))
                    {

                        ClientesEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdCliente.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
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

            if (rbnDNI.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    ClientesEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsCliente ELEMENTO in clsCliente.ListarClientePorDNI(txtTexto.Text))
                    {

                        ClientesEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdCliente.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
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
                ClienteSeleccionado = ClientesEncontrados[lstvDatos.SelectedItems[0].Index];

            }

            txtId.Text = ClienteSeleccionado.IdCliente.ToString();
            txtNombres.Text = ClienteSeleccionado.NombresCli.ToString();
            txtApellidos.Text = ClienteSeleccionado.ApellidosCli.ToString();
            txtDNI.Text = ClienteSeleccionado.DNICli.ToString();
            txtDireccion.Text = ClienteSeleccionado.DireccionCli.ToString();
            txtTelefono.Text = ClienteSeleccionado.TelefonoCli.ToString();

            if (ClienteSeleccionado.GeneroCli.ToString() == "M")
            {
                rbnMasculino.Checked = true;
            }
            else
            {
                rbnFemenino.Checked = true;
            }

            txtEmail.Text = ClienteSeleccionado.EmailCli.ToString();
            txtRUC.Text = ClienteSeleccionado.RUCCli.ToString();

            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtDNI.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            rbnMasculino.Enabled = false;
            rbnFemenino.Enabled = false;
            txtEmail.Enabled = false;
            txtRUC.Enabled = false;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtNombres.Enabled = true;
            txtApellidos.Enabled = true;
            txtDNI.Enabled = true;
            txtDireccion.Enabled = true;
            txtRUC.Enabled = true;
            txtTelefono.Enabled = true;
            rbnMasculino.Enabled = true;
            rbnFemenino.Enabled = true;
            txtEmail.Enabled = true;
            btnGuardar.Visible = true;
            btnLimpiar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsCliente nuevosDatosCliente;
            if (rbnMasculino.Checked == true)
            {
                nuevosDatosCliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                'M');
            }
            else
            {
                nuevosDatosCliente = new clsCliente(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                'F');
            }

            nuevosDatosCliente.TelefonoCli = txtTelefono.Text;
            nuevosDatosCliente.RUCCli = txtRUC.Text;
            nuevosDatosCliente.EmailCli = txtEmail.Text;
            ClienteSeleccionado.Actualizar(nuevosDatosCliente);
            MessageBox.Show("Datos actualizados satisfactoriamente.");

            //Bloquear todo
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtDNI.Enabled = false;
            txtDireccion.Enabled = false;
            txtRUC.Enabled = false;
            txtTelefono.Enabled = false;
            rbnMasculino.Enabled = false;
            rbnFemenino.Enabled = false;
            txtEmail.Enabled = false;
            btnGuardar.Visible = false;
            btnLimpiar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            txtRUC.Clear();
            txtTelefono.Clear();
            rbnMasculino.Checked = false;
            rbnFemenino.Checked = false;
            txtEmail.Clear();
            lstvDatos.Items.Clear();
            txtTexto.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }





    }
}
