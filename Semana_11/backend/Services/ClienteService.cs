using backend.Data;
using backend.Models;
using System.Text.RegularExpressions;

namespace backend.Services
{
    public class ClienteServicio
    {
        private readonly XmlDatabase BaseDatos;

        public ClienteServicio(XmlDatabase database)
        {
            BaseDatos = database;
        }

        public List<Cliente> ObtenerTodos()
        {
            return BaseDatos.Leer().Clientes;
        }

        public Cliente? ObtenerPorNit(string nit)
        {
            // Busca el cliente con el NIT especificado en la base de datos y lo devuelve, o null si no se encuentra
            return ObtenerTodos().FirstOrDefault(c => c.NIT == nit);
        }

        public (int creados, int actualizados) GuardarClientes(List<Cliente> clientesNuevos)
        {
            BaseDeDatos bd = BaseDatos.Leer();
            int creados = 0;
            int actualizados = 0;

            foreach (Cliente clienteNuevo in clientesNuevos)
            {
                // Valida que el NIT solo contenga caracteres numéricos y guiones, si no es válido se omite el cliente
                if (!ValidarNit(clienteNuevo.NIT))
                    continue;

                int indice = bd.Clientes.FindIndex(c => c.NIT == clienteNuevo.NIT);

                if (indice == -1)
                {
                    bd.Clientes.Add(clienteNuevo);
                    creados++;
                }
                else
                {
                    bd.Clientes[indice].Nombre = clienteNuevo.Nombre;
                    actualizados++;
                }
            }

            BaseDatos.Guardar(bd);
            return (creados, actualizados);
        }

        private bool ValidarNit(string nit)
        {
            // Valida que el NIT solo contenga caracteres numéricos y guiones
            return Regex.IsMatch(nit, @"^[a-zA-Z0-9\-]+$");
        }
    }
}