using DAL.Entidades;

namespace FarmaSupply.DTO
{
    /// <summary>
    /// Clase DTO (Data Transfer Object) para pasar información entre capas para la gestión de pedidos
    /// </summary>
    public class PedidoDTO
    {
        public long IdPedido { get; set; }
        public string ProductoPedido { get; set; }
        public Usuario IdUsuario_Ped { get; set; }
        public Tienda IdPedido_Tie { get; set; }
        public int Cantidad { get; set; }

        public PedidoDTO() { }

        public PedidoDTO(string productoPedido, Usuario idUsuario_Ped, Tienda idPedido_Tie, int cantidad)
        {
            ProductoPedido = productoPedido;
            IdUsuario_Ped = idUsuario_Ped;
            IdPedido_Tie = idPedido_Tie;
            Cantidad = cantidad;
        }
    }
}

