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


        //Para la relacion pedido-usuario
        public long id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario IdUsuario_Ped { get; set; }
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

        public Pedido( Usuario idUsuario_Ped, Tienda idPedido_Tie)
        {
            
            IdUsuario_Ped = idUsuario_Ped;
            IdPedido_Tie = idPedido_Tie;
        }
    }
}
