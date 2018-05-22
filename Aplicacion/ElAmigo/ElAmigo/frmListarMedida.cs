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
    public partial class frmListarMedida : Form
    {
        private List<clsMedida> _MedidaEncontrado = new List<clsMedida>();

        public List<clsMedida> MedidaEncontrado
        {
            get { return _MedidaEncontrado; }
            set { _MedidaEncontrado = value; }
        }

        public frmListarMedida()
        {
            InitializeComponent();
        }


        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            MedidaEncontrado.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsMedida ELEMENTO in clsMedida.ListarMedidaTodos())
            {
                MedidaEncontrado.Add(ELEMENTO);
                lstvDatos.Items.Add(ELEMENTO.IdMedida.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionMed);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.AbreviaturaMed);

                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }
                contador = contador + 1;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnDescripcion.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    MedidaEncontrado.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsMedida ELEMENTO in clsMedida.ListarMedidaPorDescripcion(txtTexto.Text))
                    {
                        MedidaEncontrado.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdMedida.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionMed);

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
                    MedidaEncontrado.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsMedida ELEMENTO in clsMedida.ListarMedidaPorId(Convert.ToInt32(txtTexto.Text)))
                    {
                        MedidaEncontrado.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdMedida.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionMed);

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

    }
}
