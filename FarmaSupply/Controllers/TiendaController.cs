using FarmaSupply.DTO;
using FarmaSupply.Servicios;
using FarmaSupply.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmaSupply.Controllers
{ /// <summary>
  /// Controlador para gestionar las peticiones HTTP POST y GET relacionadas con las tiendas de un usuario.
  /// </summary>
    public class TiendaController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;
        private readonly ITiendaServicio _tiendaServicio;

        public TiendaController(IUsuarioServicio usuarioServicio, ITiendaServicio tiendaServicio)
        {
            _usuarioServicio = usuarioServicio;
            _tiendaServicio = tiendaServicio;
        }


        /// <summary>
        /// Método para mostrar las tiendas asociadas al usuario autenticado.
        /// </summary>
        /// <returns>La vista de "listadoTiendas.cshtml" con la lista de tiendas del usuario.</returns>
        [Authorize]
        [HttpGet]
        [Route("/privada/listadoTiendas")]
        public IActionResult MostrarMisTiendas()
        {

            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método MostrarMisTiendas() de la clase TiendaController");

                string? emailDelUsuario = User.Identity?.Name;
                UsuarioDTO usuarioSesionActual = _usuarioServicio.obtenerUsuarioPorEmail(emailDelUsuario);

                if (usuarioSesionActual != null)
                {
                    
                    List<TiendaDTO> misTiendas = usuarioSesionActual.MisTiendas;

                    if (misTiendas != null && misTiendas.Count > 0)
                    {
                        ViewBag.MisTiendas = misTiendas;
                    }
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método MostrarMisTiendas() de la clase TiendaController");
                return View("~/Views/Home/listadoTiendas.cshtml");
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método MostrarMisTiendas() de la clase TiendaController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/listadoTiendas.cshtml");
            }
        }

        /// <summary>
        /// Método para mostrar el formulario de registro de una nueva tienda.
        /// </summary>
        /// <returns>La vista de "registroTienda.cshtml" con el formulario para agregar una nueva tienda.</returns>
        [Authorize]
        [HttpGet]
        [Route("/privada/registroTienda")]
        public IActionResult RegistrarTiendaGet()
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método RegistrarTiendaGet() de la clase TiendasController");

                string emailDelUsuario = User.Identity.Name;
                UsuarioDTO usuarioSesionActual = _usuarioServicio.obtenerUsuarioPorEmail(emailDelUsuario);
                TiendaDTO nuevaTienda = new TiendaDTO();
                nuevaTienda.idUsuario_Tie = usuarioSesionActual.Id;

                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistrarTiendaGet() de la clase TiendasController");
                return View("~/Views/Home/registroTienda.cshtml", nuevaTienda);
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método RegistrarTiendaGet() de la clase TiendasController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/home.cshtml");
            }
        }

        /// <summary>
        /// Método para procesar el formulario de registro de una nueva tienda.
        /// </summary>
        /// <param name="tiendaDTO">Objeto DTO que contiene los datos de la nueva tienda a registrar.</param>
        /// <returns>La vista de "listadoTiendas.cshtml" con un mensaje indicando el resultado del registro.</returns>
        [Authorize]
        [HttpPost]
        [Route("/privada/registroTienda")]
        public IActionResult RegistrarTiendaPost(TiendaDTO tiendaDTO)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método RegistrarTiendaPost() de la clase TiendasController");

                string emailDelUsuario = User.Identity.Name;
                UsuarioDTO usuarioSesionActual = _usuarioServicio.obtenerUsuarioPorEmail(emailDelUsuario);
                tiendaDTO.idUsuario_Tie=usuarioSesionActual.Id; // Establecer el ID de usuario en el TiendaDTO
                
                TiendaDTO nuevaTienda = _tiendaServicio.registrarTienda(tiendaDTO);

                if (nuevaTienda != null && nuevaTienda.DireccionTienda != null)
                {
                    // Si el usuario y el DNI no son null es que el registro se completo
                    // correctamente
                   
                    usuarioSesionActual.MisTiendas.Add(nuevaTienda);
                    ViewData["altaTiendaExito"] = "Alta de la tienda en el sistema OK";
                    ViewBag.MisTiendas = usuarioSesionActual.MisTiendas;
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistrarTiendaPost() de la clase TiendasController");
                    return View("~/Views/Home/listadoTiendas.cshtml");

                }
                else
                {
                    // Se verifica si la direccion ya existe para mostrar error personalizado en la vista
                    if (tiendaDTO.DireccionTienda == null)
                    {
                        ViewData["altaTiendaErrorDireccion"] = "Ya existe una tienda en esa dirección";
                        ViewBag.MisTiendas = usuarioSesionActual.MisTiendas;
                        EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistrarTiendaPost() de la clase TiendasController");
                        return View("~/Views/Home/registroTienda.cshtml");

                    }
                    else
                    {

                        ViewData["altaTiendaErrorNombre"] = "Ya existe una tienda con ese nombre";
                        ViewBag.MisTiendas = usuarioSesionActual.MisTiendas;
                        EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método RegistrarTiendaPost() de la clase TiendasController");
                        return View("~/Views/Home/registroTienda.cshtml");

                    }
                }
                   
              
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método RegistrarTiendaPost() de la clase TiendasController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/home.cshtml");
            }
        }

        /// <summary>
        /// Método para eliminar una tienda existente.
        /// </summary>
        /// <param name="id">El ID de la tienda a eliminar.</param>
        /// <returns>La vista de "listadoTiendas.cshtml" con un mensaje indicando el resultado de la eliminación.</returns>
        [Authorize]
        [HttpGet]
        [Route("/privada/eliminar-tienda/{id}")]
        public IActionResult EliminarTienda(long id)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método EliminarTienda() de la clase TiendasController");

                TiendaDTO tienda = _tiendaServicio.buscarPorId(id);
                string emailDelUsuario = User.Identity.Name;
                UsuarioDTO usuarioSesionActual = _usuarioServicio.obtenerUsuarioPorEmail(emailDelUsuario);
                if (tienda != null)
                {
                    
                    List<TiendaDTO> misTiendas = usuarioSesionActual.MisTiendas;
                    _tiendaServicio.eliminarTienda(id);
                   
                    if (misTiendas != null && misTiendas.Count > 0)
                    {
                        ViewBag.MisTiendas = misTiendas;
                    }
                    ViewData["eliminacionCorrecta"] = "La tienda se ha eliminado correctamente";
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método EliminarTienda() de la clase TiendasController. " + ViewData["eliminacionCorrecta"]);
                return View("~/Views/Home/listadoTiendas.cshtml");
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar el borrado de la tienda";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método EliminarTienda() de la clase TiendasController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/listadoTiendas.cshtml");
            }
        }

    }
}
