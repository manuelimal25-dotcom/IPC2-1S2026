namespace Semana_7
{
    // PILA: LIFO (Last In, First Out) - El último que entra es el primero que sale
    public class PilaLibros
    {
        private NodoLibro? tope;  // Apunta al elemento superior de la pila

        public PilaLibros()
        {
            tope = null;
        }

        // PUSH: Agregar un libro al tope de la pila
        public void Push(Libro libro)
        {
            NodoLibro nuevoNodo = new NodoLibro(libro);
            nuevoNodo.SetSiguiente(tope);  // El nuevo nodo apunta al tope actual
            tope = nuevoNodo;              // El nuevo nodo se convierte en el tope
        }

        // POP: Eliminar y retornar el libro del tope de la pila
        public Libro? Pop()
        {
            if (tope == null)
            {
                Console.WriteLine("La pila está vacía. No se puede hacer POP.");
                return null;  // Pila vacía
            }

            Libro libroRemovido = tope.GetDato();
            tope = tope.GetSiguiente();  // El tope ahora es el siguiente nodo
            return libroRemovido;
        }

        // PEEK: Ver el libro del tope sin eliminarlo
        public Libro? Peek()
        {
            if (tope == null)
            {
                Console.WriteLine("La pila está vacía. No se puede hacer PEEK.");
                return null;
            }

            return tope.GetDato();
        }


        // Obtener todos los libros como string
        public string ObtenerLibros()
        {
            if (tope == null)
            {
                return "Pila vacía";
            }

            string resultado = "PILA DE LIBROS\n";
            resultado += "--------------------------------------\n";
            
            NodoLibro? actual = tope;
            int posicion = 1;

            while (actual != null)
            {
                resultado += $"{posicion}. {actual.GetDato().ToString()}\n";
                actual = actual.GetSiguiente();
                posicion++;
            }
            
            resultado += "--------------------------------------";
            return resultado;
        }
    }
}