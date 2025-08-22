using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GestionBiblioteca.Modelo
{
    public class Rol
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        public string Nombre { get; set; } = "";
    }
}
