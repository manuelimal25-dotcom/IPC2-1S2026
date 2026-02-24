namespace Semana_5.Grafica
{
    // Genera imágenes PNG a partir de archivos DOT usando Graphviz
    public class GeneradorGrafica
    {
        // Convierte un archivo .dot en una imagen .png utilizando el comando 'dot' de Graphviz
        public void GenerarGrafica(string rutaArchivoDot)
        {
            try
            {
                // Cambiar extensión .dot por .png para el archivo de salida
                string rutaImagenSalida = rutaArchivoDot.Replace(".dot", ".png");

                // ProcessStartInfo: Configura cómo se ejecutará un proceso externo (en este caso, el comando 'dot')
                System.Diagnostics.ProcessStartInfo informacionProceso = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "dot",  // Ejecutable a lanzar (debe estar en PATH)
                    Arguments = $"-Tpng {rutaArchivoDot} -o {rutaImagenSalida}",  // Parámetros: formato PNG, archivo entrada y salida
                    UseShellExecute = false,  // Ejecutar directamente sin usar una consola
                    CreateNoWindow = true  // No mostrar ventana de consola al ejecutar
                };
                
                // Process.Start: Inicia el proceso configurado y lo ejecuta
                System.Diagnostics.Process? proceso = System.Diagnostics.Process.Start(informacionProceso);
                
                // WaitForExit: Espera a que el proceso termine antes de continuar
                proceso?.WaitForExit();
                
                Console.WriteLine($"Imagen generada exitosamente en: {rutaImagenSalida}");
            }
            catch (Exception excepcion)
            {
                Console.WriteLine($"Error al generar la imagen: {excepcion.Message}");
            }
        }
    }
}