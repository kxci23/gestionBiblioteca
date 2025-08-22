using GestionBiblioteca.Modelo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionBiblioteca.Controlador
{
    public class ReporteControlador
    {
        private readonly ConexionMySQL conexion = new ConexionMySQL();

        // Reporte de préstamos por usuario desde MongoDB
        public IEnumerable<Prestamos> ObtenerPrestamosPorUsuario(int idUsuario)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Prestamos>("prestamos");
            var filtro = Builders<Prestamos>.Filter.Eq(p => p.EstudianteId , idUsuario); // Cambiado UsuarioId a EstudianteId
            return coleccion.Find(filtro).ToList();
        }

        // Reporte de devoluciones por usuario desde MongoDB
        public IEnumerable<Devolucion> ObtenerDevolucionesPorUsuario(int idUsuario)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Devolucion>("devoluciones");
            var filtro = Builders<Devolucion>.Filter.Eq(d => d.RecibidoPor, idUsuario);
            return coleccion.Find(filtro).ToList();
        }

        // Reporte de préstamos activos (no devueltos) desde MongoDB
        public IEnumerable<Prestamos> ObtenerPrestamosActivos()
        {
            var coleccion = conexion.ObtenerColeccionMongo<Prestamos>("prestamos");
            var filtro = Builders<Prestamos>.Filter.Eq(p => p.Estado, "activo");
            return coleccion.Find(filtro).ToList();
        }
    }
}
