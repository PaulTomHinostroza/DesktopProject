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
    public partial class frmListarCliente : Form
    {
        
        private List<clsCliente> _ClienteEncontrado = new List<clsCliente>();

        public List<clsCliente> ClienteEncontrado
        {
            get { return _ClienteEncontrado; }
            set { _ClienteEncontrado = value; }
        }

        public frmListarCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            ClienteEncontrado.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsCliente ELEMENTO in clsCliente.ListarClienteTodos())
            {

                ClienteEncontrado.Add(ELEMENTO);
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
}
