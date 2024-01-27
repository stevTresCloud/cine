using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class EstadoPedido
    {
        public int ID_ESTADO_PEDIDO { get; set; }
        public string TIPO_ESTADO_PEDIDO { get; set; }
        public DateTime FECHA_CREACION_ESTADO_PEDIDO { get; set; }
        public bool ACTIVO_ESTADO_PEDIDO { get; set; }

        public EstadoPedido()
        {
        }

        public EstadoPedido(int idEstadoPedido, string tipoEstadoPedido, DateTime fechaCreacionEstadoPedido, bool activoEstadoPedido)
        {
            ID_ESTADO_PEDIDO = idEstadoPedido;
            TIPO_ESTADO_PEDIDO = tipoEstadoPedido;
            FECHA_CREACION_ESTADO_PEDIDO = fechaCreacionEstadoPedido;
            ACTIVO_ESTADO_PEDIDO = activoEstadoPedido;
        }
    }
}
