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
            List<Tienda> listaTiendaDao = new List<Tienda>();

            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método listTiendaToDao() de la clase ConvertirAdaoImpl");
                foreach (TiendaDTO tiendaDTO in listaTiendaDTO)
                {
                    listaTiendaDao.Add(tiendaToDao(tiendaDTO));
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método listTiendaToDao() de la clase ConvertirAdaoImpl");
                return listaTiendaDao;
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog($"\n[ERROR ConvertirAdaoImpl - listTiendaToDao()] - Al convertir lista de usuarioDTO a lista de tiendaDAO (return null): {e}");
                Console.WriteLine("\n[ERROR TiendaToDaoImpl - tolistTiendaToDao()] - Al convertir lista de tiendaDTO a lista de tiendaDAO (devolviendo null): " + e);
            }

            return null;
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
            try

            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método tiendaToDao() de la clase ConvertirAdaoImpl");

                Tienda tiendaDao = new Tienda();
                tiendaDao.IdTienda = tiendaDTO.Id;
                tiendaDao.NombreTienda = tiendaDTO.NombreTienda;
                tiendaDao.DireccionTienda = tiendaDTO.DireccionTienda;
                tiendaDao.CodigopostalTienda = tiendaDTO.CodigopostalTienda;
               


                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método tiendaToDao() de la clase ConvertirAdaoImpl");
                return tiendaDao;
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog($"\n[ERROR ConvertirAdaoImpl - tiendaToDao()] - Al convertir TiendaDTO a TiendaDAO (return null): {e}");
                Console.WriteLine("\n[ERROR TiendaToDaoImpl - toTiendaDao()] - Al convertir TiendaDTO a TiendaDAO (devolviendo null): " + e);
                return null;
            }

        }
    

        public Usuario usuarioToDao(UsuarioDTO usuarioDTO)
        {
            try
                  
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método usuarioToDao() de la clase ConvertirAdaoImpl");
                
                Usuario usuarioDao = new Usuario();
                usuarioDao.IdUsuario=usuarioDTO.Id;
                usuarioDao.NombreUsuario = usuarioDTO.NombreUsuario;
                usuarioDao.ApellidosUsuario = usuarioDTO.ApellidosUsuario;
                usuarioDao.EmailUsuario = usuarioDTO.EmailUsuario;
                usuarioDao.ClaveUsuario = usuarioDTO.ClaveUsuario;
                usuarioDao.TlfUsuario = usuarioDTO.TlfUsuario;
                usuarioDao.DniUsuario = usuarioDTO.DniUsuario;
                usuarioDao.Rol = usuarioDTO.Rol;
                usuarioDao.Foto = usuarioDTO.Foto;
                

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
