using cine_acceso_datos.Entidades;
using cine_logica_negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cine_presentacion_windows
{
    public partial class FrmPedidoFactura : Form
    {
        private PedidoCompraLogica pedidoCompraLogica;
        private ProveedorLogica proveedorLogica;
        private EstadoPedidoLogica estadoPedidoLogica;
        public FrmPedidoFactura()
        {
            InitializeComponent();
            pedidoCompraLogica = new PedidoCompraLogica();
            proveedorLogica = new ProveedorLogica();
            estadoPedidoLogica = new EstadoPedidoLogica();
        }

        private void InicializarDatos()
        {
            LimpiarTodo();
            // Inicializamos el DataGridView
            List<PedidoCompra> listaPedidos = pedidoCompraLogica.ObtenerTodosPedidosCompra();
            dgvPedidosCompra.Rows.Clear();
            dgvPedidosCompra.Columns.Clear();

            //Añadir columnas al DataGridView
            dgvPedidosCompra.Columns.Add("id", "ID");
            dgvPedidosCompra.Columns.Add("estado", "Estado");
            dgvPedidosCompra.Columns.Add("proveedor", "Proveedor");
            dgvPedidosCompra.Columns.Add("fechaEntrega", "Fecha de Entrega");
            dgvPedidosCompra.Columns.Add("total", "Total");

            foreach (PedidoCompra pedido in listaPedidos)
            {
                Proveedor proveedor = proveedorLogica.ObtenerProveedorPorID(pedido.ID_PROVEEDOR);
                EstadoPedido estadoPedido = estadoPedidoLogica.ObtenerEstadoPedidoPorID(pedido.ID_ESTADO_PEDIDO);

                dgvPedidosCompra.Rows.Add(
                pedido.ID_PEDIDO_COMPRA,
                estadoPedido.TIPO_ESTADO_PEDIDO,
                proveedor.NOMBRE_PROVEEDOR + " " + proveedor.APELLIDO_PROVEEDOR,
                pedido.FECHA_ENTREGA,
                pedido.TOTAL);
            }
            dgvPedidosCompra.ClearSelection();

            InicializarEstadoPedido();
            InicializarProveedores();
        }

        private void InicializarEstadoPedido()
        {
            // Limpiamos el combo de Estados de Pedido
            cbEstadoPedido.DataSource = null;
            EstadoPedidoLogica estadoPedidoLogica = new EstadoPedidoLogica();
            List<EstadoPedido> estados = estadoPedidoLogica.ObtenerTodosEstadosPedido();
            foreach (EstadoPedido estado in estados)
            {
                cbEstadoPedido.Items.Add(estado.TIPO_ESTADO_PEDIDO);
            }
        }

        private void InicializarProveedores()
        {
            // Limpiamos el combo de Proveedores
            cbProveedor.DataSource = null;
            ProveedorLogica proveedorLogica = new ProveedorLogica();
            List<Proveedor> proveedores = proveedorLogica.ObtenerTodosProveedores();
            foreach (Proveedor proveedor in proveedores)
            {
                cbProveedor.Items.Add(proveedor.NOMBRE_PROVEEDOR + " " + proveedor.APELLIDO_PROVEEDOR);
            }
        }

        private void dgvPedidosCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Creamos un nuevo Pedido de Compra
            PedidoCompra pedidoCompra = new PedidoCompra();
            if (cbEstadoPedido.SelectedIndex == -1)
            {
                MessageBox.Show("El estado de pedido no puede estar vacío");
                return;
            }
            pedidoCompra.ID_ESTADO_PEDIDO = ((EstadoPedido)cbEstadoPedido.SelectedItem).ID_ESTADO_PEDIDO;
            if (cbProveedor.SelectedIndex == -1)
            {
                MessageBox.Show("El proveedor no puede estar vacío");
                return;
            }
            pedidoCompra.ID_PROVEEDOR = ((Proveedor)cbProveedor.SelectedItem).ID_PROVEEDOR;
            if (dpFechaEntrega.Value == null)
            {
                MessageBox.Show("La fecha de entrega no puede estar vacía");
                return;
            }
            pedidoCompra.FECHA_ENTREGA = dpFechaEntrega.Value;
            if (txtTotal.Text == "")
            {
                MessageBox.Show("El total no puede estar vacío");
                return;
            }
            pedidoCompra.TOTAL = float.Parse(txtTotal.Text);

            int pedidoCreado = pedidoCompraLogica.InsertarPedidoCompra(pedidoCompra);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Editamos un Pedido de Compra a partir de las cajas de texto
            if (txtIdPedidoCompra.Text != "")
            {
                int idPedidoCompra = Convert.ToInt32(txtIdPedidoCompra.Text);
                if (cbEstadoPedido.SelectedIndex == -1)
                {
                    MessageBox.Show("El estado de pedido no puede estar vacío");
                    return;
                }
                int idEstadoPedido = ((EstadoPedido)cbEstadoPedido.SelectedItem).ID_ESTADO_PEDIDO;
                if (cbProveedor.SelectedIndex == -1)
                {
                    MessageBox.Show("El proveedor no puede estar vacío");
                    return;
                }
                int idProveedor = ((Proveedor)cbProveedor.SelectedItem).ID_PROVEEDOR;
                if (dpFechaEntrega.Value == null)
                {
                    MessageBox.Show("La fecha de entrega no puede estar vacía");
                    return;
                }
                DateTime fechaEntrega = dpFechaEntrega.Value;
                if (txtTotal.Text == "")
                {
                    MessageBox.Show("El total no puede estar vacío");
                    return;
                }
                float total = float.Parse(txtTotal.Text);
                // Número pedido de compra
                if (txtNumeroPedido.Text == "")
                {
                    MessageBox.Show("El número de pedido de compra no puede estar vacío");
                    return;
                }
                string numeroPedidoCompra = txtNumeroPedido.Text;

                PedidoCompra pedidoCompra = new PedidoCompra(
                    idPedidoCompra: idPedidoCompra,
                    idProveedor: idProveedor,
                    idEstadoPedido: idEstadoPedido,
                    fechaEntrega: fechaEntrega,
                    total: total,
                    numeroPedidoCompra: numeroPedidoCompra,
                    activoPedidoCompra: true
                    );

                pedidoCompraLogica.ActualizarPedidoCompra(pedidoCompra);
                InicializarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminamos un Pedido de Compra a partir del ID
            if (txtIdPedidoCompra.Text != "")
            {
                int idPedidoCompra = Convert.ToInt32(txtIdPedidoCompra.Text);
                pedidoCompraLogica.EliminarPedidoCompra(idPedidoCompra);
                InicializarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un pedido de compra");
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {

        }

        private void FrmPedidoFactura_Load(object sender, EventArgs e)
        {
            // Inicializamos los datos de la ventana
            InicializarDatos();
        }

        private void LimpiarTodo()
        {
            txtIdPedidoCompra.Text = "";
            cbEstadoPedido.SelectedIndex = -1;
            cbProveedor.SelectedIndex = -1;
            dpFechaEntrega.Value = DateTime.Now;
            txtTotal.Text = "";
            txtNumeroPedido.Text = "";
        }
    }
}
