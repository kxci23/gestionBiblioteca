using GestionBiblioteca.Modelo;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionBiblioteca.Controlador
{
    public class DevolucionControlador
    {
        private readonly ConexionMySQL conexion = new ConexionMySQL();

        // Registrar una devolución en MongoDB y (opcionalmente) en MySQL
        public void RegistrarDevolucion(Devolucion devolucion)
        {
            // Aquí iría la lógica para guardar en MySQL si la tienes (no incluida en el ejemplo original)

            // Guardar en MongoDB
            conexion.InsertarDocumento("devoluciones", devolucion);
        }

        // Obtener todas las devoluciones desde MongoDB
        public IEnumerable<Devolucion> ObtenerDevoluciones()
        {
            return conexion.ObtenerDocumentos<Devolucion>("devoluciones")
                           .OrderByDescending(d => d.FechaDevolucion);
        }

        // Buscar devoluciones por usuario desde MongoDB
        public IEnumerable<Devolucion> BuscarPorUsuario(int idUsuario)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Devolucion>("devoluciones");
            var filtro = Builders<Devolucion>.Filter.Eq(d => d.RecibidoPor, idUsuario);
            return coleccion.Find(filtro).ToList();
        }

        public void RegistrarDevolucionEnMongo(int id, int prestamoId, DateTime fechaDevolucion, string condicionLibro, string observaciones, int recibidoPor)
        {
            var devolucion = new Devolucion
            {
                Id = id,
                PrestamoId = prestamoId,
                FechaDevolucion = fechaDevolucion,
                CondicionLibro = condicionLibro,
                Observaciones = observaciones,
                RecibidoPor = recibidoPor
            };
            conexion.InsertarDocumento("devoluciones", devolucion);
        }
    }
}
