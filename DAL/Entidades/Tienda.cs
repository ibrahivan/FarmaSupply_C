using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
/// <summary>
/// Clase DAO (Data Access Object) que representa la tabla tiendas de la BBDD, 
/// ejerce como modelo virtual de la tabla en la aplicación.
/// </summary>
namespace DAL.Entidades
{
    [Table("tiendas", Schema = "fs_logica")]
    public class Tienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_tienda")]
        public long IdTienda { get; set; }

        [Required]
        [Column("nombre_tienda")]
        [StringLength(70)]
        public string NombreTienda { get; set; }

        [Required]
        [Column("direccion_tienda")]
        [StringLength(70)]
        public string DireccionTienda { get; set; }

        [Required]
        [Column("codigopostal_tienda")]
        [StringLength(70)]
        public string CodigopostalTienda { get; set; }

        //Para la relacion tienda-usuario
        public long id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public Usuario IdUsuario_Tie { get; set; }
        //
        public virtual ICollection<Pedido> List_Tie_Ped { get; set; } = new List<Pedido>();

        public Tienda() { }

        public Tienda(string nombreTienda, string direccionTienda, string codigopostalTienda, Usuario idUsuario_Tie,
                      ICollection<Pedido> list_Tie_Ped)
        {
            NombreTienda = nombreTienda;
            DireccionTienda = direccionTienda;
            CodigopostalTienda = codigopostalTienda;
            IdUsuario_Tie = idUsuario_Tie;
            List_Tie_Ped = list_Tie_Ped;
        }
    }
}
