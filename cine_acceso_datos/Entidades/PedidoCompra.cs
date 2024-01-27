using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class PedidoCompra
    {
        public int IDPedidoCompra { get; set; }
        public int IDProveedor { get; set; }
        public int IDEstadoPedido { get; set; }
        public string NumeroPedidoCompra { get; set; }
        public bool ActivoPedidoCompra { get; set; }
        public DateTime FechaEntrega { get; set; }
        public float Total { get; set; }
        public DateTime FechaCreacionPedidoCompra { get; set; }

        public PedidoCompra()
        {
        }

        public PedidoCompra(int idProveedor, int idEstadoPedido, string numeroPedidoCompra, bool activoPedidoCompra, DateTime fechaEntrega, float total)
        {
            IDProveedor = idProveedor;
            IDEstadoPedido = idEstadoPedido;
            NumeroPedidoCompra = numeroPedidoCompra;
            ActivoPedidoCompra = activoPedidoCompra;
            FechaEntrega = fechaEntrega;
            Total = total;
            FechaCreacionPedidoCompra = DateTime.Now;
        }
    }
}
