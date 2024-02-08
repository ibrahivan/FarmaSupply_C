using DAL.Entidades;
using FarmaSupply.DTO;

namespace FarmaSupply.Servicios
{
    /// <summary>
    /// Interfaz  donde se declaran los metodos que son necesarios para el paso de una DTO a entidad DAO
    /// </summary>
    public interface IConvertirAdao
    {
        /// <summary>
        /// Convierte un objeto UsuarioDTO en un objeto UsuarioDAO campo por campo.
        /// </summary>
        /// <param name="usuarioDTO">El objeto UsuarioDTO a convertir.</param>
        /// <returns>El objeto Usuario convertido a DAO.</returns>

        public Usuario usuarioToDao(UsuarioDTO usuarioDTO);

        /// <summary>
        /// Convierte una lista de objetos UsuarioDTO en una lista de objetos UsuarioDAO.
        /// </summary>
        /// <param name="listaUsuarioDTO">La lista de objetos UsuarioDTO cargados.</param>
        /// <returns>La lista de usuarios convertida a DAOs.</returns>

        public List<Usuario> listUsuarioToDao(List<UsuarioDTO> listaUsuarioDTO);
        
        /// <summary>
        /// Convierte campo a campo un objeto TiendaDTO a DAO.
        /// </summary>
        /// <param name="tiendaDTO">El objeto TiendaDTO.</param>
        /// <returns>La Tienda convertida a DAO.</returns>

        public Tienda tiendaToDao(TiendaDTO tiendaDTO);
        
        /// <summary>
        /// Convierte toda una lista de objetos TiendaDTO a una lista de DAOs.
        /// </summary>
        /// <param name="listaTiendaDTO">Lista cargada de objetos TiendaDTO.</param>
        /// <returns>Lista de tiendas convertidas a DAO.</returns>

        public List<Tienda> listTiendaToDao(List<TiendaDTO> listaTiendaDTO);

        /// <summary>
        /// Convierte campo a campo un objeto UsuarioDTO a DAO.
        /// </summary>
        /// <param name="usuarioDTO">El objeto UsuarioDTO.</param>
        /// <returns>Usuario convertido a DAO.</returns>

        public Pedido pedidoToDao(PedidoDTO pedidoDTO);

        /// <summary>
        /// Convierte toda una lista de objetos PedidoDTO a lista de DAOs.
        /// </summary>
        /// <param name="listaPedidoDTO">Lista cargada de objetos PedidoDTO.</param>
        /// <returns>Lista de pedidos DAO.</returns>

        public List<Pedido> listPedidoToDao(List<PedidoDTO> listaPedidoDTO);

        /// <summary>
        /// Método que convierte campo a campo un objeto CatalogoProductoDTO a DAO.
        /// </summary>
        /// <param name="catalogoProductoDTO">El objeto CatalogoProductoDTO.</param>
        /// <returns>CatalogoProducto convertido a DAO.</returns>

        public CatalogoProducto catalogoProductoToDao(CatalogoProductoDTO catalogoProductoDTO);

        /// <summary>
        /// Método que convierte toda una lista de objetos CatalogoProductoDTO a lista de DAOs.
        /// </summary>
        /// <param name="listaCatalogoProducto">Lista cargada de objetos CatalogoProductoDTO.</param>
        /// <returns>Lista de CatalogoProducto DAO.</returns>

        public List<CatalogoProducto> listCatalogoProductoToDao(List<CatalogoProductoDTO> listaCatalogoProductoDTO);
    }
}
