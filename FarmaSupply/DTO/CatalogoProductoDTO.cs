namespace FarmaSupply.DTO
{
    /// <summary>
    /// Clase DTO (Data Transfer Object) para pasar información entre capas para la gestión del catalogo de productos
    /// </summary>
    public class CatalogoProductoDTO
    {
        public long IdCatalogoProducto { get; set; }
        public int Cantidad { get; set; }
        public String Descripcion { get; set; }

        //Cons
        public CatalogoProductoDTO()
        {
        }

        public CatalogoProductoDTO(int cantidad, string descripcion)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
        }
    }
}
