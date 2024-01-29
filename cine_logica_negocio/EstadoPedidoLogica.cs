using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cine_acceso_datos.DAO;
using cine_acceso_datos.Entidades;

namespace cine_logica_negocio
{
    public class EstadoPedidoLogica
    {
        private EstadoPedidoDAO estadoPedidoDao;

        public EstadoPedidoLogica()
        {
            estadoPedidoDao = new EstadoPedidoDAO();
        }

        public int InsertarEstadoPedido(string tipoEstadoPedido, bool activoEstadoPedido)
        {
            estadoPedidoDao.InsertarEstadoPedido(tipoEstadoPedido, activoEstadoPedido);
            List<EstadoPedido> estados = estadoPedidoDao.ObtenerTodosEstadosPedido();
            return estados.Last().ID_ESTADO_PEDIDO;
        }

        public List<EstadoPedido> ObtenerTodosEstadosPedido()
        {
            return estadoPedidoDao.ObtenerTodosEstadosPedido();
        }

        public EstadoPedido ObtenerEstadoPedidoPorID(int idEstadoPedido)
        {
            return estadoPedidoDao.ObtenerEstadoPedidoPorID(idEstadoPedido);
        }

        public void ActualizarEstadoPedido(int idEstadoPedido, string tipoEstadoPedido, bool activoEstadoPedido)
        {
            estadoPedidoDao.ActualizarEstadoPedido(idEstadoPedido, tipoEstadoPedido, activoEstadoPedido);
        }

        public void EliminarEstadoPedido(int idEstadoPedido)
        {
            estadoPedidoDao.EliminarEstadoPedido(idEstadoPedido);
        }
    }
}
