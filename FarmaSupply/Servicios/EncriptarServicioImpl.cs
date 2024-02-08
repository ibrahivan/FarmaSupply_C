using FarmaSupply.Utils;
using System.Security.Cryptography;
using System.Text;

namespace FarmaSupply.Servicios
{
    public class EncriptarServicioImpl:IServicioEncriptar
    {
        public string Encriptar(string contrasenya)
        {
            try
            {
                EscribirLog.escribirEnFicheroLog("[INFO] Entrando en el método Encriptar() de la clase ServicioEncriptarImpl");

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(contrasenya);
                    byte[] hashBytes = sha256.ComputeHash(bytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    EscribirLog.escribirEnFicheroLog("[INFO] Saliendo del método Encriptar() de la clase ServicioEncriptarImpl");
                    return hash;
                }
            }
            catch (ArgumentException e)
            {
                EscribirLog.escribirEnFicheroLog("[Error  ServicioEncriptarImpl - Encriptar()] Error al encriptar: " + e.Message);
                return null;
            }

        }
    }
}
