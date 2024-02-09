using DAL.Entidades;
using FarmaSupply.DTO;
using FarmaSupply.Utils;

namespace FarmaSupply.Servicios
{
    public class ConvertirAdaoImpl : IConvertirAdao
    {
        public CatalogoProducto catalogoProductoToDao(CatalogoProductoDTO catalogoProductoDTO)
        {
            throw new NotImplementedException();
        }

        public List<CatalogoProducto> listCatalogoProductoToDao(List<CatalogoProductoDTO> listaCatalogoProductoDTO)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> listPedidoToDao(List<PedidoDTO> listaPedidoDTO)
        {
            throw new NotImplementedException();
        }

        public List<Tienda> listTiendaToDao(List<TiendaDTO> listaTiendaDTO)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> listUsuarioToDao(List<UsuarioDTO> listaUsuarioDTO)
        {
            List<Usuario> listaUsuarioDao = new List<Usuario>();

            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método listUsuarioToDao() de la clase ConvertirAdaoImpl");
                foreach (UsuarioDTO usuarioDTO in listaUsuarioDTO)
                {
                    listaUsuarioDao.Add(usuarioToDao(usuarioDTO));
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método listUsuarioToDao() de la clase ConvertirAdaoImpl");
                return listaUsuarioDao;
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog($"\n[ERROR ConvertirAdaoImpl - listUsuarioToDao()] - Al convertir lista de usuarioDTO a lista de usuarioDAO (return null): {e}");
                Console.WriteLine("\n[ERROR UsuarioToDaoImpl - toListUsuarioDao()] - Al convertir lista de UsuarioDTO a lista de UsuarioDAO (devolviendo null): " + e);
            }

            return null;

        }

        public Pedido pedidoToDao(PedidoDTO pedidoDTO)
        {
            throw new NotImplementedException();
        }

        public Tienda tiendaToDao(TiendaDTO tiendaDTO)
        {
            throw new NotImplementedException();
        }

        public Usuario usuarioToDao(UsuarioDTO usuarioDTO)
        {
            try
                  
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método usuarioToDao() de la clase ConvertirAdaoImpl");
                
                Usuario usuarioDao = new Usuario();
                usuarioDao.NombreUsuario = usuarioDTO.NombreUsuario;
                usuarioDao.ApellidosUsuario = usuarioDTO.ApellidosUsuario;
                usuarioDao.EmailUsuario = usuarioDTO.EmailUsuario;
                usuarioDao.ClaveUsuario = usuarioDTO.ClaveUsuario;
                usuarioDao.TlfUsuario = usuarioDTO.TlfUsuario;
                usuarioDao.DniUsuario = usuarioDTO.DniUsuario;
                usuarioDao.Rol = usuarioDTO.Rol;
                

                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método usuarioToDao() de la clase ConvertirAdaoImpl");
                return usuarioDao;
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog($"\n[ERROR ConvertirAdaoImpl - UsuarioToDao()] - Al convertir usuarioDTO a usuarioDAO (return null): {e}");
                Console.WriteLine("\n[ERROR UsuarioToDaoImpl - toUsuarioDao()] - Al convertir UsuarioDTO a UsuarioDAO (devolviendo null): " + e);
                return null;
            }

        }
    }
}
