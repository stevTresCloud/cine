using System;
using System.Collections.Generic;
using System.Windows.Forms;
using cine_acceso_datos.Entidades;
using cine_logica_negocio;

namespace cine_presentacion_windows
{
    public partial class FrmFacturas : Form
    {
        private FacturaLogica facturaLogica;
        private List<String> listaEstadoPago = new List<string>();

        public FrmFacturas()
        {
            InitializeComponent();
            facturaLogica = new FacturaLogica();
            listaEstadoPago.Add("Pendiente");
            listaEstadoPago.Add("Pagado");
            listaEstadoPago.Add("Anulado");
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {

            List<Factura> listaEmpleados = facturaLogica.ObtenerTodasFacturas();

            dgvListadoEmpleados.Rows.Clear();

            foreach (Factura factura in listaEmpleados)
            {
                dgvListadoEmpleados.Rows.Add(factura.ID_FACTURA, factura.NUMERO_FACTURA, factura.FECHA_EXPEDICION, factura.ESTADO_PAGO);
            }
            // Agregamos valores a la lista desplegable de estado de pago
            estadoPago.DataSource = listaEstadoPago;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void estadoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Creamos una nueva Factura
            Factura factura = new Factura();
            if (numFactura.Text == "")
            {
                MessageBox.Show("El número de factura no puede estar vacío");
                return;
            }
            factura.NUMERO_FACTURA = numFactura.Text;
            if (fechaExpedicion.Value == null)
            {
                MessageBox.Show("La fecha de expedición no puede estar vacía");
                return;
            }
            factura.FECHA_EXPEDICION = fechaExpedicion.Value;
            // Verificamos que el estado de pago tenga un valor de acuerdo a la lista desplegable listaEstadoPago
            if (estadoPago.SelectedIndex == -1)
            {
                MessageBox.Show("El estado de pago no puede estar vacío");
                return;
            }
            factura.ESTADO_PAGO = listaEstadoPago[estadoPago.SelectedIndex];
            PedidoCompra pedidoFactura = new PedidoCompra();
            if (pedidoFactura.ID_PEDIDO_COMPRA == 0)
            {
                MessageBox.Show("El pedido de compra no puede estar vacío");
                return;
            }
            int facturaCreada = facturaLogica.InsertarFactura(pedidoFactura.ID_PEDIDO_COMPRA, factura.NUMERO_FACTURA, factura.FECHA_EXPEDICION, factura.ESTADO_PAGO);
            MessageBox.Show("Factura creada con ID: " + facturaCreada);
            limpiarCampos();
            FrmFacturas_Load(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fechaExpedicion_ValueChanged(object sender, EventArgs e)
        {

        }

        // Helpers
        private void limpiarCampos()
        {
            numFactura.Text = "";
            fechaExpedicion.Value = DateTime.Now;
            estadoPago.SelectedIndex = -1;
        }
    }
}
