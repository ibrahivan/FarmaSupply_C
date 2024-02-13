using DAL.Entidades;
using FarmaSupply.DTO;

namespace FarmaSupply.Servicios
{
    /// <summary>
    /// Interfaz del servicio para la gestión de usuarios, donde se declaran los
    /// métodos correspondientes que serán implementados.
    /// </summary>

    public interface IUsuarioServicio
    {
        /// <summary>
        /// Se registra a un usuario antes comprobando si ya se encuentra en la BBDD registrado el usuario
        /// </summary>
        /// <param name="userDTO">El usuario a registrar</param>
        /// <returns>El usuario registrado</returns>

        public UsuarioDTO registrarUsuario(UsuarioDTO userDTO);

        /// <summary>
        /// Busca a un usuario por su identificador asignado en la bbdd
        /// </summary>
        /// <param name="id">ID del usuarioDTO a buscar</param>
        /// <returns>El usuario buscado</returns>

        public UsuarioDTO buscarPorId(long id);

        /// <summary>
        /// Busca a un usuario por su email asignado en la bbdd
        /// </summary>
        /// <param name="email">Email del usuarioDTO a buscar</param>
        /// <returns>El usuario buscado</returns>
        public UsuarioDTO obtenerUsuarioPorEmail(string email);

        /// <summary>
        /// Busca a un usuario por su DNI
        /// </summary>
        /// <param name="dni">DNI del usuario que se quiere encontrar</param>
        /// <returns>True si el usuario existe, false en caso contrario</returns>

        public List<UsuarioDTO> obtenerTodosLosUsuarios();

        /// <summary>
        /// Busca un usuario por su token de recuperación.
        /// </summary>
        /// <param name="token">Token que identifica al usuario que recibió un correo con la URL y dicho token</param>
        /// <returns>El usuario buscado</returns>

        public UsuarioDTO obtenerUsuarioPorToken(String token);

        /// <summary>
        /// Método que controla que el usuario existe y no está su cuenta confirmada.
        /// </summary>
        /// <param name="emailUsuario">El email del usuario a confirmar</param>
        /// <returns>True si el proceso se ha realizado correctamente, false en caso contrario</returns>
       
        bool confirmarCuenta(String emailUsuario);

        /// <summary>
        /// Método que controla que el usuario existe y no está su cuenta confirmada.
        /// </summary>
        /// <param name="emailUsuario">El email del usuario a confirmar</param>
        /// /// <param name="claveUsuario">clave usuario</param>
        /// <returns>True si el proceso se ha realizado correctamente, false en caso contrario</returns>
        bool verificarCredenciales(string emailUsuario, string claveUsuario);

        /// <summary>
        /// Modifica la contraseña del usuario registrando el token
        /// </summary>
        /// <param name="usuario">El usuario para cambiar su contraseña</param>
        /// <returns>True si el proceso se ha iniciado correctamente, false en caso contrario</returns>

        public bool modificarContrasenyaConToken(UsuarioDTO usuario);

        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        /// <param name="id">El identificador del usuario</param>

        public void eliminar(long id);

        /// <summary>
        /// Modifica un usuario en la base de datos.
        /// </summary>
        /// <param name="usuarioModificado">El usuario con los datos modificados</param>

        public void actualizarUsuario(UsuarioDTO usuarioModificado);


        /// <summary>
        /// Inicia proceso recuperacion usuario
        /// </summary>
        /// <param name="emailUsuario">El email del usuario</param>
        public bool iniciarProcesoRecuperacion(string emailUsuario);


        public int contarUsuariosPorRol(string rol);
        /// <summary>
        /// Convierte una imagen en un string.
        /// </summary>
        /// <param name="data">Los datos de la imagen a convertir.</param>
        /// <returns>Un string que representa la imagen convertida.</returns>

    }
}
