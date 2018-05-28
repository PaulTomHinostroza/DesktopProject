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
    public partial class frmActualizarEliminarMedida : Form
    {
        private List<clsMedida> _MedidaEncontrado = new List<clsMedida>();

        public List<clsMedida> MedidaEncontrado
        {
            get { return _MedidaEncontrado; }
            set { _MedidaEncontrado = value; }
        }

        private clsMedida _MedidaSeleccionado;

        public clsMedida MedidaSeleccionado
        {
            get { return _MedidaSeleccionado; }
            set { _MedidaSeleccionado = value; }
        }

        public frmActualizarEliminarMedida()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.TextLength == 0)
            {
                MessageBox.Show("Selecciona un dato.");
            }
            else
            {
                txtDescripcion.Enabled = true;
                txtAbrev.Enabled = true;
                btnGuardar.Enabled = true;
                nudEquivalencia.Enabled = true;
            }
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
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.AbreviaturaMed);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EquivalenteUnidad.ToString());

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
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.AbreviaturaMed);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EquivalenteUnidad.ToString());

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
                MedidaSeleccionado = MedidaEncontrado[lstvDatos.SelectedItems[0].Index];

            }
        }

        private void lstvDatos_DoubleClick(object sender, EventArgs e)
        {
            txtId.Text = MedidaSeleccionado.IdMedida.ToString();
            txtDescripcion.Text = MedidaSeleccionado.DescripcionMed.ToString();
            txtAbrev.Text = MedidaSeleccionado.AbreviaturaMed.ToString();
            nudEquivalencia.Value = MedidaSeleccionado.EquivalenteUnidad;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsMedida nuevoMedida;
            nuevoMedida = new clsMedida(txtDescripcion.Text,txtAbrev.Text,Convert.ToInt32(nudEquivalencia.Value));
            MedidaSeleccionado.Actualizar(nuevoMedida);
            MessageBox.Show("Datos actualizados satisfactoriamente.");

            //Bloquear todo
            txtDescripcion.Enabled = false;
            txtDescripcion.Clear();
            txtAbrev.Enabled = false;
            nudEquivalencia.Enabled=false;
            txtAbrev.Clear();
            txtId.Clear();
            btnGuardar.Enabled = false;

            txtTexto.Clear();
        }


    }
}
