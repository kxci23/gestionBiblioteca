using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GestionBiblioteca.Modelo
{
    public class LibroEstado
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? IdMongo { get; set; } // Id para MongoDB

        public int Id { get; set; } // Id para MySQL
        public int Estado { get; set; } // 0 = prestado, 1 = disponible
       
    }
}
