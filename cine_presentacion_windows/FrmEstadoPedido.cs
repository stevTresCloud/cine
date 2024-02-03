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
    public partial class FrmEstadoPedido : Form
    {
        private EstadoPedidoLogica estadoPedidoLogica;

        public FrmEstadoPedido()
        {
            InitializeComponent();
            estadoPedidoLogica = new EstadoPedidoLogica();
        }

        private void FrmEstadoPedido_Load(object sender, EventArgs e)
        {
            InicializarDatosEstadosPedido();
        }

        private void InicializarDatosEstadosPedido()
        {
            // Obtener y mostrar todos los estados de pedido en el DataGridView
            List<EstadoPedido> listaEstadosPedido = estadoPedidoLogica.ObtenerTodosEstadosPedido();

            dgvEstadosPedido.Rows.Clear();
            dgvEstadosPedido.Columns.Clear();

            // Añadir columnas al DataGridView
            dgvEstadosPedido.Columns.Add("id", "ID");
            dgvEstadosPedido.Columns.Add("tipo", "Tipo");
            dgvEstadosPedido.Columns.Add("activo", "Activo");

            foreach (EstadoPedido estadoPedido in listaEstadosPedido)
            {
                dgvEstadosPedido.Rows.Add(
                    estadoPedido.ID_ESTADO_PEDIDO,
                    estadoPedido.TIPO_ESTADO_PEDIDO,
                    estadoPedido.ACTIVO_ESTADO_PEDIDO.ToString());
            }

            dgvEstadosPedido.ClearSelection();
        }

        private void dgvEstadosPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEstadosPedido.Rows[e.RowIndex];
                MostrarDetallesEstadoPedido(row);
            }
        }

        private void MostrarDetallesEstadoPedido(DataGridViewRow row)
        {
            if (row != null)
            {
                txtIdEstadoPedido.Text = row.Cells["id"].Value.ToString();
                txtTipoEstadoPedido.Text = row.Cells["tipo"].Value.ToString();
                chkActivoEstadoPedido.Checked = Convert.ToBoolean(row.Cells["activo"].Value);
            }
        }

        private void LimpiarCampos()
        {
            txtIdEstadoPedido.Text = "";
            txtTipoEstadoPedido.Text = "";
            chkActivoEstadoPedido.Checked = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Creamos un nuevo estado de pedido
            if (!string.IsNullOrEmpty(txtTipoEstadoPedido.Text))
            {
                string tipoEstadoPedido = txtTipoEstadoPedido.Text;
                bool activoEstadoPedido = chkActivoEstadoPedido.Checked;

                estadoPedidoLogica.InsertarEstadoPedido(tipoEstadoPedido, activoEstadoPedido);

                MessageBox.Show("Estado de pedido creado");
                LimpiarCampos();
                InicializarDatosEstadosPedido();
            }
            else
            {
                MessageBox.Show("El tipo de estado de pedido no puede estar vacío");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Actualizar un estado de pedido seleccionado
            if (!string.IsNullOrEmpty(txtIdEstadoPedido.Text))
            {
                int idEstadoPedido = Convert.ToInt32(txtIdEstadoPedido.Text);
                string tipoEstadoPedido = txtTipoEstadoPedido.Text;
                bool activoEstadoPedido = chkActivoEstadoPedido.Checked;

                estadoPedidoLogica.ActualizarEstadoPedido(idEstadoPedido, tipoEstadoPedido, activoEstadoPedido);

                MessageBox.Show($"Estado de pedido actualizado con ID: {idEstadoPedido}");
                LimpiarCampos();
                InicializarDatosEstadosPedido();
            }
            else
            {
                MessageBox.Show("Seleccione un estado de pedido para actualizar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminamos el registro a partir del campo txtIdEstadoPedido
            if (!string.IsNullOrEmpty(txtIdEstadoPedido.Text))
            {
                int idEstadoPedido = Convert.ToInt32(txtIdEstadoPedido.Text);
                estadoPedidoLogica.EliminarEstadoPedido(idEstadoPedido);

                MessageBox.Show($"Estado de pedido eliminado con ID: {idEstadoPedido}");
                LimpiarCampos();
                InicializarDatosEstadosPedido();
            }
            else
            {
                MessageBox.Show("Seleccione un estado de pedido para eliminar");
            }
        }

        private void dgvEstadosPedido_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Mostrar detalles del estado de pedido seleccionado en las cajas de texto
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEstadosPedido.Rows[e.RowIndex];
                MostrarDetallesEstadoPedido(row);
            }
        }
    }
}
