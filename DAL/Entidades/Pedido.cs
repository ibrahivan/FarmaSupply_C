using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Clase DAO (Data Access Object) que representa la tabla pedidos de la BBDD, 
/// ejerce como modelo virtual de la tabla en la aplicación.
/// </summary>
namespace DAL.Entidades
{
    [Table("pedidos", Schema = "fs_logica")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_pedido")]
        public long IdPedido { get; set; }


        [Column("precio_pedido")]
        public int PrecioPedido { get; set; }

        //
        //Para la relacion pedido-tienda
        public long id_tienda { get; set; }
        [ForeignKey("id_tienda")]
        public Tienda IdPedido_Tie { get; set; }
        //
        //Para la relacion N:M con catalogo de productos   
        [Column("idPed_Cat")]
        public List<CatalogoProducto> List_Ped_Cat { get; set; } = new List<CatalogoProducto>();

        //Constructores
        public Pedido() { }

        public Pedido(int precioPedido, long id_tienda, Tienda idPedido_Tie, List<CatalogoProducto> list_Ped_Cat)
        {
            PrecioPedido = precioPedido;
            this.id_tienda = id_tienda;
            IdPedido_Tie = idPedido_Tie;
            List_Ped_Cat = list_Ped_Cat;
        }
    }
}
