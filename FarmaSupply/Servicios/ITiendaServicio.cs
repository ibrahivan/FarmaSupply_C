using FarmaSupply.DTO;

namespace FarmaSupply.Servicios
{


    /// <summary>
    /// Interfaz del servicio para la gestión de tiendas, donde se declaran los
    /// métodos correspondientes que serán implementados.
    /// </summary>
    public interface ITiendaServicio
    {
        /// <summary>
        /// Se registra a una tienda antes comprobando si ya se encuentra en la BBDD
        /// registrada la tienda 
        /// </summary>
        /// <param name="tiendaDTO">La tienda a registrar</param>
        /// <returns>El usuario registrado</returns>
        TiendaDTO registrarTienda(TiendaDTO tiendaDTO);

        /// <summary>
        /// Busca a una tienda por su identificador asignado en la bbdd
        /// </summary>
        /// <param name="id">ID de la tiendaDTO a buscar</param>
        /// <returns>La tienda buscada</returns>
        TiendaDTO buscarPorId(long id);

        /// <summary>
        /// Elimina una tienda de la base de datos
        /// </summary>
        /// <param name="id">El ID de la tienda a eliminar</param>
        void eliminarTienda(long id);

      
    }


}
