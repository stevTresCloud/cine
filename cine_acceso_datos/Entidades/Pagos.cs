using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Pagos
    {
        public int ID_PAGOS { get; set; }
        public int? ID_PEDIDO_COMPRA { get; set; }
        public int? ID_FACTURA { get; set; }
        public float MONTO { get; set; }
        public DateTime FECHA_CREACION_PAGOS { get; set; }
        public bool ACTIVO_PAGOS { get; set; }

        public Pagos()
        {
        }

        public Pagos(int idPagos, int? idPedidoCompra, int? idFactura, float monto, DateTime fechaCreacionPagos, bool activoPagos)
        {
            ID_PAGOS = idPagos;
            ID_PEDIDO_COMPRA = idPedidoCompra;
            ID_FACTURA = idFactura;
            MONTO = monto;
            FECHA_CREACION_PAGOS = fechaCreacionPagos;
            ACTIVO_PAGOS = activoPagos;
        }
    }
}
