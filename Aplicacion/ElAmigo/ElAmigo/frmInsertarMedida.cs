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
    public partial class frmInsertarMedida : Form
    {
        private List<clsMedida> _MedidaEncontrado = new List<clsMedida>();

        public List<clsMedida> MedidaEncontrado
        {
            get { return _MedidaEncontrado; }
            set { _MedidaEncontrado = value; }
        }

        public frmInsertarMedida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                clsMedida nuevaMedida;
                nuevaMedida = new clsMedida(txtDescripcionMedida.Text, txtAbreviaturaDescripcion.Text);
                nuevaMedida.InsertarMedida();
                MessageBox.Show("Medida Registrado");
            }
            
            catch (Exception ErrorRegCli)
            {
                MessageBox.Show(ErrorRegCli.Message);

            }
        }

        private void txtDescripcionMedida_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcionMedida.Text.Length>=3)
            {
                MedidaEncontrado.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsMedida ELEMENTO in clsMedida.ListarMedidaPorDescripcion(txtDescripcionMedida.Text))
                {
                    MedidaEncontrado.Add(ELEMENTO);
                    lstvDatos.Items.Add(ELEMENTO.IdMedida.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionMed);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.AbreviaturaMed);

                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }

                }
            }
            else
            {
                lstvDatos.Items.Clear();
            }
        }
    }
}
