using DAL.Entidades;
using FarmaSupply.DTO;
using FarmaSupply.Utils;
using System.Linq.Expressions;

namespace FarmaSupply.Servicios
{
    public class ConvertirAdtoImpl : IConvertirAdto
    {
        public CatalogoProductoDTO catalogoProductoToDto(CatalogoProducto cP)
        {
            throw new NotImplementedException();
        }

        public List<CatalogoProductoDTO> listaCatalogoProductoToDto(List<CatalogoProducto> listaCatalogoProducto)
        {
            throw new NotImplementedException();
        }

        public List<PedidoDTO> listaPedidoToDto(List<Pedido> listaPedido)
        {
            throw new NotImplementedException();
        }

        public List<TiendaDTO> listaTiendaToDto(List<Tienda> listaTienda)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método listaTiendaToDto() de la clase ConvertirAdtoImpl");
                List<TiendaDTO> listaDto = new List<TiendaDTO>();
                foreach (Tienda t in listaTienda)
                {
                    listaDto.Add(tiendaToDto(t));
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método listaTiendaToDto() de la clase ConvertirAdtoImpl");
                return listaDto;
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog($"[ERROR ConvertirAdtoImpl - listaTiendaToDto()] - Error al convertir listaTiendaDAO a lista de listaTiendaDTO (return null): {e}");
                Console.WriteLine("\n[ERROR TiendaToDtoImpl - listaTiendaToDto()] - Error al convertir listaTiendaDAO a listaTiendaDTOO (devolviendo null): " + e);
            }
            return null;
        }

        public List<UsuarioDTO> listaUsuarioToDto(List<Usuario> listaUsuario)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método listaUsuarioToDto() de la clase ConvertirAdtoImpl");
                List<UsuarioDTO> listaDto = new List<UsuarioDTO>();
                foreach (Usuario u in listaUsuario)
                {
                    listaDto.Add(usuarioToDto(u));
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método listaUsuarioToDto() de la clase ConvertirAdtoImpl");
                return listaDto;
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog($"[ERROR ConvertirAdtoImpl - listaUsuarioToDto()] - Error al convertir lista de usuario DAO a lista de usuarioDTO (return null): {e}");
                Console.WriteLine("\n[ERROR UsuarioToDtoImpl - listaUsuarioToDto()] - Error al convertir lista de usuario DAO a lista de UsuarioDTO (devolviendo null): " + e);
            }
            return null;

        }

        public PedidoDTO pedidoToDto(Pedido p)
        {
            throw new NotImplementedException();
        }

        public TiendaDTO tiendaToDto(Tienda t)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método tiendaToDto() de la clase ConvertirAdtoImpl");


                TiendaDTO dto = new TiendaDTO();
                dto.Id = t.IdTienda;
                dto.NombreTienda = t.NombreTienda;
                dto.DireccionTienda = t.DireccionTienda;
                dto.CodigopostalTienda = t.CodigopostalTienda;



                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método tiendaToDto() de la clase ConvertirAdtoImpl");
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine("\n[ERROR TiendaToDtoImpl - tiendaToDto()] - Error al convertir tiendaDAO a tiendaDTO (return null): " + e);
                EscribirLog.escribirEnFicheroLog($"[ERROR ConvertirAdtoImpl - tiendaToDto()] - Error al convertir tiendaDAO a tiendaDTO (return null): {e}");
                return null;
            }
        }

        public UsuarioDTO usuarioToDto(Usuario u)
        {
            
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método usuarioToDto() de la clase ConvertirAdtoImpl");

                
                UsuarioDTO dto = new UsuarioDTO();
                dto.NombreUsuario = u.NombreUsuario;
                dto.ApellidosUsuario = u.ApellidosUsuario;
                dto.DniUsuario = u.DniUsuario;
                dto.TlfUsuario = u.TlfUsuario;
                dto.EmailUsuario = u.EmailUsuario;
                dto.ClaveUsuario = u.ClaveUsuario;
                dto.Token = u.Token;
                dto.ExpiracionToken = u.ExpiracionToken;
                dto.Id = u.IdUsuario;
                dto.Rol = u.Rol;
                dto.Foto = u.Foto;
                
                

                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método usuarioToDto() de la clase ConvertirAdtoImpl");
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine("\n[ERROR UsuarioToDtoImpl - usuarioToDto()] - Error al convertir usuario DAO a usuarioDTO (return null): " + e);
                EscribirLog.escribirEnFicheroLog($"[ERROR ConvertirAdtoImpl - usuarioToDto()] - Error al convertir usuario DAO a usuarioDTO (return null): {e}");
                return null;
            }
        }
    }
}
