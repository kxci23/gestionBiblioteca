using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace GestionBiblioteca.Modelo
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int IdUsuario { get; set; }

        public string NombreCompleto { get; set; } = "";
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public int RolId { get; set; }
        public string RolNombre { get; set; } = "";
        public bool Activo { get; set; }
    }
}