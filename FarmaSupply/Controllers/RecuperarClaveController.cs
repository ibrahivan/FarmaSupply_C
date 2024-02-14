using FarmaSupply.DTO;
using FarmaSupply.Servicios;
using FarmaSupply.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FarmaSupply.Controllers
{
    public class RecuperarClaveController:Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public RecuperarClaveController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        [Route("/auth/solicitar-recuperacion")]
        public IActionResult MostrarVistaIniciarRecuperacion()
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método MostrarVistaIniciarRecuperacion() de la clase SolicitarRecuperacionController");

                UsuarioDTO usuarioDTO = new UsuarioDTO();
                return View("~/Views/Home/iniciarRecuperacion.cshtml", usuarioDTO);
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método MostrarVistaIniciarRecuperacion() de la clase SolicitarRecuperacionController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/iniciarRecuperacion.cshtml");
            }
        }

        [HttpPost]
        [Route("/auth/iniciar-recuperacion")]
        public IActionResult ProcesarInicioRecuperacion([Bind("EmailUsuario")] UsuarioDTO usuarioDTO)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método ProcesarInicioRecuperacion() de la clase RecuperarClaveController");

                bool envioConExito = _usuarioServicio.iniciarProcesoRecuperacion(usuarioDTO.EmailUsuario);

                if (envioConExito)
                {
                    ViewData["MensajeExitoMail"] = "Proceso de recuperación OK";
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ProcesarInicioRecuperacion() de la clase RecuperarClaveController. " + ViewData["MensajeExitoMail"]);
                    return View("~/Views/Home/login.cshtml");
                }
                else
                {
                    ViewData["MensajeErrorMail"] = "No se inició el proceso de recuperación, cuenta de correo electrónico no encontrada.";
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ProcesarInicioRecuperacion() de la clase RecuperarClaveController. " + ViewData["MensajeErrorMail"]);
                return View("~/Views/Home/iniciarRecuperacion.cshtml");
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método ProcesarInicioRecuperacion() de la clase RecuperarClaveController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/iniciarRecuperacion.cshtml");
            }
        }
        [HttpGet]
        [Route("/auth/recuperar")]
        public IActionResult MostrarVistaRecuperar([FromQuery(Name = "token")] string token)
        {

            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método MostrarVistaRecuperar() de la clase RecuperarPasswordController");

                UsuarioDTO usuario = _usuarioServicio.obtenerUsuarioPorToken(token);

                if (usuario != null)
                {
                    ViewData["UsuarioDTO"] = usuario;
                }
                else
                {
                    ViewData["MensajeErrorTokenValidez"] = "El enlace de recuperación no es válido o el usuario no se ha encontrado";
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método MostrarVistaRecuperar() de la clase RecuperarClaveController. " + ViewData["MensajeErrorTokenValidez"]);
                    return View("~/Views/Home/iniciarRecuperacion.cshtml");
                }
                EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método MostrarVistaRecuperar() de la clase RecuperarClaveController");
                return View("~/Views/Home/recuperar.cshtml");
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método MostrarVistaRecuperar() de la clase RecuperarClaveController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/iniciarRecuperacion.cshtml");
            }
        }


        [HttpPost]
        [Route("/auth/recuperar")]
        public IActionResult ProcesarRecuperacionContraseña(UsuarioDTO usuarioDTO)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método ProcesarRecuperacionContrasenya() de la clase RecuperarClaveController");

                UsuarioDTO usuarioExistente = _usuarioServicio.obtenerUsuarioPorToken(usuarioDTO.Token);

                if (usuarioExistente == null)
                {
                    ViewData["MensajeErrorTokenValidez"] = "El enlace de recuperación no es válido";
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ProcesarRecuperacionContrasenya() de la clase RecuperarClaveController. " + ViewData["MensajeErrorTokenValidez"]);
                    return View("~/Views/Home/iniciarRecuperacion.cshtml");
                }

                if (usuarioExistente.ExpiracionToken.HasValue && usuarioExistente.ExpiracionToken.Value < DateTime.Now)
                {
                    ViewData["MensajeErrorTokenExpirado"] = "El enlace de recuperación ha expirado";
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ProcesarRecuperacionContrasenya() de la clase RecuperarClaveController. " + ViewData["MensajeErrorTokenExpirado"]);
                    return View("~/Views/Home/iniciarRecuperacion.cshtml");
                }

                bool modificadaPassword = _usuarioServicio.modificarContrasenyaConToken(usuarioDTO);

                if (modificadaPassword)
                {
                    ViewData["ContraseñaModificadaExito"] = "Contraseña modificada OK";
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ProcesarRecuperacionContrasenya() de la clase RecuperarClaveController. " + ViewData["ContraseñaModificadaExito"]);
                    return View("~/Views/Home/login.cshtml");
                }
                else
                {
                    ViewData["ContraseñaModificadaError"] = "Error al cambiar de contraseña";
                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método ProcesarRecuperacionContrasenya() de la clase RecuperarClaveController. " + ViewData["ContraseñaModificadaError"]);
                    return View("~/Views/Home/iniciarRecuperacion.cshtml");
                }
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                EscribirLog.escribirEnFicheroLog("[ERROR] Se lanzó una excepción en el método ProcesarRecuperacionContrasenya() de la clase RecuperarClaveController: " + e.Message + e.StackTrace);
                return View("~/Views/Home/iniciarRecuperacion.cshtml");
            }
        }

    }
}
