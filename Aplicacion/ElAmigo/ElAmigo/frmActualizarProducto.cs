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
    public partial class frmActualizarProducto : Form
    {
        public frmActualizarProducto()
        {
            InitializeComponent();
        }

        private Boolean _Abierto;

        public Boolean Abierto
        {
            get { return _Abierto; }
            set { _Abierto = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Abierto = true;
        }
    }
}
