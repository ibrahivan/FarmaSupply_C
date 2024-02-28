using DAL.Entidades;
using FarmaSupply.DTO;
using FarmaSupply.Utils;
using Microsoft.EntityFrameworkCore;


namespace FarmaSupply.Servicios
{
    public class TiendaServicioImpl : ITiendaServicio
    {
        private readonly FarmasupplyContext _contexto;
        private readonly IConvertirAdao _convertirAdao;
        private readonly IConvertirAdto _convertirAdto;
        
        public TiendaServicioImpl(
         FarmasupplyContext contexto,
         IConvertirAdao convertirAdao,
         IConvertirAdto convertirAdto
        )
        {
            _contexto = contexto;
            _convertirAdao = convertirAdao;
            _convertirAdto = convertirAdto;
        }

        public TiendaDTO registrarTienda(TiendaDTO tiendaDTO)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método registrarTienda() de la clase TiendaServicioImpl");

                Usuario? usuarioPropietario = _contexto.Usuarios.Find(tiendaDTO.IdPropietario);
                // Comprueba si ya existe una tienda con el nombre que quiere registrar
                var tiendaDaoNombre = _contexto.Tiendas.FirstOrDefault((t => t.NombreTienda == tiendaDTO.NombreTienda));

                if (tiendaDaoNombre != null)
                {
                    return null; // Si no es null es que ya está registrada
                }

                // Ahora se comprueba si hay una tienda por la direccion que quiere registrar
                var yaExisteDireccion = _contexto.Tiendas.FirstOrDefault((t => t.DireccionTienda == tiendaDTO.DireccionTienda));

                if (yaExisteDireccion!=null)
                {
                    // Si es que ya hay una tienda con esa direccion se setea a null para controlar el
                    // error en controlador
                    tiendaDTO.DireccionTienda=null;
                    return tiendaDTO;
                }
                
                Tienda tienda = _convertirAdao.tiendaToDao(tiendaDTO);

                if (usuarioPropietario != null)
                    tienda.IdUsuarioPropietarioNavigation = usuarioPropietario;

                tienda.IdUsuarioPropietario = tienda.IdUsuarioPropietarioNavigation.IdUsuario;
                 _contexto.Tiendas.Add(tienda);
                 _contexto.SaveChanges();
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método registraTienda() de la clase TiendaServicioImpl");
                
                return tiendaDTO;
            }
            catch (DbUpdateException dbe)
            {
                EscribirLog.escribirEnFicheroLog("[Error TiendaServicioImpl - registraTienda()] Error de persistencia al actualizar la bbdd: " + dbe.Message);
                return null;
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog("[Error TiendaServicioImpl - registraTienda()] Error al registrar una tienda: " + e.Message);
                return null;
            }


        }

        public TiendaDTO buscarPorId(long id)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método buscarPorId() de la clase TiendaServicioImpl");

                Tienda? tienda = _contexto.Tiendas.Find(id);
                if (tienda != null)
                {
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método buscarPorId() de la clase TiendaServicioImpl");
                    return _convertirAdto.tiendaToDto(tienda);
                }
            }
            catch (Exception e)
            {
                EscribirLog.escribirEnFicheroLog($"[ERROR TiendaServicioImpl - buscarPorId()] - Al buscar una tienda de un usuario por su id: {e}");
            }
            return null;

        }

        public void eliminarTienda(long id)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método eliminarTienda() de la clase TiendaServicioImpl");

                Tienda? tienda = _contexto.Tiendas.Find(id);
                if (tienda != null)
                {
                    _contexto.Tiendas.Remove(tienda);
                    _contexto.SaveChanges();
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método eliminarTienda() de la clase TiendaServicioImpl. Tienda eliminada correctamente.");
                }
            }
            catch (DbUpdateException dbe)
            {
                EscribirLog.escribirEnFicheroLog($"[Error TiendaServicioImpl - eliminarTienda()] Error de persistencia al eliminar una tienda por su id: {dbe.Message}");
            }
        }
        public List<TiendaDTO> obtenerTiendasPorPropietarioId(long id)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método obtenerTiendasPorPropietarioId() de la clase TiendaServicioImpl");

                List<Tienda> listaTiendas = _contexto.Tiendas.Where(t => t.IdUsuarioPropietario == id).ToList();
                return _convertirAdto.listaTiendaToDto(listaTiendas);
            }
            catch (ArgumentNullException e)
            {
                EscribirLog.escribirEnFicheroLog($"[ERROR TiendaServicioImpl - obtenerTiendasPorPropietarioId()] - Argumento id es NULL al obtener las tiendas de un usuario: {e}");
                return null;
            }
        }



    }
}

