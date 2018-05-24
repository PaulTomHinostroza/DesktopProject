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
    public partial class frmInsertarAlmacen : Form
    {
        public frmInsertarAlmacen()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            
            try
            {
                clsAlmacen nuevoAlmacen;
                nuevoAlmacen = new clsAlmacen(txtDireccion.Text, txtTelefono.Text);
                nuevoAlmacen.DescripcionAlm = txtDescripcion.Text;
                nuevoAlmacen.InsertarAlmacen();
                MessageBox.Show("Almacen Registrado");
            }
            catch (Exception ErrorRegCli)
            {
                MessageBox.Show(ErrorRegCli.Message);

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
