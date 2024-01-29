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
    public class UsuariosLogica
    {
        private UsuarioDAO usuariosDao;

        public UsuariosLogica()
        {
            usuariosDao = new UsuarioDAO();
        }

        public int InsertarUsuario(Usuario usuario)
        {
            usuariosDao.InsertarUsuario(usuario);
            List<Usuario> usuarios = usuariosDao.ObtenerTodosLosUsuarios();
            return usuarios.Last().ID_USUARIO;
        }

        public List<Usuario> ObtenerTodosUsuarios()
        {
            return usuariosDao.ObtenerTodosLosUsuarios();
        }

        public Usuario ObtenerUsuarioPorID(int idUsuario)
        {
            return usuariosDao.ObtenerUsuarioPorID(idUsuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            usuariosDao.ActualizarUsuario(usuario);
        }

        public void EliminarUsuario(int idUsuario)
        {
            usuariosDao.EliminarUsuario(idUsuario);
        }
    }
}
