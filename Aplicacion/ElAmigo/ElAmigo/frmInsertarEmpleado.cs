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
    public partial class frmInsertarEmpleado : Form
    {
        private List<clsCargo> _LosCargos = new List<clsCargo>();

        public List<clsCargo> LosCargos
        {
            get { return _LosCargos; }
            set { _LosCargos = value; }
        }

        public frmInsertarEmpleado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                clsEmpleado nuevoEmpleado;
                if (rbnMasculino.Checked == true)
                {
                    nuevoEmpleado = new clsEmpleado(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                    'M', Convert.ToDateTime(dtpFechaNacimiento.Value.Date), LosCargos[cmbCargo.SelectedIndex],txtUsuario.Text,txtPassword.Text);
                }
                else
                {
                    nuevoEmpleado = new clsEmpleado(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                    'F', Convert.ToDateTime(dtpFechaNacimiento.Value.Date), LosCargos[cmbCargo.SelectedIndex], txtUsuario.Text, txtPassword.Text);

                }
                nuevoEmpleado.TelefonoEmp = txtTelefono.Text;
                nuevoEmpleado.EmailEmp = txtEmail.Text;
                nuevoEmpleado.InsertarEmpleado();
                MessageBox.Show("Empleado Registrado");
            }
            catch (Exception ErrorRegEm)
            {

                MessageBox.Show(ErrorRegEm.Message);
            }
        }

        private void frmInsertarEmpleado_Load(object sender, EventArgs e)
        {
            LosCargos.Clear();
            cmbCargo.Items.Clear();
            foreach (clsCargo elemento in clsCargo.ListarCargoTodos())
            {
                cmbCargo.Items.Add(elemento.NombreCargo);
                LosCargos.Add(elemento);
            }
        }
    }
}
