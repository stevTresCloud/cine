using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class PedidoCompra
    {
        public int ID_PEDIDO_COMPRA { get; set; }
        public int ID_PROVEEDOR { get; set; }
        public int ID_ESTADO_PROVEEDOR { get; set; }
        public string NUMERO_PEDIDO_COMPRA { get; set; }
        public bool ACTIVO_PEDIDO_COMPRA { get; set; }
        public DateTime FECHA_ENTREGA { get; set; }
        public float TOTAL { get; set; }
        public DateTime FECHA_CREACION_PEDIDO_COMPRA { get; set; }

        public PedidoCompra()
        {
        }

        public PedidoCompra(int idProveedor, int idEstadoPedido, string numeroPedidoCompra, bool activoPedidoCompra, DateTime fechaEntrega, float total)
        {
            ID_PROVEEDOR = idProveedor;
            ID_ESTADO_PROVEEDOR = idEstadoPedido;
            NUMERO_PEDIDO_COMPRA = numeroPedidoCompra;
            ACTIVO_PEDIDO_COMPRA = activoPedidoCompra;
            FECHA_ENTREGA = fechaEntrega;
            TOTAL = total;
            FECHA_CREACION_PEDIDO_COMPRA = DateTime.Now;
        }
    }
}
