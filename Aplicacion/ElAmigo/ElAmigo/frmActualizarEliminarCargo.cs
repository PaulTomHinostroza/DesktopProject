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
    public partial class frmActualizarEliminarCargo : Form
    {
        private List<clsCargo> _CargosEncontrados = new List<clsCargo>();

        public List<clsCargo> CargosEncontrados
        {
            get { return _CargosEncontrados; }
            set { _CargosEncontrados = value; }
        }

        private clsCargo _CargoSeleccionado ;

        public clsCargo CargoSeleccionado
        {
            get { return _CargoSeleccionado; }
            set { _CargoSeleccionado = value; }
        }

        public frmActualizarEliminarCargo()
        {
            InitializeComponent();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnNombre.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    CargosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsCargo ELEMENTO in clsCargo.ListarCargoPorNombre(txtTexto.Text))
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
            if (rbnId.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    CargosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsCargo ELEMENTO in clsCargo.ListarCargoPorId(Convert.ToInt32(txtTexto.Text)))
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
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CargosEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsCargo ELEMENTO in clsCargo.ListarCargoTodos())
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

        private void lstvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvDatos.SelectedItems.Count > 0)
            {
                CargoSeleccionado = CargosEncontrados[lstvDatos.SelectedItems[0].Index];
            }

            txtId.Text = CargoSeleccionado.IdCargo.ToString();
            txtNombre.Text = CargoSeleccionado.NombreCargo.ToString();
            txtDescripcion.Text = CargoSeleccionado.DescripcionCargo.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.TextLength==0)
            {
                MessageBox.Show("Selecciona un dato.");
            }
            else
            {
                txtNombre.Enabled = true;
                txtDescripcion.Enabled = true;
                btnGuardar.Visible = true;
                btnActualizar.Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsCargo nuevoCargo;
            nuevoCargo = new clsCargo(txtNombre.Text);
            nuevoCargo.DescripcionCargo = txtDescripcion.Text;
            CargoSeleccionado.Actualizar(nuevoCargo);
            MessageBox.Show("Datos actualizados satisfactoriamente.");

            //Bloquear todo
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtId.Clear();
            lstvDatos.Items.Clear();
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            txtTexto.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
