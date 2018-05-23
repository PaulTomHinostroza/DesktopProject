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
    public partial class frmListarCargo : Form
    {
        private List<clsCargo> _CargosEncontrados = new List<clsCargo>();

        public List<clsCargo> CargosEncontrados
        {
            get { return _CargosEncontrados; }
            set { _CargosEncontrados = value; }
        }


        public frmListarCargo()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
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
    }
}
