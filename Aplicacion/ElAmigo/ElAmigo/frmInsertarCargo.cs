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
    public partial class frmInsertarCargo : Form
    {
        private List<clsCargo> _CargosEncontrados = new List<clsCargo>();

        public List<clsCargo> CargosEncontrados
        {
            get { return _CargosEncontrados; }
            set { _CargosEncontrados = value; }
        }

        public frmInsertarCargo()
        {
            InitializeComponent();
        }

        private void btnRegistrarCargo_Click(object sender, EventArgs e)
        {
            try
            {
                clsCargo nuevoCargo;

                nuevoCargo = new clsCargo(txtNombre.Text);

                nuevoCargo.DescripcionCargo = txtDescripcion.Text;
                nuevoCargo.InsertarCargo();
                MessageBox.Show("Cargo Registrado");
            }
            catch (Exception ErrorRegCli)
            {
                MessageBox.Show(ErrorRegCli.Message);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
                if (txtNombre.Text.Length >= 3)
                {
                    CargosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsCargo ELEMENTO in clsCargo.ListarCargoPorNombre(txtNombre.Text))
                    {
                        CargosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdCargo.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionCargo);

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
        }
    }
}
