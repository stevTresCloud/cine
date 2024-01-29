using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cine_acceso_datos.Entidades;
using cine_acceso_datos.DAO;

namespace cine_logica_negocio
{
    public class FacturaLogica
    {
        private FacturaDAO facturaDao;

        public FacturaLogica()
        {
            facturaDao = new FacturaDAO();
        }

        public int InsertarFactura(int idFactura, string numeroFactura, DateTime fechaExpedicion, string estadoPago)
        {
            facturaDao.InsertarFactura(idFactura, numeroFactura, fechaExpedicion, estadoPago);
            Factura factura = facturaDao.ObtenerFacturaPorID(idFactura);
            return factura != null ? factura.ID_FACTURA : -1;
        }

        public List<Factura> ObtenerTodasFacturas()
        {
            return facturaDao.ObtenerTodasFacturas();
        }

        public Factura ObtenerFacturaPorID(int idFactura)
        {
            return facturaDao.ObtenerFacturaPorID(idFactura);
        }

        public void ActualizarFactura(int idPedidoCompra, int idFactura, string numeroFactura, DateTime fechaExpedicion, string estadoPago)
        {
            facturaDao.ActualizarFactura(idPedidoCompra, idFactura, numeroFactura, fechaExpedicion, estadoPago);
        }

        public void EliminarFactura(int idFactura)
        {
            facturaDao.EliminarFactura(idFactura);
        }
    }

}
