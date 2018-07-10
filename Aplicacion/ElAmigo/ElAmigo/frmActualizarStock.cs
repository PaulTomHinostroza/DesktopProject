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
    public partial class frmActualizarStock : Form
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

        private List<clsStock> _stockEncontrados = new List<clsStock>();

        public List<clsStock> StockEncontrados
        {
            get { return _stockEncontrados; }
            set { _stockEncontrados = value; }
        }

        private clsStock _stockSeleccionado;

        public clsStock StockSeleccionado
        {
            get { return _stockSeleccionado; }
            set { _stockSeleccionado = value; }
        }

        public frmActualizarStock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
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

                StockEncontrados.Clear();
                lstvCantidad.Items.Clear();
                int contador = 1;
                foreach (clsStock ELEMENTO in clsStock.ListarStockPorProducto(ProductoSeleccionado.IdProducto))
                {

                    StockEncontrados.Add(ELEMENTO);
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

            cmbMedida.Items.Clear();
            foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(Convert.ToInt32(lblIdProducto.Text)))
            {
                cmbMedida.Items.Add(ELEMENTO.DescripcionMed);
            }

            lblEquivalencia.Text = "0";
            lblIdAlmacen.Text = "0";
            nudCantidad.Value = 0;
            txtAlmacen.Clear();
            cmbMedida.Enabled = false;
            nudCantidad.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            btnActualizar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void lstvCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvCantidad.SelectedItems.Count > 0)
            {
                StockSeleccionado = StockEncontrados[lstvCantidad.SelectedItems[0].Index];
            }

            txtAlmacen.Text = StockSeleccionado.DescripcionAlmacen.ToString();
            lblIdAlmacen.Text = StockSeleccionado.IdAlmacenInt.ToString();
        }

        private void cmbMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProductoMedida(Convert.ToInt32(lblIdProducto.Text), cmbMedida.SelectedItem.ToString()))
            {
                lblEquivalencia.Text = ELEMENTO.Equivalencia.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtProducto.TextLength == 0 || txtAlmacen.TextLength ==0 )
            {
                MessageBox.Show("Seleccione un producto y/o almacén !");
            }
            else
            {
                btnAgregar.Enabled = true;
                btnQuitar.Enabled = true;
                btnLimpiar.Enabled = false;
                cmbMedida.Enabled = true;
                nudCantidad.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ////ACTUALIZAR Stock
            clsStock nuevoStock;
            nuevoStock = new clsStock(Convert.ToInt32(lblIdProducto.Text),
                                        Convert.ToInt32(lblIdAlmacen.Text),
                                        Convert.ToInt32(lblEquivalencia.Text),
                                        Convert.ToDecimal(nudCantidad.Value));
            nuevoStock.ActualizarAñadir();

            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            cmbMedida.Enabled = false;
            nudCantidad.Enabled = false;
            btnLimpiar.Enabled = true;
            btnLimpiar.PerformClick();

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ////ACTUALIZAR Stock
            clsStock nuevoStock;
            nuevoStock = new clsStock(Convert.ToInt32(lblIdProducto.Text),
                                        Convert.ToInt32(lblIdAlmacen.Text),
                                        Convert.ToInt32(lblEquivalencia.Text),
                                        Convert.ToDecimal(nudCantidad.Value));
            nuevoStock.ActualizarQuitar();

            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            cmbMedida.Enabled = false;
            nudCantidad.Enabled = false;
            btnLimpiar.Enabled = true;
            btnLimpiar.PerformClick();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            lstvDatos.Items.Clear();
            lstvCantidad.Items.Clear();
            txtProducto.Clear();
            txtAlmacen.Clear();
            cmbMedida.Items.Clear();
            nudCantidad.Value = 0;
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
