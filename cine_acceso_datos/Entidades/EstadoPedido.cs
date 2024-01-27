using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class EstadoPedido
    {
        public int IdEstadoPedido { get; set; }
        public string TipoEstadoPedido { get; set; }
        public DateTime FechaCreacionEstadoPedido { get; set; }
        public bool ActivoEstadoPedido { get; set; }

        public EstadoPedido()
        {
        }

        public EstadoPedido(int idEstadoPedido, string tipoEstadoPedido, DateTime fechaCreacionEstadoPedido, bool activoEstadoPedido)
        {
            IdEstadoPedido = idEstadoPedido;
            TipoEstadoPedido = tipoEstadoPedido;
            FechaCreacionEstadoPedido = fechaCreacionEstadoPedido;
            ActivoEstadoPedido = activoEstadoPedido;
        }
    }
