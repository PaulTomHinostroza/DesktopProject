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
    public partial class frmInsertarVenta : Form
    {
        private clsProducto _ProductoSeleccionado;

        public clsProducto ProductoSeleccionado
        {
            get { return _ProductoSeleccionado; }
            set { _ProductoSeleccionado = value; }
        }

        public frmInsertarVenta()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //auxiliar
        private int _IdProd;

        public int IdProd
        {
            get { return _IdProd; }
            set { _IdProd = value; }
        }

        private void btnBusquedaCliente_Click(object sender, EventArgs e)
        {
            frmListarClienteVenta x;
            x = new frmListarClienteVenta();
            x.ShowDialog();

            if (x.ClienteSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtDatos.Text = x.ClienteSeleccionado.NombresCli+" "+x.ClienteSeleccionado.ApellidosCli.ToString();
                txtDocIdentidad.Text = x.ClienteSeleccionado.DNICli;
                lblIdCliente.Text = x.ClienteSeleccionado.IdCliente.ToString();

            }
            txtDocIdentidad.ReadOnly = true;
            txtDatos.ReadOnly = true;
        }

        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {
            frmListarProductoMedidaPrecioVenta x;
            x = new frmListarProductoMedidaPrecioVenta();
            x.ShowDialog();

            if (x.ProductoSeleccionado == null)
            {
                MessageBox.Show("La búsqueda fue cancelada");
            }
            else
            {
                txtDescripcion.Text = x.ProductoSeleccionado.DescripcionProd.ToString();
                IdProd = x.ProductoSeleccionado.IdProducto;
                lblCodigoProducto.Text = x.ProductoSeleccionado.IdProducto.ToString();


                cmbMedida.Items.Clear();
                foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProducto(x.ProductoSeleccionado.IdProducto))
                {
                    cmbMedida.Items.Add(ELEMENTO.DescripcionMed);
                }
            }

        }

        private void rbnBoleta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked == true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";
                }

            }
        }

        private void rbnGuia_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnFactura.Checked == true)
            {
                lblTipo.Text = "FACTURA";
            }
            else
            {
                if (rbnGuia.Checked == true)
                {
                    lblTipo.Text = "GUIA DE REMISION";
                }
                else
                {
                    lblTipo.Text = "BOLETA DE VENTA";
                }

            }
        }

        private void cmbMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProductoMedida(IdProd, cmbMedida.SelectedItem.ToString()))
            {

                txtPVenta.Text = ELEMENTO.Precio.ToString();
                lblIdMedida.Text = ELEMENTO.IdMedidaInt.ToString();
                lblEquivalenciaMed.Text = ELEMENTO.Equivalencia.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double valorVenta, subtotal, igv, total,precioUnit;
            subtotal = 0;
            total = 0;
            igv = 0;
            precioUnit = 0;
            Boolean repetido;
            int index;
            precioUnit = Convert.ToDouble(txtPVenta.Text) / Convert.ToDouble(lblEquivalenciaMed.Text);
            valorVenta = Convert.ToDouble(nudCantidad.Value) * Convert.ToDouble(txtPVenta.Text);
            index = 0;
            repetido = false;

            if (lstvDatos.Items.Count == 0)
            {
                lstvDatos.Items.Add((nudCantidad.Value).ToString());
                lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(lblIdMedida.Text);
                lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(cmbMedida.SelectedItem.ToString());
                lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(lblCodigoProducto.Text);
                lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(txtDescripcion.Text);
                lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(precioUnit.ToString("0.00"));
                lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(valorVenta.ToString("0.00"));
                lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(lblEquivalenciaMed.Text);
            }
            else
            {

                for (int i = 0; i < lstvDatos.Items.Count; i++)
                {
                    if (lstvDatos.Items[i].SubItems[2].Text == cmbMedida.SelectedItem.ToString() && lstvDatos.Items[i].SubItems[4].Text == txtDescripcion.Text)
                    {
                        index = i;
                        repetido = true;
                    }

                }

                if (repetido == true)
                {
                    lstvDatos.Items[index].Text = (Convert.ToDecimal(lstvDatos.Items[index].Text) + nudCantidad.Value).ToString();
                    lstvDatos.Items[index].SubItems[6].Text = (Convert.ToDouble(lstvDatos.Items[index].SubItems[6].Text) + valorVenta).ToString("0.00");
                }
                else
                {
                    lstvDatos.Items.Add((nudCantidad.Value).ToString());
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(lblIdMedida.Text);
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(cmbMedida.SelectedItem.ToString());
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(lblCodigoProducto.Text);
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(txtDescripcion.Text);
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(precioUnit.ToString("0.00"));
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(valorVenta.ToString("0.00"));
                    lstvDatos.Items[lstvDatos.Items.Count - 1].SubItems.Add(lblEquivalenciaMed.Text);
                }
            }

            for (int i = 0; i < lstvDatos.Items.Count; i++)
            {
                total = total + Convert.ToDouble(lstvDatos.Items[i].SubItems[6].Text);
            }

            subtotal = total / 1.18;
            igv = subtotal * 0.18;

            txtSubtotal.Text = subtotal.ToString("0.00");
            txtIGV2.Text = igv.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");

            ////ACTUALIZAR Stock
            clsStock nuevoStock;
            nuevoStock = new clsStock(Convert.ToInt32(lblCodigoProducto.Text),
                                        Convert.ToInt32(lblIdAlmacen.Text), 
                                        Convert.ToInt32(lblEquivalenciaMed.Text),
                                        Convert.ToDecimal(nudCantidad.Value));
            nuevoStock.ActualizarQuitar();




        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            ////ACTUALIZAR Stock
            clsStock nuevoStock;
            nuevoStock = new clsStock(Convert.ToInt32(lstvDatos.SelectedItems[0].SubItems[3].Text),
                                        Convert.ToInt32(lblIdAlmacen.Text),
                                        Convert.ToInt32(lblEquivalenciaMed.Text),
                                        Convert.ToDecimal(lstvDatos.SelectedItems[0].Text));
            nuevoStock.ActualizarAñadir();

            double total, subtotal, igv;
            total = 0;
            subtotal = 0;
            igv = 0;
            total = Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(lstvDatos.SelectedItems[0].SubItems[6].Text);
            subtotal = total / 1.18;
            igv = subtotal * 0.18;
            lstvDatos.SelectedItems[0].Remove();
            txtSubtotal.Text = subtotal.ToString("0.00");
            txtIGV2.Text = igv.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");

            
        }

        private void btnInsertarVenta_Click(object sender, EventArgs e)
        {
            if (lstvDatos.Items.Count==0)
            {
                MessageBox.Show("Agregue un producto a la lista!");
            }
            else
            {
                clsVenta nuevaVenta;
                if (rbnBoleta.Checked == true)
                {
                    nuevaVenta = new clsVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblSerie.Text), "BOLETA", Convert.ToDecimal(txtTotal.Text));
                    nuevaVenta.InsertarVenta();
                }
                if (rbnFactura.Checked == true)
                {
                    nuevaVenta = new clsVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblSerie.Text), "FACTURA", Convert.ToDecimal(txtTotal.Text));
                    nuevaVenta.InsertarVenta();
                }
                if (rbnGuia.Checked == true)
                {
                    nuevaVenta = new clsVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblSerie.Text), "GUIA DE REMISIÓN", Convert.ToDecimal(txtTotal.Text));
                    nuevaVenta.InsertarVenta();
                }


                int n;
                n = 0;

                while (n < lstvDatos.Items.Count)
                {
                    clsDetalleVenta nuevoDetalleVenta;
                    nuevoDetalleVenta = new clsDetalleVenta(8000, Convert.ToInt32(lstvDatos.Items[n].SubItems[3].Text), Convert.ToInt32(lstvDatos.Items[n].SubItems[1].Text), Convert.ToDecimal(lstvDatos.Items[n].Text));
                    nuevoDetalleVenta.InsertarDetalleVenta();
                    n = n + 1;
                }

                lstvDatos.Items.Clear();
            }
            

        }

        private void frmInsertarVenta_Load(object sender, EventArgs e)
        {
            lblIdEmpleado.Text = mdlVariables.MiEmpleadoConectado.IdEmpleado.ToString();
            foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenTodos())
            {
                if (ELEMENTO.TipoAlm.ToString()=="PRINCIPAL")
                {
                    lblIdAlmacen.Text = ELEMENTO.IdAlmacen.ToString();
                }
            }
            if (lblIdAlmacen.Text == "IdAlmacen")
            {
                MessageBox.Show("Registre un Almacen Principal/Contacte con el Administrador");
                Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (lstvDatos.Items.Count == 0)
            {
                MessageBox.Show("Agregue productos a la lista!");
            }
            else
            {
                int n;
                n = 0;

                while (n < lstvDatos.Items.Count)
                {
                    clsStock nuevoStock;
                    nuevoStock = new clsStock(Convert.ToInt32(lstvDatos.Items[n].SubItems[3].Text),
                                                Convert.ToInt32(lblIdAlmacen.Text),
                                                Convert.ToInt32(lstvDatos.Items[n].SubItems[7].Text),
                                                Convert.ToDecimal(lstvDatos.Items[n].Text));
                    nuevoStock.ActualizarAñadir();
                    n = n + 1;
                }

                lstvDatos.Items.Clear();
                txtIGV2.Clear();
                txtSubtotal.Clear();
                txtTotal.Clear();
            }
            
        }


    }
}
