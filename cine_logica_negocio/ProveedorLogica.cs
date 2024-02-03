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
    public class ProveedorLogica
    {
        private ProveedorDAO proveedorDao = new ProveedorDAO();

        public ProveedorLogica()
        {
        }

        public int InsertarProveedor(string nombre, string apellido, string identificacion, string direccion, string telefono, string correo)
        {
            proveedorDao.InsertarProveedor(nombre: nombre, apellido: nombre, identificacion: identificacion, direccion: direccion, telefono: telefono, correo: correo);

            List<Proveedor> proveedores = proveedorDao.ObtenerProveedores();
            Proveedor ultimoProveedor = proveedores.LastOrDefault();

            return ultimoProveedor != null ? ultimoProveedor.ID_PROVEEDOR : -1;
        }

        public List<Proveedor> ObtenerTodosProveedores()
        {
            return proveedorDao.ObtenerProveedores();
        }

        public Proveedor ObtenerProveedorPorID(int idProveedor)
        {
            return proveedorDao.ObtenerProveedorPorID(idProveedor);
        }

        public void ActualizarProveedor(int idProveedor, string nombre, string apellido, string identificacion, string direccion, string telefono, string correo)
        {
            proveedorDao.ActualizarProveedor(idProveedor: idProveedor,nombre: nombre,apellido: apellido, identificacion: identificacion,direccion: direccion,telefono: telefono, correo: correo);
        }

        public void EliminarProveedor(int idProveedor)
        {
            proveedorDao.EliminarProveedor(idProveedor);
        }
    }
}
