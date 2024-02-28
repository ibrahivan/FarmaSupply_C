namespace FarmaSupply.DTO
{
    /// <summary>
    /// Clase DTO (Data Transfer Object) para pasar información entre capas para la gestión del catalogo de productos
    /// </summary>
    public class CatalogoProductoDTO
    {
        public long IdCatalogoProducto;
        public int Cantidad;
        public String Descripcion;
        public String NombreProducto;
        public int PrecioUnitario;
        //Cons
        public CatalogoProductoDTO()
        {
        }

        public CatalogoProductoDTO(int cantidad, string descripcion, string nombreProducto, int precioUnitario)
        {
            Cantidad = cantidad;
            Descripcion = descripcion;
            NombreProducto = nombreProducto;
            PrecioUnitario = precioUnitario;
        }
    }
}
