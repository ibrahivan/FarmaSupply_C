using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
/// <summary>
/// Clase DAO (Data Access Object) que representa la tabla usuarios de la BBDD, 
/// ejerce como modelo virtual de la tabla en la aplicación.
/// </summary>

namespace DAL.Entidades
{
    [Table("usuarios", Schema = "fs_gestion")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_usuario")]
        public long IdUsuario { get; set; }

        [Required]
        [Column("nombre_usuario")]
        [StringLength(70)]
        public string? NombreUsuario { get; set; } =null;

        [Column("apellidos_usuario")]
        [StringLength(100)]
        public string? ApellidosUsuario { get; set; } =null;

        [Required]
        [Column("dni_usuario")]
        [StringLength(9)]
        public string? DniUsuario { get; set; } = null;

        [Column("tlf_usuario")]
        [StringLength(9)]
        public string? TlfUsuario { get; set; } = null;

        [Required]
        [Column("email_usuario")]
        [StringLength(100)] 
        public string? EmailUsuario { get; set; }

        [Required]
        [Column("clave_usuario")]
        [StringLength(100)]
        public string? ClaveUsuario { get; set; }

        [Column("token_recuperacion")]
        [StringLength(100)]
        public string? Token { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime? ExpiracionToken { get; set; }

        [Column("rol_usuario")]
        [StringLength(20)]
        public string? Rol { get; set; }

        [Column("cuenta_confirmada")]
        public bool CuentaConfirmada { get; set; } = false;

        [Column("foto_usuario")]
        public byte[]? Foto { get; set; }

        public virtual ICollection<Tienda> Tiendas { get; set; } = new List<Tienda>();




        public Usuario() { }

        public Usuario(string? nombreUsuario, string? apellidosUsuario, string? dniUsuario, string? tlfUsuario, string? emailUsuario, string? claveUsuario, string? token, DateTime? expiracionToken, string? rol, bool cuentaConfirmada, byte[]? foto, ICollection<Tienda> tiendas)
        {
            NombreUsuario = nombreUsuario;
            ApellidosUsuario = apellidosUsuario;
            DniUsuario = dniUsuario;
            TlfUsuario = tlfUsuario;
            EmailUsuario = emailUsuario;
            ClaveUsuario = claveUsuario;
            Token = token;
            ExpiracionToken = expiracionToken;
            Rol = rol;
            CuentaConfirmada = cuentaConfirmada;
            Foto = foto;
            Tiendas = tiendas;
        }
    }
}
