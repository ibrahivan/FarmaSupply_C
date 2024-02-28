using DAL.Entidades;

namespace FarmaSupply.DTO
{
    /// <summary>
    /// Clase DTO (Data Transfer Object) para pasar información entre capas para la gestión de tiendas
    /// </summary>
    public class TiendaDTO
    {
        public long Id { get; set; }
        public string NombreTienda { get; set; }
        public string DireccionTienda { get; set; }
        public string CodigopostalTienda { get; set; }
        public List<PedidoDTO> MisPedidos { get; set; } = new List<PedidoDTO>();

        public long IdPropietario { get; set; }
    
        public TiendaDTO()
        {
        }

        public TiendaDTO(string nombreTienda, string direccionTienda, string codigopostalTienda, List<PedidoDTO> misPedidos, long idPropietario)
        {
            NombreTienda = nombreTienda;
            DireccionTienda = direccionTienda;
            CodigopostalTienda = codigopostalTienda;
            MisPedidos = misPedidos;
            IdPropietario = idPropietario;
        }
    }
}
