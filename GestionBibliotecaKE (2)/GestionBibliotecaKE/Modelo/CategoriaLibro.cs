using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GestionBiblioteca.Modelo
{
    public class CategoriaLibro
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }

        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";

        public override string ToString() => Nombre;
    }
}
