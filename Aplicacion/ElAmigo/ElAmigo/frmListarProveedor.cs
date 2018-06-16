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
    public partial class frmListarProveedor : Form
    {
        private List<clsProveedor> _ProveedoresEncontrados = new List<clsProveedor>();

        public List<clsProveedor> ProveedoresEncontrados
        {
          get { return _ProveedoresEncontrados; }
          set { _ProveedoresEncontrados = value; }
        }

        public frmListarProveedor()
        {
            InitializeComponent();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnNombres.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    ProveedoresEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProveedor ELEMENTO in clsProveedor.ListarProveedorPorNombre(txtTexto.Text))
                    {
                        ProveedoresEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProveedor.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreRazonProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreContactoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.CelularContactoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NroCuentaProv.ToString());

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
                    ProveedoresEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProveedor ELEMENTO in clsProveedor.ListarProveedorPorId(Convert.ToInt32(txtTexto.Text)))
                    {
                        ProveedoresEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProveedor.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreRazonProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreContactoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.CelularContactoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NroCuentaProv.ToString());

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
            ProveedoresEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsProveedor ELEMENTO in clsProveedor.ListarProveedorTodos())
            {
                ProveedoresEncontrados.Add(ELEMENTO);
                lstvDatos.Items.Add(ELEMENTO.IdProveedor.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreRazonProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreContactoProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.CelularContactoProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionProv.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NroCuentaProv.ToString());

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

        private void frmListarProveedor_Load(object sender, EventArgs e)
        {
            btnMostrarTodos.PerformClick();
        }

    }
}
