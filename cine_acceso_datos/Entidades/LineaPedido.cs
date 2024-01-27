using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class LineaPedido
    {
        public int IdLineaPedido { get; set; }
        public int IdPedidoCompra { get; set; }
        public DateTime FechaCreacionLineaPedido { get; set; }
        public bool ActivoLineaPedido { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Subtotal { get; set; }

        public LineaPedido()
        {
        }

        public LineaPedido(int idPedidoCompra, int cantidad, float precio)
        {
            IdPedidoCompra = idPedidoCompra;
            FechaCreacionLineaPedido = DateTime.Now;
            ActivoLineaPedido = true;
            Cantidad = cantidad;
            Precio = precio;
            Subtotal = cantidad * precio;
        }
    }
}
