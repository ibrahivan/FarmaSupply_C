﻿using DAL.Entidades;
using FarmaSupply.DTO;
using FarmaSupply.Servicios;
using FarmaSupply.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmaSupply.Controllers
{
    public class AdministracionController: Controller
    {

        private readonly IUsuarioServicio _usuarioServicio;
       

        public AdministracionController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
            
        }

        /// <summary>
        /// Obtiene y muestra el listado de todos los usuarios en la vista de administración de usuarios.
        /// </summary>
        
      
        [HttpGet]
        [Route("/privada/administracion-usuarios")]
        public IActionResult ListadoUsuarios(UsuarioDTO usuario)
        {
            try
            {
                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                if (User.IsInRole("ROLE_ADMIN"))
                {
                    EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método ListadoUsuarios() de la clase AdministracionUsuariosController");
                    
                    ViewBag.Usuarios = _usuarioServicio.obtenerTodosLosUsuarios();

                }
                else if (User.IsInRole("ROLE_USER"))
                {
                    // Obtener solo el usuario actual si el usuario tiene el rol "ROLE_USER"
                    usuarioDTO= _usuarioServicio.obtenerUsuarioPorEmail(User.Identity.Name);
                    usuarios.Add(usuarioDTO);
                    ViewBag.Usuarios = usuarios;
                    

                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ListadoUsuarios() de la clase AdministracionUsuariosController");
                return View("~/Views/Home/listado.cshtml");
            }
            catch (Exception e)
            {
                ViewData["error"] = "Ocurrió un error al obtener la lista de usuarios";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método ListadoUsuarios() de la clase AdministracionUsuariosController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/home.cshtml");
            }
        }

        /// <summary>
        /// Elimina un usuario con el ID proporcionado y redirige a la vista de administración de usuarios con el resultado de la eliminación.
        /// </summary>
        /// <param name="id">ID del usuario a eliminar.</param>
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet]
        [Route("/privada/eliminar-usuario/{id}")]
        public IActionResult EliminarUsuario(long id)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método EliminarUsuario() de la clase AdministracionUsuariosController");

                UsuarioDTO usuario = _usuarioServicio.buscarPorId(id);
                List<UsuarioDTO> usuarios = _usuarioServicio.obtenerTodosLosUsuarios();

                string emailUsuarioActual = User.Identity.Name;

                int adminsRestantes = _usuarioServicio.contarUsuariosPorRol("ROLE_ADMIN");

                if (emailUsuarioActual == usuario.EmailUsuario)
                {
                    ViewData["noTePuedesEliminar"] = "Un administrador no puede eliminarse a sí mismo";
                    ViewBag.Usuarios = usuarios;
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método EliminarUsuario() de la clase AdministracionUsuariosController. " + ViewData["noTePuedesEliminar"]);
                    return View("~/Views/Home/listado.cshtml");
                }
                else if (User.IsInRole("ROLE_ADMIN") && adminsRestantes == 1 && usuario.Rol == "ROLE_ADMIN")
                {
                    ViewData["noSePuedeEliminar"] = "No se puede eliminar al último administrador del sistema";
                    ViewBag.Usuarios = usuarios;
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método EliminarUsuario() de la clase AdministracionUsuariosController. " + ViewData["noSePuedeEliminar"]);
                    return View("~/Views/Home/listado.cshtml");
                }
             

                _usuarioServicio.eliminar(id);
                ViewData["eliminacionCorrecta"] = "El usuario se ha eliminado correctamente";
                ViewBag.Usuarios = _usuarioServicio.obtenerTodosLosUsuarios();

                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método EliminarUsuario() de la clase AdministracionUsuariosController. " + ViewData["eliminacionCorrecta"]);
                return View("~/Views/Home/listado.cshtml");

            }
            catch (Exception e)
            {
                ViewData["error"] = "Ocurrió un error al eliminar el usuario";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método EliminarUsuario() de la clase AdministracionUsuariosController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/home.cshtml");
            }
        }

        /// <summary>
        /// Edita el usuario con el ID proporcionado y redirige a la vista correspondiente con el resultado de la edición.
        /// </summary>
        /// <param name="id">ID del usuario a editar.</param>
        
        [HttpGet]
        [Route("/privada/editar-usuario/{id}")]
        public IActionResult MostrarFormularioEdicion(long id)
        {
            try
             {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método MostrarFormularioEdicion() de la clase AdministracionUsuariosController");

                UsuarioDTO usuarioDTO = _usuarioServicio.buscarPorId(id);

                if (usuarioDTO == null)
                {
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método MostrarFormularioEdicion() de la clase AdministracionUsuariosController. No se encontró al usuario con id " + id);
                    return View("~/Views/Home/listado.cshtml");
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método MostrarFormularioEdicion() de la clase AdministracionUsuariosController.");
                return View("~/Views/Home/editarUsuario.cshtml", usuarioDTO);
            }
            catch (Exception e)
            {
                ViewData["error"] = "Ocurrió un error al obtener el usuario para editar";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método MostrarFormularioEdicion() de la clase AdministracionUsuariosController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/home.cshtml");
            }
        }

        /// <summary>
        /// Procesa la edición del usuario y redirige a la vista correspondiente con el resultado de la edición.
        /// </summary>
        
 
        [HttpPost]
        [Route("/privada/procesar-editar")]
        public IActionResult ProcesarFormularioEdicion(long id, string nombre, string apellidos, string telefono, string rol, IFormFile foto)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método ProcesarFormularioEdicion() de la clase AdministracionUsuariosController");

                UsuarioDTO usuarioDTO = _usuarioServicio.buscarPorId(id);
                usuarioDTO.NombreUsuario = nombre;
                usuarioDTO.ApellidosUsuario = apellidos;
                usuarioDTO.TlfUsuario = telefono;

                if (rol.Equals("Administrador"))
                {
                    usuarioDTO.Rol = "ROLE_ADMIN";
                }
                else
                {
                    usuarioDTO.Rol = rol;
                }

                if (foto != null && foto.Length > 0)
                {
                    byte[] fotoBytes;
                    using (var memoryStream = new MemoryStream())
                    {
                        foto.CopyTo(memoryStream);
                        fotoBytes = memoryStream.ToArray();
                    }
                    usuarioDTO.Foto = fotoBytes;
                }
                else
                {
                    UsuarioDTO usuarioActualDTO = _usuarioServicio.buscarPorId(id);
                    byte[] fotoActual = usuarioActualDTO.Foto;
                    usuarioDTO.Foto = fotoActual;
                }

                

                ViewData["EdicionCorrecta"] = "El Usuario se ha editado correctamente";
                _usuarioServicio.actualizarUsuario(usuarioDTO);
                ListadoUsuarios(usuarioDTO);

                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ProcesarFormularioEdicion() de la clase AdministracionUsuariosController. " + ViewData["EdicionCorrecta"]);
                return View("~/Views/Home/listado.cshtml");
            }
            catch (Exception e)
            {
                ViewData["Error"] = "Ocurrió un error al editar el usuario";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método ProcesarFormularioEdicion() de la clase AdministracionUsuariosController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/home.cshtml");
            }
        }

        /// <summary>
        /// Procesa la creación de nueva cuenta del usuario por parte de un admin y redirige a la vista 
        /// correspondiente con el resultado del alta del usuario.
        /// </summary>
        /// <param name="usuarioDTO">El objeto DTO con los nuevos datos del usuario.</param>
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpPost]
        [Route("/auth/admin/crear-cuenta")]
        public IActionResult RegistrarPost(UsuarioDTO usuarioDTO)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método RegistrarPost() de la clase AdministracionUsuariosController");

                UsuarioDTO nuevoUsuario = _usuarioServicio.registrarUsuario(usuarioDTO);

                if (nuevoUsuario.EmailUsuario == "EmailNoConfirmado")
                {
                    ViewData["EmailNoConfirmado"] = "Ya existe un usuario registrado con ese email con la cuenta sin verificar";
                    ViewBag.Usuarios = _usuarioServicio.obtenerTodosLosUsuarios();
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistrarPost() de la clase AdministracionUsuariosController. " + ViewData["EmailNoConfirmado"]);
                    return View("~/Views/Home/listado.cshtml");
                }
                else if (nuevoUsuario.EmailUsuario == "EmailRepetido")
                {
                    ViewData["EmailRepetido"] = "Ya existe un usuario con ese email registrado en el sistema";
                    ViewBag.Usuarios = _usuarioServicio.obtenerTodosLosUsuarios();
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistrarPost() de la clase AdministracionUsuariosController. " + ViewData["EmailRepetido"]);
                    return View("~/Views/Home/registro.cshtml");
                }
                else
                {
                    ViewData["MensajeRegistroExitoso"] = "Registro del nuevo usuario OK";
                    ViewBag.Usuarios = _usuarioServicio.obtenerTodosLosUsuarios();
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistrarPost() de la clase AdministracionUsuariosController." + ViewData["MensajeRegistroExitoso"]);
                    return View("~/Views/Home/listado.cshtml");
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método RegistrarPost() de la clase AdministracionUsuariosController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/listado.cshtml");
            }
        }

        /// <summary>
        /// Muestra la vista de alta de usuario desde el panel de administración enviando un DTO a dicha vista.
        /// </summary>
        [Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet]
        [Route("/auth/admin/crear-cuenta")]
        public IActionResult RegistroUsuarioDesdeAdminGet()
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método RegistroUsuarioDesdeAdminGet() de la clase AdministracionUsuariosController");

                UsuarioDTO usuarioDTO = new UsuarioDTO();
                ViewData["esRegistroDeAdmin"] = true;

                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistroUsuarioDesdeAdminGet() de la clase AdministracionUsuariosController.");
                return View("~/Views/Home/registro.cshtml", usuarioDTO);

            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, reintente";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método RegistroUsuarioDesdeAdminGet() de la clase AdministracionUsuariosController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/registro.cshtml");
            }
        }
    }
}

