using GestionBiblioteca.Modelo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionBiblioteca.Controlador
{
    public class LibroControlador
    {
        private readonly ConexionMySQL conexion = new ConexionMySQL();

        // Obtener todos los libros desde MongoDB
        public IEnumerable<Libro> ObtenerTodos()
        {
            return conexion.ObtenerDocumentos<Libro>("libros");
        }

        // Obtener un libro por Id desde MongoDB
        public Libro? ObtenerPorId(int id)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Libro>("libros");
            var filtro = Builders<Libro>.Filter.Eq(l => l.Id, id);
            return coleccion.Find(filtro).FirstOrDefault();
        }

        // Agregar un libro en MongoDB
        public void Agregar(Libro libro)
        {
            // Si el Id es 0, no lo asignes como _id en MongoDB
            if (libro.Id == 0)
            {
                // Crea un nuevo libro sin el campo Id para que MongoDB asigne el _id automáticamente
                var libroSinId = new
                {
                    libro.Titulo,
                    libro.Autor,
                    libro.Isbn,
                    libro.TotalPaginas,
                    libro.Stock,
                    libro.CategoriaId,
                    libro.EstadoId
                };
                conexion.ObtenerColeccionMongo<dynamic>("libros").InsertOne(libroSinId);
            }
            else
            {
                // Si el Id es válido, úsalo como _id
                // 1. Insertar el libro en MySQL y obtener el Id generado
                int idGenerado = InsertarLibroEnMySQL(libro); // Este método debe devolver el Id autoincremental

                // 2. Asignar el Id al objeto libro
                libro.Id = idGenerado;

                // 3. Insertar el libro en MongoDB con el Id correcto
                conexion.InsertarDocumento("libros", libro);
            }
        }

        // Actualizar un libro en MongoDB
        public bool Actualizar(Libro libroActualizado)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Libro>("libros");
            var filtro = Builders<Libro>.Filter.Eq(l => l.Id, libroActualizado.Id);
            var resultado = coleccion.ReplaceOne(filtro, libroActualizado);
            return resultado.ModifiedCount > 0;
        }

        // Eliminar un libro en MongoDB
        public bool Eliminar(int id)
        {
            var coleccion = conexion.ObtenerColeccionMongo<Libro>("libros");
            var filtro = Builders<Libro>.Filter.Eq(l => l.Id, id);
            var resultado = coleccion.DeleteOne(filtro);
            return resultado.DeletedCount > 0;
        }

        // Método para insertar el libro en MySQL y obtener el Id generado
        private int InsertarLibroEnMySQL(Libro libro)
        {
            // Lógica para insertar el libro en la base de datos MySQL y devolver el Id autoincremental
            // Aquí debes implementar el código necesario para realizar la inserción en MySQL
            // y retornar el Id generado.
            throw new NotImplementedException("Este método debe ser implementado para insertar en MySQL");
        }
    }
}
