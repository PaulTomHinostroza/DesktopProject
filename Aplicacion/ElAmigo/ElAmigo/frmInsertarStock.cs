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
    public partial class frmInsertarStock : Form
    {
        private List<clsProducto> _ProductosEncontrados = new List<clsProducto>();

        public List<clsProducto> ProductosEncontrados
        {
            get { return _ProductosEncontrados; }
            set { _ProductosEncontrados = value; }
        }

        private clsProducto _ProductoSeleccionado;

        public clsProducto ProductoSeleccionado
        {
            get { return _ProductoSeleccionado; }
            set { _ProductoSeleccionado = value; }
        }

        private List<clsMedida> _LasMedidas = new List<clsMedida>();

        public List<clsMedida> LasMedidas
        {
            get { return _LasMedidas; }
            set { _LasMedidas = value; }
        }

        private List<clsAlmacen> _LosAlmacenes = new List<clsAlmacen>();

        public List<clsAlmacen> LosAlmacenes
        {
            get { return _LosAlmacenes; }
            set { _LosAlmacenes = value; }
        }


        public frmInsertarStock()
        {
            InitializeComponent();
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (rbnDescripcion.Checked == true)
            {
                if (txtTexto.Text.Length >= 3)
                {
                    ProductosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProducto ELEMENTO in clsProducto.ListarProductoPorDescripcion(txtTexto.Text))
                    {
                        ProductosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProducto.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionProd);

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
                ProductoSeleccionado = ProductosEncontrados[lstvDatos.SelectedItems[0].Index];

                lstvCantidad.Items.Clear();
                int contador = 1;
                foreach (clsStock ELEMENTO in clsStock.ListarStockPorProducto(ProductoSeleccionado.IdProducto))
                {

                    lstvCantidad.Items.Add(ELEMENTO.DescripcionAlmacen.ToString());
                    lstvCantidad.Items[contador - 1].SubItems.Add(ELEMENTO.TipoAlm.ToString());
                    lstvCantidad.Items[contador - 1].SubItems.Add(ELEMENTO.CantidadST.ToString());
                    lstvCantidad.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionMedida.ToString());

                    if (contador % 2 == 0)
                    {
                        lstvCantidad.Items[contador - 1].BackColor = Color.DarkCyan;
                    }
                    contador = contador + 1;
                }

                lblIdProducto.Text = ProductoSeleccionado.IdProducto.ToString();
                txtProducto.Text = ProductoSeleccionado.DescripcionProd.ToString();
            }

        }

        private void frmInsertarStock_Load(object sender, EventArgs e)
        {
            rbnDescripcion.Checked = true;
            LasMedidas.Clear();
            cmbMedida.Items.Clear();
            foreach (clsMedida elemento in clsMedida.ListarMedidaTodos())
            {
                LasMedidas.Add(elemento);
                cmbMedida.Items.Add(elemento.DescripcionMed);
            }

            LosAlmacenes.Clear();
            cmbAlmacen.Items.Clear();
            foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenTodos())
            {
                LosAlmacenes.Add(ELEMENTO);
                cmbAlmacen.Items.Add(ELEMENTO.DireccionAlm);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                clsStock nuevoStock;
                nuevoStock = new clsStock(Convert.ToInt32(lblIdProducto.Text), LosAlmacenes[cmbAlmacen.SelectedIndex], LasMedidas[cmbMedida.SelectedIndex], Convert.ToDecimal(nudCantidad.Value));
                nuevoStock.InsertarStock();
                MessageBox.Show("Stock Registrado");

            }
            catch (Exception ErrorRegProd)
            {

                MessageBox.Show(ErrorRegProd.Message);
            }

            LasMedidas.Clear();
            cmbMedida.Items.Clear();
            foreach (clsMedida elemento in clsMedida.ListarMedidaTodos())
            {
                LasMedidas.Add(elemento);
                cmbMedida.Items.Add(elemento.DescripcionMed);
            }

            LosAlmacenes.Clear();
            cmbAlmacen.Items.Clear();
            foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenTodos())
            {
                LosAlmacenes.Add(ELEMENTO);
                cmbAlmacen.Items.Add(ELEMENTO.DireccionAlm);
            }

            txtTexto.Clear();
            lstvDatos.Items.Clear();
            lstvCantidad.Items.Clear();
            txtProducto.Clear();
            nudCantidad.Value = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            lstvDatos.Items.Clear();
            lstvCantidad.Items.Clear();
            txtProducto.Clear();
            nudCantidad.Value = 0;

            LasMedidas.Clear();
            cmbMedida.Items.Clear();
            foreach (clsMedida elemento in clsMedida.ListarMedidaTodos())
            {
                LasMedidas.Add(elemento);
                cmbMedida.Items.Add(elemento.DescripcionMed);
            }

            LosAlmacenes.Clear();
            cmbAlmacen.Items.Clear();
            foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenTodos())
            {
                LosAlmacenes.Add(ELEMENTO);
                cmbAlmacen.Items.Add(ELEMENTO.DireccionAlm);
            }

        }

        private void rbnDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            BotonBuscar();
        }

        private void rbnId_CheckedChanged(object sender, EventArgs e)
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
                    ProductosEncontrados.Clear();
                    lstvDatos.Items.Clear();
                    int contador = 1;
                    foreach (clsProducto ELEMENTO in clsProducto.ListarProductoPorId(Convert.ToInt32(txtTexto.Text)))
                    {
                        ProductosEncontrados.Add(ELEMENTO);
                        lstvDatos.Items.Add(ELEMENTO.IdProducto.ToString());
                        lstvDatos.Items[contador - 1].SubItems.Add(ELEMENTO.DescripcionProd);

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
