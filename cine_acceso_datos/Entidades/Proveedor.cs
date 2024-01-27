using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Proveedor
    {
        public int ID_PROVEEDOR { get; set; }
        public DateTime FECHA_CREACION_PROVEEDOR { get; set; }
        public bool ACTIVO_PROVEEDOR { get; set; }
        public string NOMBRE_PROVEEDOR { get; set; }
        public string APELLIDO_PROVEEDOR { get; set; }
        public string IDENTIFICACION_PROVEEDOR { get; set; }
        public string DIRECCION_PROVEEDOR { get; set; }
        public string TELEFONO_PROVEEDOR { get; set; }
        public string CORREO_PROVEEDOR { get; set; }

        public Proveedor()
        {
        }

        public Proveedor(DateTime fechaCreacion, bool activo, string nombre, string apellido, string identificacion, string direccion, string telefono, string correo)
        {
            FECHA_CREACION_PROVEEDOR = fechaCreacion;
            ACTIVO_PROVEEDOR = activo;
            NOMBRE_PROVEEDOR = nombre;
            APELLIDO_PROVEEDOR = apellido;
            IDENTIFICACION_PROVEEDOR = identificacion;
            DIRECCION_PROVEEDOR = direccion;
            TELEFONO_PROVEEDOR = telefono;
            CORREO_PROVEEDOR = correo;
        }
    }
}
