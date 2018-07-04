using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ElAmigo
{
    public partial class frmBusquedaCliente : Form
    {
        private List<clsCliente> _ClientesEncontrados = new List<clsCliente>();

        public List<clsCliente> ClientesEncontrados
        {
            get { return _ClientesEncontrados; }
            set { _ClientesEncontrados = value; }
        }

        public frmBusquedaCliente()
        {
            InitializeComponent();
        }

        private void rbnTodosLosClientes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnTodosLosClientes.Checked == true)
            {
                dtpFechaDesde.Visible = false; dtpFechaHasta.Visible = false;
            }
            else
            {
                dtpFechaDesde.Visible = true; dtpFechaHasta.Visible = true;
            } 
        }

        private void rbnFechaRegistro_CheckedChanged(object sender, EventArgs e)
        {
            rbnTodosLosClientes_CheckedChanged(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbnTodosLosClientes.Checked==true)
            {
                ClientesEncontrados.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsCliente ELEMENTO in clsCliente.ListarClienteTodos())
                {

                    ClientesEncontrados.Add(ELEMENTO);
                    lstvDatos.Items.Add(ELEMENTO.IdCliente.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }

                    contador = contador + 1;
                }
            }
            else if (rbnFechaRegistro.Checked == true)
            {
                ClientesEncontrados.Clear();
                lstvDatos.Items.Clear();
                int contador = 1;
                foreach (clsCliente ELEMENTO in clsCliente.Listar_PorFechasDeRegistro(dtpFechaDesde.Value, dtpFechaHasta.Value))
                {
                    ClientesEncontrados.Add(ELEMENTO);
                    lstvDatos.Items.Add(ELEMENTO.IdCliente.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.NombresCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.ApellidosCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DNICli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.TelefonoCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.GeneroCli.ToString());
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.EmailCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DireccionCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.RUCCli);
                    lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.FechaInscripcion.ToString());
                    if (contador % 2 == 0)
                    {
                        lstvDatos.Items[contador - 1].BackColor = Color.Khaki;
                    }

                    contador = contador + 1;
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmReporteCliente reporte;
            reporte = new frmReporteCliente();
            reporte.clsClienteBindingSource.DataSource = ClientesEncontrados;

            ReportParameter parTitulo = null;
            if (rbnTodosLosClientes.Checked == true)
            {
                parTitulo = new ReportParameter("titulo", "CLIENTES REGISTRADOS");
            }
            else if (rbnFechaRegistro.Checked == true)
            {
                parTitulo = new ReportParameter("titulo", "Clientes (Registrados desde " + dtpFechaDesde.Value.ToShortDateString() + " hasta " + dtpFechaHasta.Value.ToShortDateString() + ")");
            }
            reporte.reportViewer1.LocalReport.SetParameters(parTitulo);
            ReportParameter parPie;
            parPie = new ReportParameter("pie", "Impreso el " + System.DateTime.Now.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString());
            reporte.reportViewer1.LocalReport.SetParameters(parPie);

            reporte.Show();
        }

    }
}
