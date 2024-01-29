using cine_acceso_datos.DAO;
using cine_acceso_datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_logica_negocio
{
    public class PagosLogica
    {
        private PagosDAO pagosDao;

        public PagosLogica()
        {
            pagosDao = new PagosDAO();
        }

        public void InsertarPago(Pagos pago)
        {
            pagosDao.InsertarPago(pago);
        }

        public List<Pagos> ObtenerTodosLosPagos()
        {
            return pagosDao.ObtenerTodosLosPagos();
        }

        public Pagos ObtenerPagoPorID(int idPago)
        {
            return pagosDao.ObtenerPagoPorID(idPago);
        }

        public void ActualizarPago(Pagos pago)
        {
            pagosDao.ActualizarPago(pago);
        }

        public void EliminarPago(int idPago)
        {
            pagosDao.EliminarPago(idPago);
        }
    }

}
