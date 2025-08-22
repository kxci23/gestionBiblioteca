using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GestionBiblioteca.Modelo
{
    public class SesionActiva
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
