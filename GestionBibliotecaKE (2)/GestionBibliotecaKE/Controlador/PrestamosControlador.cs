using GestionBiblioteca.Modelo;
using MySql.Data.MySqlClient;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionBiblioteca.Controlador
{
    public class PrestamosControlador
    {
        private readonly ConexionMySQL conexion = new ConexionMySQL();

        public void RegistrarPrestamo(Prestamos prestamo)
        {
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                string query = @"INSERT INTO prestamos (estudiante_id, libro_id, fecha_prestamo, fecha_devolucion, estado)
                                 VALUES (@estudiante_id, @libro_id, @fecha_prestamo, @fecha_devolucion, @estado);";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estudiante_id", prestamo.EstudianteId);
                    cmd.Parameters.AddWithValue("@libro_id", prestamo.LibroId);
                    cmd.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaPrestamo);
                    cmd.Parameters.AddWithValue("@fecha_devolucion", prestamo.FechaDevolucionEsperada);
                    cmd.Parameters.AddWithValue("@estado", prestamo.Estado);
                    cmd.ExecuteNonQuery();
                }
                using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                {
                    var id = Convert.ToInt32(cmdId.ExecuteScalar());
                    prestamo.Id = id;
                }
            }

            // Inserta el préstamo en MongoDB
            conexion.InsertarDocumento("prestamos", prestamo);
        }

        // Obtener todos los préstamos desde MongoDB
        public List<Prestamos> ObtenerTodos()
        {
            return conexion.ObtenerDocumentos<Prestamos>("prestamos");
        }

        // Obtener un préstamo por Id desde MongoDB
        public Prestamos? ObtenerPorId(int id)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Prestamos>("prestamos");
            var filtro = Builders<Prestamos>.Filter.Eq(p => p.Id, id);
            return coleccion.Find(filtro).FirstOrDefault();
        }

        // Actualizar un préstamo en MongoDB
        public bool Actualizar(Prestamos prestamoActualizado)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Prestamos>("prestamos");
            var filtro = Builders<Prestamos>.Filter.Eq(p => p.Id, prestamoActualizado.Id);
            var resultado = coleccion.ReplaceOne(filtro, prestamoActualizado);
            return resultado.ModifiedCount > 0;
        }

        // Eliminar un préstamo en MongoDB
        public bool Eliminar(int id)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Prestamos>("prestamos");
            var filtro = Builders<Prestamos>.Filter.Eq(p => p.Id, id);
            var resultado = coleccion.DeleteOne(filtro);
            return resultado.DeletedCount > 0;
        }

        public void CrearPrestamo(int idEstudiante, int idLibro, DateTime fechaDevolucion)
        {
            int idPrestamoGenerado;
            // Insertar en MySQL
            using (var conn = conexion.ObtenerConexionMySQL())
            {
                conn.Open();
                string query = @"INSERT INTO prestamos (estudiante_id, libro_id, fecha_prestamo, fecha_devolucion, estado)
                                 VALUES (@estudiante_id, @libro_id, NOW(), @fecha_devolucion, 'activo');";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estudiante_id", idEstudiante);
                    cmd.Parameters.AddWithValue("@libro_id", idLibro);
                    cmd.Parameters.AddWithValue("@fecha_devolucion", fechaDevolucion);
                    cmd.ExecuteNonQuery();
                }
                using (var cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                {
                    idPrestamoGenerado = Convert.ToInt32(cmdId.ExecuteScalar());
                }
            }

            // Insertar en MongoDB
            var prestamoMongo = new Prestamos
            {
                Id = idPrestamoGenerado,
                EstudianteId = idEstudiante, // Cambiado de UsuarioId a EstudianteId
                LibroId = idLibro,
                FechaPrestamo = DateTime.Now,
                FechaDevolucionEsperada = fechaDevolucion, // Cambiado para coincidir con la propiedad correcta
                Estado = "activo"
            };
            conexion.InsertarDocumento("prestamos", prestamoMongo);
        }
    }
}