namespace FarmaSupply.Utils
{   /// <summary>
    /// Clase para FicherosLog
    /// </summary>
    public class EscribirLog
    {
        /// <summary>
        /// Metodo de escritirua en fichero log
        /// </summary>
        /// <param name="mensajeLog"></param>
        public static void escribirEnFicheroLog(string mensajeLog)
        {
            try
            {
                using (FileStream fs = new FileStream(@AppDomain.CurrentDomain.BaseDirectory + "farmasupply.log", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter m_streamWriter = new StreamWriter(fs))
                    {
                        m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                        // Quitar posibles saltos de línea del mensaje
                        mensajeLog = mensajeLog.Replace(Environment.NewLine, " | ");
                        mensajeLog = mensajeLog.Replace("\r\n", " | ").Replace("\n", " | ").Replace("\r", " | ");
                        m_streamWriter.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " " + mensajeLog);
                        m_streamWriter.Flush();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[Error EscribirLog - escribirEnFicheroLog()] Error al escribir en el fichero log:" + e.Message);
            }
        }
    }
}

