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
        public List<PedidoDTO> List_Tie_Ped { get; set; } = new List<PedidoDTO>();

        public TiendaDTO()
        {
        }

        public TiendaDTO(string nombreTienda, string direccionTienda, string codigopostalTienda,
            List<PedidoDTO> list_Tie_Ped)
        {
            NombreTienda = nombreTienda;
            DireccionTienda = direccionTienda;
            CodigopostalTienda = codigopostalTienda;
            List_Tie_Ped = list_Tie_Ped;
        }
    }
}
