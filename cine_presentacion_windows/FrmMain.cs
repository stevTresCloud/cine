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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Estado Pedido
            FrmEstadoPedido frmEstadoPedido = new FrmEstadoPedido();
            frmEstadoPedido.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar programa
            Application.Exit();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Proveedores
            FrmProveedor frmProveedor = new FrmProveedor();
            frmProveedor.Show();
        }

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Peliculas
            FrmPelicula frmPelicula = new FrmPelicula();
            frmPelicula.Show();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Facturas
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de Pedidos
            FrmPedidoFactura frmPedidoFactura = new FrmPedidoFactura();
            frmPedidoFactura.Show();

        }
    }
}
