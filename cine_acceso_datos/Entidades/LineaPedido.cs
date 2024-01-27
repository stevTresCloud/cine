using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class LineaPedido
    {
        public int ID_LINEA_PEDIDO { get; set; }
        public int ID_PEDIDO_COMPRA { get; set; }
        public DateTime FECHA_CREACION_LINEA_PEDIDO { get; set; }
        public bool ACTIVO_LINEA_PEDIDO { get; set; }
        public int CANTIDAD { get; set; }
        public float PRECIO { get; set; }
        public float SUBTOTAL { get; set; }

        public LineaPedido()
        {
        }

        public LineaPedido(int idPedidoCompra, int cantidad, float precio)
        {
            ID_PEDIDO_COMPRA = idPedidoCompra;
            FECHA_CREACION_LINEA_PEDIDO = DateTime.Now;
            ACTIVO_LINEA_PEDIDO = true;
            CANTIDAD = cantidad;
            PRECIO = precio;
            SUBTOTAL = cantidad * precio;
        }
    }
}
