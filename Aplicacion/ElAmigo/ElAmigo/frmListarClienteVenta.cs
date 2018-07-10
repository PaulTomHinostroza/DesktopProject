using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ElAmigo
{
    public partial class frmListarClienteVenta : Form
    {
        //mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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


        public frmListarClienteVenta()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClienteSeleccionado = null;
            Close();
        }

        private void lstvDatos_DoubleClick(object sender, EventArgs e)
        {
            ClienteSeleccionado = ClientesEncontrados[lstvDatos.SelectedItems[0].Index];
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //mover el formulario
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void rbnNombres_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnApellidos_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnId_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnDNI_CheckedChanged(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese un código correcto.");
            }
            
        }


    }
}
