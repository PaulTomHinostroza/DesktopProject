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
    public partial class frmActualizarEliminarEmpleado : Form
    {
        private List<clsEmpleado> _EmpleadosEncontrados = new List<clsEmpleado>();

        public List<clsEmpleado> EmpleadosEncontrados
        {
            get { return _EmpleadosEncontrados; }
            set { _EmpleadosEncontrados = value; }
        }

        private clsEmpleado _EmpleadoSeleccionado;

        public clsEmpleado EmpleadoSeleccionado
        {
            get { return _EmpleadoSeleccionado; }
            set { _EmpleadoSeleccionado = value; }
        }

        private List<clsCargo> _LosCargos = new List<clsCargo>();

        public List<clsCargo> LosCargos
        {
            get { return _LosCargos; }
            set { _LosCargos = value; }
        }

        public frmActualizarEliminarEmpleado()
        {
            InitializeComponent();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnNombres.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    EmpleadosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsEmpleado ELEMENTO in clsEmpleado.ListarEmpleadoPorNombres(txtTexto.Text))
                    {

                        EmpleadosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdEmpleado.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNIEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaNacEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcionEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Usuario.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Password.ToString());
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

            if (rbnApellidos.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    EmpleadosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsEmpleado ELEMENTO in clsEmpleado.ListarEmpleadoPorApellidos(txtTexto.Text))
                    {

                        EmpleadosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdEmpleado.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNIEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaNacEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcionEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Usuario.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Password.ToString());
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

            if (rbnDNI.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    EmpleadosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsEmpleado ELEMENTO in clsEmpleado.ListarEmpleadoPorDNI(txtTexto.Text))
                    {

                        EmpleadosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdEmpleado.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNIEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaNacEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcionEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Usuario.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Password.ToString());
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

            if (rbnCargo.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    EmpleadosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsEmpleado ELEMENTO in clsEmpleado.ListarEmpleadoPorCargo(txtTexto.Text))
                    {

                        EmpleadosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdEmpleado.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNIEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaNacEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcionEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Usuario.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Password.ToString());
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
            EmpleadosEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsEmpleado ELEMENTO in clsEmpleado.ListarEmpleadoTodos())
            {

                EmpleadosEncontrados.Add(ELEMENTO);
                lstvDatos.Items.Add(ELEMENTO.IdEmpleado.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNIEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaNacEmp.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcionEmp.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Usuario.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Password.ToString());
                if (contador % 2 == 0)
                {
                    lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                }

                contador = contador + 1;
            }
        }

        private void btnMostrarTodos_Click_1(object sender, EventArgs e)
        {
            EmpleadosEncontrados.Clear();
            lstvDatos.Items.Clear();
            int contador = 1;
            foreach (clsEmpleado ELEMENTO in clsEmpleado.ListarEmpleadoTodos())
            {

                EmpleadosEncontrados.Add(ELEMENTO);
                lstvDatos.Items.Add(ELEMENTO.IdEmpleado.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNIEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailEmp);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaNacEmp.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcionEmp.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Usuario.ToString());
                lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Password.ToString());
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
                EmpleadoSeleccionado = EmpleadosEncontrados[lstvDatos.SelectedItems[0].Index];

            }

            txtId.Text = EmpleadoSeleccionado.IdEmpleado.ToString();
            txtNombres.Text = EmpleadoSeleccionado.NombresEmp.ToString();
            txtApellidos.Text = EmpleadoSeleccionado.ApellidosEmp.ToString();
            txtDNI.Text = EmpleadoSeleccionado.DNIEmp.ToString();
            txtDireccion.Text = EmpleadoSeleccionado.DireccionEmp.ToString();
            dtpFechaNacimiento.Value = Convert.ToDateTime(EmpleadoSeleccionado.FechaNacEmp.Date);
            txtTelefono.Text = EmpleadoSeleccionado.TelefonoEmp.ToString();
            txtUsuario.Text = EmpleadoSeleccionado.Usuario.ToString();
            txtPassword.Text = EmpleadoSeleccionado.Password.ToString();

            if (EmpleadoSeleccionado.GeneroEmp.ToString()=="M")
            {
                rbnMasculino.Checked = true;
            }
            else
            {
                rbnFemenino.Checked = true;
            }

            txtEmail.Text = EmpleadoSeleccionado.EmailEmp.ToString();
            txtCargo.Text = EmpleadoSeleccionado.NombreCargo.ToString();

            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtDNI.Enabled = false;
            txtDireccion.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
            txtTelefono.Enabled = false;
            rbnMasculino.Enabled = false;
            rbnFemenino.Enabled = false;
            txtEmail.Enabled = false;
            txtCargo.Enabled = false;
            txtCargo.Visible = true;
            cmbCargo.Visible = false;
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.TextLength == 0)
            {
                MessageBox.Show("Selecciona un Dato.");
            }
            else
            {
                txtNombres.Enabled = true;
                txtApellidos.Enabled = true;
                txtDNI.Enabled = true;
                txtDireccion.Enabled = true;
                dtpFechaNacimiento.Enabled = true;
                txtTelefono.Enabled = true;
                rbnMasculino.Enabled = true;
                rbnFemenino.Enabled = true;
                txtEmail.Enabled = true;
                txtCargo.Visible = false;
                cmbCargo.Visible = true;
                btnGuardar.Visible = true;
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
            }
            

        }

        private void frmActualizarEliminarEmpleado_Load(object sender, EventArgs e)
        {
            LosCargos.Clear();
            cmbCargo.Items.Clear();
            foreach (clsCargo elemento in clsCargo.ListarCargoTodos())
            {
                cmbCargo.Items.Add(elemento.NombreCargo);
                LosCargos.Add(elemento);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsEmpleado nuevoEmpleado;
            if (rbnMasculino.Checked == true)
            {
                nuevoEmpleado = new clsEmpleado(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                'M', Convert.ToDateTime(dtpFechaNacimiento.Value.Date), LosCargos[cmbCargo.SelectedIndex],
                                                txtUsuario.Text,txtPassword.Text);
            }
            else
            {
                nuevoEmpleado = new clsEmpleado(txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtDireccion.Text,
                                                'F', Convert.ToDateTime(dtpFechaNacimiento.Value.Date), LosCargos[cmbCargo.SelectedIndex],
                                                txtUsuario.Text, txtPassword.Text);

            }
            nuevoEmpleado.TelefonoEmp = txtTelefono.Text;
            nuevoEmpleado.EmailEmp = txtEmail.Text;
            EmpleadoSeleccionado.Actualizar(nuevoEmpleado);
            MessageBox.Show("Datos actualizados satisfactoriamente.");

            //Bloquear todo
            txtNombres.Enabled = false;
            txtApellidos.Enabled = false;
            txtDNI.Enabled = false;
            txtDireccion.Enabled = false;
            dtpFechaNacimiento.Enabled = false;
            txtTelefono.Enabled = false;
            rbnMasculino.Enabled = false;
            rbnFemenino.Enabled = false;
            txtEmail.Enabled = false;
            txtCargo.Clear();
            txtCargo.Visible = true;
            cmbCargo.Visible = false;
            btnGuardar.Visible = false;
            txtUsuario.Enabled = false;
            txtPassword.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbnNombres_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnApellidos_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnId_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnDNI_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnCargo_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void BotonBuscar()
        {
            if (rbnId.Checked == true)
            {
                btnBuscar.Visible = true;
            }
            else
            {
                btnBuscar.Visible = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbnId.Checked == true)
                {
                    EmpleadosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsEmpleado ELEMENTO in clsEmpleado.ListarEmpleadoPorId(Convert.ToInt32(txtTexto.Text)))
                    {

                        EmpleadosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdEmpleado.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNIEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailEmp);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombreCargo);
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaNacEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcionEmp.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Usuario.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.Password.ToString());
                        if (contador % 2 == 0)
                        {
                            lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                        }

                        contador = contador + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese un código correcto.");
            }
            
        }
    }
}
