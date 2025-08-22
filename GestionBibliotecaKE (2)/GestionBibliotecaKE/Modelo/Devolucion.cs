using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GestionBiblioteca.Modelo
{
    public class Devolucion
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        public int PrestamoId { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string CondicionLibro { get; set; } = "";
        public string Observaciones { get; set; } = "";
        public int RecibidoPor { get; set; }
    }
}
