using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GestionBiblioteca.Controlador
{
    internal class RespaldoControlador
    {
        private readonly ConexionMySQL conexion = new ConexionMySQL();

        // Realiza un respaldo de una colección de objetos a un archivo JSON y a MongoDB
        public void RealizarRespaldo<T>(IEnumerable<T> datos, string rutaArchivo, string nombreColeccion)
        {
            // Respaldo en archivo JSON
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(datos, opciones);
            File.WriteAllText(rutaArchivo, json);

            // Respaldo en MongoDB
            foreach (var item in datos)
            {
                conexion.InsertarDocumento(nombreColeccion, item);
            }
        }

        // Restaura una colección de objetos desde un archivo JSON
        public List<T> RestaurarRespaldo<T>(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("El archivo de respaldo no existe.", rutaArchivo);

            string json = File.ReadAllText(rutaArchivo);
            var datos = JsonSerializer.Deserialize<List<T>>(json);
            return datos ?? new List<T>();
        }

        // Puedes hacer lo mismo para restaurar desde MongoDB si lo deseas
    }
}
