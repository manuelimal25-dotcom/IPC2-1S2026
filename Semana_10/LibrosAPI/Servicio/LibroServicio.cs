using System.Text.Json;
using LibrosAPI.Modelo;

namespace LibrosAPI.Servicio
{
    public class LibroServicio
    {
        //Define la ubicación del archivo JSON donde se almacenan los datos de los libros.
        private readonly string rutaArchivo;
        // Configuración para la serialización JSON, como la indentación para mejorar la legibilidad del archivo.
        private readonly JsonSerializerOptions opcionesJson;
        // Constructor que inicializa la ruta del archivo y las opciones de serialización JSON.
        public LibroServicio()
        {
            rutaArchivo = Path.Combine("Data", "Libros.JSON");
            
            opcionesJson = new JsonSerializerOptions
            {
                // Configura la serialización para que el JSON resultante sea legible con indentación.
                WriteIndented = true
            };
        }

        //Retorna la lista completa de libros almacenados en el archivo JSON.
        // Si el archivo no existe o está vacío, retorna una lista vacía.
        public List<Libro> ObtenerTodos()
        {
            if (!File.Exists(rutaArchivo))
                return new List<Libro>();

            string contenido = File.ReadAllText(rutaArchivo);

            if (string.IsNullOrWhiteSpace(contenido))
                return new List<Libro>();

            return JsonSerializer.Deserialize<List<Libro>>(contenido) ?? new List<Libro>();
        }

        // Busca y retorna un libro por su identificador único.
        // Retorna null si no existe ningún libro con ese Id.
        public Libro? ObtenerPorId(string id)
        {
            return ObtenerTodos().FirstOrDefault(libro => libro.Id == id);
        }

        // Agrega un nuevo libro a la colección.
        public Libro Agregar(Libro libro)
        {
            // Se ignora cualquier Id enviado por el cliente para garantizar uno valido en el servidor.
            libro.Id = Guid.NewGuid().ToString();

            List<Libro> libros = ObtenerTodos();
            libros.Add(libro);
            Guardar(libros);
            return libro;
        }

        // Actualiza los datos de un libro existente identificado por su Id.
        // Retorna true si el libro fue actualizado, false si no se encontró el libro.
        public bool Actualizar(string id, Libro libroActualizado)
        {
            List<Libro> libros = ObtenerTodos();
            int indice = libros.FindIndex(libro => libro.Id == id);

            if (indice == -1)
                return false;

            libroActualizado.Id = id;
            libros[indice] = libroActualizado;
            Guardar(libros);
            return true;
        }

        // Elimina un libro de la colección por su Id.
        // Retorna true si fue eliminado, false si el libro no existe.
        public bool Eliminar(string id)
        {
            List<Libro> libros = ObtenerTodos();
            Libro? libroAEliminar = libros.FirstOrDefault(libro => libro.Id == id);

            if (libroAEliminar == null)
                return false;

            libros.Remove(libroAEliminar);
            Guardar(libros);
            return true;
        }

        // Serializa la lista de libros y la escribe en el archivo JSON.
        private void Guardar(List<Libro> libros)
        {
            string contenido = JsonSerializer.Serialize(libros, opcionesJson);
            File.WriteAllText(rutaArchivo, contenido);
        }
    }
}