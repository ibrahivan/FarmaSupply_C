using DAL.Entidades;

namespace FarmaSupply.DTO
{
    /// <summary>
    /// Clase DTO (Data Transfer Object) para pasar información entre capas para la gestión de pedidos
    /// </summary>
    public class PedidoDTO
    {
        public long IdPedido { get; set; }
        public string PrecioPedido { get; set; }
        public Tienda IdPedido_Tie { get; set; }
        public List<CatalogoProducto> listaCtalogoProductos;

        public PedidoDTO() { }

        public PedidoDTO(string precioPedido, Tienda idPedido_Tie, List<CatalogoProducto> listaCtalogoProductos)
        {
            PrecioPedido = precioPedido;
            IdPedido_Tie = idPedido_Tie;
            this.listaCtalogoProductos = listaCtalogoProductos;
        }
    }
}

