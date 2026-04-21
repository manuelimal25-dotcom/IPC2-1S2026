using backend.Data;
using backend.Models;

namespace backend.Services
{
    public class BancoServicio
    {
        private readonly XmlDatabase BaseDatos;

        public BancoServicio(XmlDatabase database)
        {
            BaseDatos = database;
        }

        public List<Banco> ObtenerTodos()
        {
            return BaseDatos.Leer().Bancos;
        }

        public Banco? ObtenerPorCodigo(int codigo)
        {
            return ObtenerTodos().FirstOrDefault(b => b.Codigo == codigo);
        }

        public (int creados, int actualizados) GuardarBancos(List<Banco> bancosNuevos)
        {
            BaseDeDatos bd = BaseDatos.Leer();
            int creados = 0;
            int actualizados = 0;

            foreach (Banco bancoNuevo in bancosNuevos)
            {
                int indice = bd.Bancos.FindIndex(b => b.Codigo == bancoNuevo.Codigo);

                if (indice == -1)
                {
                    bd.Bancos.Add(bancoNuevo);
                    creados++;
                }
                else
                {
                    bd.Bancos[indice].Nombre = bancoNuevo.Nombre;
                    actualizados++;
                }
            }

            BaseDatos.Guardar(bd);
            return (creados, actualizados);
        }
    }
}