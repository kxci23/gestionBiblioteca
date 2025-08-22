using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GestionBiblioteca.Modelo
{
    public class Prestamos
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        public int SolicitudId { get; set; }
        public int EstudianteId { get; set; }
        public int LibroId { get; set; }
        public int BibliotecarioId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public string Estado { get; set; } = "";
    }
}
