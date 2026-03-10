namespace Semana_7
{
    // COLA: FIFO (First In, First Out) - El primero que entra es el primero que sale
    public class ColaPersonas
    {
        private NodoPersona? frente;  // Apunta al primer elemento
        private NodoPersona? final;   // Apunta al último elemento

        public ColaPersonas()
        {
            frente = null;
            final = null;
        }

        // ENQUEUE: Agregar una persona al final de la cola
        public void Enqueue(Persona persona)
        {
            NodoPersona nuevoNodo = new NodoPersona(persona);

            if (final == null)  // Cola vacía
            {
                frente = nuevoNodo;
                final = nuevoNodo;
            }
            else
            {
                final.SetSiguiente(nuevoNodo);  // El último apunta al nuevo
                final = nuevoNodo;              // El nuevo se convierte en el último
            }
        }

        // DEQUEUE: Eliminar y retornar la persona del frente de la cola
        public Persona? Dequeue()
        {
            if (frente == null)
            {
                Console.WriteLine("La cola está vacía. No se puede hacer DEQUEUE.");
                return null;
            }

            Persona personaRemovida = frente.GetDato();
            frente = frente.GetSiguiente();  // El frente ahora es el siguiente

            if (frente == null)  // Si la cola quedó vacía
            {
                final = null;
            }

            return personaRemovida;
        }

        // PEEK: Ver la persona del frente sin eliminarla
        public Persona? Peek()
        {
            if (frente == null)
            {
                Console.WriteLine("La cola está vacía. No se puede hacer PEEK.");
                return null;
            }

            return frente.GetDato();
        }

        // Obtener todas las personas como string
        public string ObtenerPersonas()
        {
            if (frente == null)
            {
                return "Cola vacía";
            }

            string resultado = "";
            NodoPersona? actual = frente;

            while (actual != null)
            {
                resultado += actual.GetDato().ToString() + "\n";
                actual = actual.GetSiguiente();
            }

            return resultado;
        }
    }
}