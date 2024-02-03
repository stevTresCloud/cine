using cine_acceso_datos.DAO;
using cine_acceso_datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_logica_negocio
{
    public class PedidoCompraLogica
    {
        private PedidoCompraDAO pedidoCompraDao;

        public PedidoCompraLogica()
        {
            pedidoCompraDao = new PedidoCompraDAO();
        }

        // Metodo para insertar un pedido de compra
        public int InsertarPedidoCompra(PedidoCompra pedidoCompra)
        {
            pedidoCompraDao.InsertarPedidoCompra(pedidoCompra);
            List<PedidoCompra> pedidos = pedidoCompraDao.ObtenerPedidosCompra();
            return pedidos.Last().ID_PEDIDO_COMPRA;
        }

        // Metodo para obtener todos los pedidos de compra
        public List<PedidoCompra> ObtenerTodosPedidosCompra()
        {
            return pedidoCompraDao.ObtenerPedidosCompra();
        }

        // Metodo para obtener un pedido de compra por su ID
        public PedidoCompra ObtenerPedidoCompraPorID(int idPedidoCompra)
        {
            return pedidoCompraDao.ObtenerPedidoCompraPorID(idPedidoCompra);
        }

        // Metodo para actualizar un pedido de compra
        public void ActualizarPedidoCompra(PedidoCompra pedidoCompra)
        {
            pedidoCompraDao.ActualizarPedidoCompra(pedidoCompra);
        }

        // Metodo para eliminar un pedido de compra
        public void EliminarPedidoCompra(int idPedidoCompra)
        {
            pedidoCompraDao.EliminarPedidoCompra(idPedidoCompra);
        }
    }
}
