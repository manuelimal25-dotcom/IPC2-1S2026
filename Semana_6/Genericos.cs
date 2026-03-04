// Nodo genérico - puede almacenar CUALQUIER tipo de dato
public class Nodo<T>
{
    private T dato;              // T es un tipo genérico (puede ser int, string, Paciente, etc.)
    private Nodo<T>? siguiente;

    public Nodo(T dato)
    {
        this.dato = dato;
        this.siguiente = null;
    }

    public T GetDato()
    {
        return dato;
    }

    public void SetDato(T dato)
    {
        this.dato = dato;
    }

    public Nodo<T>? GetSiguiente()
    {
        return siguiente;
    }

    public void SetSiguiente(Nodo<T>? siguiente)
    {
        this.siguiente = siguiente;
    }
}

// Lista enlazada genérica - puede almacenar CUALQUIER tipo
public class ListaEnlazada<T>
{
    private Nodo<T>? cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    public void Insertar(T dato)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(dato);
        
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo<T>? actual = cabeza;
            while (actual.GetSiguiente() != null)
            {
                actual = actual.GetSiguiente();
            }
            actual.SetSiguiente(nuevoNodo);
        }
    }

    public void Recorrer()
    {
        Nodo<T>? actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine(actual.GetDato());
            actual = actual.GetSiguiente();
        }
    }
}