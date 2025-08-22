using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GestionBiblioteca.Modelo
{
    public class Sesion
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int UsuarioId { get; set; }
        public string IpOrigen { get; set; } = "";
        public DateTime CreadoEn { get; set; }
        public bool Activo { get; set; }
    }
}