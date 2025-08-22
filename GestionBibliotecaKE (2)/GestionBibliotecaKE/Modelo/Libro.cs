using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GestionBiblioteca.Modelo
{
    public class Libro
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        public string Titulo { get; set; } = "";
        public string Autor { get; set; } = "";
        public string Isbn { get; set; } = "";
        public int TotalPaginas { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }
    }
}
