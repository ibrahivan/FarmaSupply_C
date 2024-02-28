using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    [Table("catalogoProductos", Schema = "fs_logica")]
    public class CatalogoProducto
    {
       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_catalogo_producto")]
        public long IdCatalogoProducto { get; set; }

        [Column("nombre_producto")]
        public String NombreProducto { get; set; }

        [Column("precio_unitario_producto")]
        public int PrecioUnitario { get; set; }

        [Column("cantidad_producto")]
        public int Cantidad { get; set; }

        
        [Column("descripcion_producto")]
        public String Descripcion { get; set; }

        //Para la relacion N:M con pedidos  
        [Column("idCat_Ped")]
        public List<Pedido> List_Cat_Ped { get; set; } = new List<Pedido>();

        //Constructores
        public CatalogoProducto()
        {
        }

        public CatalogoProducto(int cantidad)
        {
            Cantidad = cantidad;
        }
    }
}