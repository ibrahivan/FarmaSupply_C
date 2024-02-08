using DAL.Entidades;
using FarmaSupply.DTO;

namespace FarmaSupply.Servicios
{
    /// <summary>
    /// Interfaz  donde se declaran los metodos que son necesarios para el paso de una entidad DAO a DTO
    /// </summary>
    public interface IConvertirAdto
    {
        /// <summary>
        /// Método que convierte campo a campo un objeto entidad Usuario a UsuarioDTO.
        /// </summary>
        /// <param name="usuario">El usuario a transformar.</param>
        /// <returns>El DTO del usuario.</returns>
        public UsuarioDTO usuarioToDto(Usuario u);


        /// <summary>
        /// Convierte todos los objetos entidad Usuario DAO a una lista UsuarioDTO.
        /// </summary>
        /// <param name="listaUsuario">La lista de usuarios a transformar.</param>
        /// <returns>La lista de UsuarioDTO.</returns>
        public List<UsuarioDTO> listaUsuarioToDto(List<Usuario> listaUsuario);

        /// <summary>
        /// Convierte campo a campo un objeto entidad tienda a tiendaDTO.
        /// </summary>
        /// <param name="t">La tienda a transformar.</param>
        /// <returns>El DTO de la tienda.</returns>
        public TiendaDTO tiendaToDto(Tienda t);

        /// <summary>
        /// Convierte todos los objetos entidad tienda DAO a una lista TiendaDTO.
        /// </summary>
        /// <param name="listaTienda">La lista de tiendas DAO.</param>
        /// <returns>La lista de TiendaDTO.</returns>
        public List<TiendaDTO> listaTiendaToDto(List<Tienda> listaTienda);

        /// <summary>
        /// Convierte campo a campo un objeto entidad Pedido a PedidoDTO.
        /// </summary>
        /// <param name="p">El pedido a transformar.</param>
        /// <returns>El DTO del pedido.</returns>
        public PedidoDTO pedidoToDto(Pedido p);

        /// <summary>
        /// Convierte todos los objetos entidad Pedido a una lista PedidoDTO.
        /// </summary>
        /// <param name="listaPedido">La lista de pedidos a transformar.</param>
        /// <returns>Lista de PedidoDTO.</returns>
        public List<PedidoDTO> listaPedidoToDto(List<Pedido> listaPedido);

        /// <summary>
        /// Método que convierte campo a campo un objeto entidad CatalogoProducto a CatalogoProductoDTO
        /// </summary>
        /// <param name="cP" </param>
        /// <returns>El DTO del CatalogoProducto</returns>

        public CatalogoProductoDTO catalogoProductoToDto(CatalogoProducto cP);

        /// <summary>
        /// Método que convierte todos los objetos entidad CatalogoProducto DAO a una lista CatalogoProductoDTO.
        /// </summary>
        /// <param name="listaCatalogoProducto"</param> 
        /// <returns> La lista de objetos DTO CatalogoProducto.</returns>


        public List<CatalogoProductoDTO> listaCatalogoProductoToDto(List<CatalogoProducto> listaCatalogoProducto);
    }
}
