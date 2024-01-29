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
    public class BoletosLogica
    {
        private BoletosDAO boletoDao = new BoletosDAO();

        public int InsertarBoleto(int idBoletos, string codigoTicket)
        {
            boletoDao.InsertarBoleto(idBoletos, codigoTicket);
            List<Boletos> boletos = boletoDao.ObtenerBoletos();
            return boletos.Count > 0 ? boletos[0].ID_BOLETOS : -1;
        }

        public List<Boletos> ObtenerBoletos()
        {
            return boletoDao.ObtenerBoletos();
        }

        public Boletos ObtenerBoletoPorId(int idBoletos)
        {
            List<Boletos> boletos = boletoDao.ObtenerBoletos();
            return boletos.FirstOrDefault(boleto => boleto.ID_BOLETOS == idBoletos);
        }

        public void ActualizarBoleto(int idBoletos, string codigoTicket)
        {
            boletoDao.ActualizarBoleto(idBoletos, codigoTicket);
        }

        public void EliminarBoleto(int idBoletos)
        {
            boletoDao.EliminarBoleto(idBoletos);
        }
    }
}
