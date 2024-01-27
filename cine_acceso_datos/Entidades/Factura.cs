using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Factura
    {
        public int ID_PEDIDO_COMPRA { get; set; }
        public int ID_FACTURA { get; set; }
        public string NUMERO_FACTURA { get; set; }
        public DateTime FECHA_CREACION_FACTURA { get; set; }
        public bool ACTIVO_FACTURA { get; set; }
        public DateTime FECHA_EXPEDICION { get; set; }
        public string ESTADO_PAGO { get; set; }


        public Factura()
        {

        }

        public Factura(int idPedidoCompra, int idFactura, string numeroFactura, DateTime fechaCreacionFactura, bool activoFactura, DateTime fechaExpedicion, string estadoPago)
        {
            ID_PEDIDO_COMPRA = idPedidoCompra;
            ID_FACTURA = idFactura;
            NUMERO_FACTURA = numeroFactura;
            FECHA_CREACION_FACTURA = fechaCreacionFactura;
            ACTIVO_FACTURA = activoFactura;
            FECHA_EXPEDICION = fechaExpedicion;
            ESTADO_PAGO = estadoPago;
        }
    }
}
