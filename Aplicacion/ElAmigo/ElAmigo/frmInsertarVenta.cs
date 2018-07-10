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
        private List<clsVenta> _Serie = new List<clsVenta>();

        public List<clsVenta> Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

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
            try
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
                    txtDatos.Text = x.ClienteSeleccionado.NombresCli + " " + x.ClienteSeleccionado.ApellidosCli.ToString();
                    txtDocIdentidad.Text = x.ClienteSeleccionado.DNICli;
                    lblIdCliente.Text = x.ClienteSeleccionado.IdCliente.ToString();
                    txtRUC.Text = x.ClienteSeleccionado.RUCCli.ToString();
                    txtDireccion.Text = x.ClienteSeleccionado.DireccionCli.ToString();

                }
                txtDocIdentidad.ReadOnly = true;
                txtDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    lblTipo.Text = "BOLETA DE VENTA";
            }
        }

        private void cmbMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (clsPrecio ELEMENTO in clsPrecio.ListarPreciosProductoMedida(IdProd, cmbMedida.SelectedItem.ToString()))
                {

                    txtPVenta.Text = ELEMENTO.Precio.ToString();
                    lblIdMedida.Text = ELEMENTO.IdMedidaInt.ToString();
                    lblEquivalenciaMed.Text = ELEMENTO.Equivalencia.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    MessageBox.Show("Busque un producto!.");
                }
                else
                {
                    double valorVenta, subtotal, igv, total, precioUnit;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }

        private void GenerarSerie()
        {
            try
            {
                Serie.Clear();
                int contador;
                contador = 0;
                if (rbnBoleta.Checked == true)
                {
                    foreach (clsVenta ELEMENTO in clsVenta.generarSerieNumeroComprobante("BOLETA"))
                    {
                        Serie.Add(ELEMENTO);
                        lblSerie.Text = ELEMENTO.Serie.ToString();
                        lblNroCorrelativo.Text = ELEMENTO.NroVenta.ToString();
                        contador = contador + 1;
                    }

                    if (contador == 0)
                    {
                        lblSerie.Text = "1";
                        lblNroCorrelativo.Text = "1";
                    }
                    else if (Convert.ToInt32(lblNroCorrelativo.Text) == 10)
                    {
                        lblSerie.Text = (Convert.ToInt32(lblSerie.Text) + 1).ToString();
                        lblNroCorrelativo.Text = "1";
                    }
                    else
                    {
                        lblNroCorrelativo.Text = (Convert.ToInt32(lblNroCorrelativo.Text) + 1).ToString();
                    }
                }
                else
                {
                    foreach (clsVenta ELEMENTO in clsVenta.generarSerieNumeroComprobante("FACTURA"))
                    {
                        Serie.Add(ELEMENTO);
                        lblSerie.Text = ELEMENTO.Serie.ToString();
                        lblNroCorrelativo.Text = ELEMENTO.NroVenta.ToString();
                        contador++;
                    }

                    if (contador == 0)
                    {
                        lblSerie.Text = "1";
                        lblNroCorrelativo.Text = "1";
                    }
                    else if (Convert.ToInt32(lblNroCorrelativo.Text) == 10)
                    {
                        lblSerie.Text = (Convert.ToInt32(lblSerie.Text) + 1).ToString();
                        lblNroCorrelativo.Text = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void IdVenta()
        {
            try
            {
                if (rbnBoleta.Checked == true)
                {
                    foreach (clsVenta ELEMENTO in clsVenta.BuscarIdVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblNroCorrelativo.Text), Convert.ToInt32(lblSerie.Text), "BOLETA", Convert.ToDecimal(txtTotal.Text)))
                    {
                        lblIdVenta.Text = ELEMENTO.IdVenta.ToString();
                    }
                }
                else
                {
                    foreach (clsVenta ELEMENTO in clsVenta.BuscarIdVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblNroCorrelativo.Text), Convert.ToInt32(lblSerie.Text), "FACTURA", Convert.ToDecimal(txtTotal.Text)))
                    {
                        lblIdVenta.Text = ELEMENTO.IdVenta.ToString();
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnInsertarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstvDatos.Items.Count == 0 || string.IsNullOrEmpty(txtDatos.Text))
                {
                    MessageBox.Show("Agregue un producto a la lista / Seleccione un Cliente ");
                }
                else
                {
                    GenerarSerie();
                    clsVenta nuevaVenta;
                    if (rbnBoleta.Checked == true)
                    {
                        nuevaVenta = new clsVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblNroCorrelativo.Text), Convert.ToInt32(lblSerie.Text), "BOLETA", Convert.ToDecimal(txtTotal.Text));
                        nuevaVenta.InsertarVenta();
                        foreach (clsVenta ELEMENTO in clsVenta.BuscarIdVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblNroCorrelativo.Text), Convert.ToInt32(lblSerie.Text), "BOLETA", Convert.ToDecimal(txtTotal.Text)))
                        {
                            lblIdVenta.Text = ELEMENTO.IdVenta.ToString();
                        }
                    }
                    if (rbnFactura.Checked == true)
                    {
                        nuevaVenta = new clsVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblNroCorrelativo.Text), Convert.ToInt32(lblSerie.Text), "FACTURA", Convert.ToDecimal(txtTotal.Text));
                        nuevaVenta.InsertarVenta();
                        foreach (clsVenta ELEMENTO in clsVenta.BuscarIdVenta(Convert.ToInt32(lblIdCliente.Text), Convert.ToInt32(lblIdEmpleado.Text), Convert.ToInt32(lblNroCorrelativo.Text), Convert.ToInt32(lblSerie.Text), "FACTURA", Convert.ToDecimal(txtTotal.Text)))
                        {
                            lblIdVenta.Text = ELEMENTO.IdVenta.ToString();
                        }
                    }

                    int n;
                    n = 0;

                    while (n < lstvDatos.Items.Count)
                    {
                        clsDetalleVenta nuevoDetalleVenta;
                        nuevoDetalleVenta = new clsDetalleVenta(Convert.ToInt32(lblIdVenta.Text), Convert.ToInt32(lstvDatos.Items[n].SubItems[3].Text), Convert.ToInt32(lstvDatos.Items[n].SubItems[1].Text), Convert.ToDecimal(lstvDatos.Items[n].Text));
                        nuevoDetalleVenta.InsertarDetalleVenta();
                        n = n + 1;
                    }

                    MessageBox.Show("VENTA  REALIZADA SATISFACTORIAMENTE", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result = MessageBox.Show("¿Desea imprimir?", "Imprimir Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //{
                    //    try
                    //    {

                    //        //---------------- imprimir--------------------------

                    //        try
                    //        {
                    //            string tipoComprobante = cboTipoComprobante.Text;
                    //            if (tipoComprobante.CompareTo("FACTURA") == 0)
                    //            {
                    //                FrmReporteFactura form = new FrmReporteFactura();
                    //                form.idVenta = Convert.ToInt32(txtIdVenta.Text);
                    //                form.Show();
                    //            }
                    //            else
                    //            {
                    //                FrmReporteBoleta form = new FrmReporteBoleta();
                    //                form.idVenta = Convert.ToInt32(txtIdVenta.Text);
                    //                form.Show();

                    //            }
                    //        }
                    //        catch (Exception ex)
                    //        {

                    //            MessageBox.Show(ex.Message);
                    //        }

                    //        //--------------------------------------------------------


                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show(ex.Message);
                    //    }

                    //}
                    //else result = DialogResult.No;
                    //{
                    //    this.Close();
                    //}

                    lstvDatos.Items.Clear();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void frmInsertarVenta_Load(object sender, EventArgs e)
        {
            try
            {
                lblIdEmpleado.Text = mdlVariables.MiEmpleadoConectado.IdEmpleado.ToString();
                lblNombreEmpleado.Text = mdlVariables.MiEmpleadoConectado.NombresEmp.ToString();
                foreach (clsAlmacen ELEMENTO in clsAlmacen.ListarAlmacenTodos())
                {
                    if (ELEMENTO.TipoAlm.ToString() == "PRINCIPAL")
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void Limpiar()
        {
            txtDatos.Clear();
            txtDescripcion.Clear();
            txtDocIdentidad.Clear();
            txtIGV2.Clear();
            txtPVenta.Clear();
            txtSubtotal.Clear();
            txtTotal.Clear();
            nudCantidad.Value = 0;
            cmbMedida.Items.Clear();

        }


    }
}
