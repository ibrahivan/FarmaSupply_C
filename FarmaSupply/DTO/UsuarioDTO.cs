using DAL.Entidades;
using System.Globalization;

namespace FarmaSupply.DTO
{
    /// <summary>
    /// Clase DTO (Data Transfer Object) para pasar información entre capas para la gestión de usuarios
    /// </summary>
    public class UsuarioDTO
    {
        // ATRIBUTOS
        public long Id { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string DniUsuario { get; set; }
        public string TlfUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public DateTime? ExpiracionToken { get; set; }
        public bool CuentaConfirmada { get; set; }
        public byte[] Foto { get; set; }
        public string Rol { get; set; }
        public List<Pedido> List_Usu_Ped { get; set; } = new List<Pedido>();
        public List<Tienda> List_Usu_Tie { get; set; } = new List<Tienda>();

        // CONSTRUCTORES
        public UsuarioDTO() { }

        public UsuarioDTO(string nombreUsuario, string apellidosUsuario, string dniUsuario, string tlfUsuario,
            string emailUsuario, string claveUsuario, byte[] foto, string rol)
        {
            NombreUsuario = nombreUsuario;
            ApellidosUsuario = apellidosUsuario;
            DniUsuario = dniUsuario;
            TlfUsuario = tlfUsuario;
            EmailUsuario = emailUsuario;
            ClaveUsuario = claveUsuario;
            Foto = foto;
            Rol = rol;
        }

        public UsuarioDTO(string nombreUsuario, string apellidosUsuario, string dniUsuario, string tlfUsuario,
            string emailUsuario, string claveUsuario, string token, string password, string password2,
            DateTime? expiracionToken, bool cuentaConfirmada, byte[] foto, string rol, List<Pedido> list_Usu_Ped,
            List<Tienda> list_Usu_Tie)
        {
            NombreUsuario = nombreUsuario;
            ApellidosUsuario = apellidosUsuario;
            DniUsuario = dniUsuario;
            TlfUsuario = tlfUsuario;
            EmailUsuario = emailUsuario;
            ClaveUsuario = claveUsuario;
            Token = token;
            Password = password;
            Password2 = password2;
            ExpiracionToken = expiracionToken;
            CuentaConfirmada = cuentaConfirmada;
            Foto = foto;
            Rol = rol;
            List_Usu_Ped = list_Usu_Ped;
            List_Usu_Tie = list_Usu_Tie;
        }
    }
}
