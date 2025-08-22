using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBiblioteca.Modelo
{
    internal class LogAuditoria
    {
        public long Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? LibroId { get; set; }
        public string AccionTipo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public string IpOrigen { get; set; }
    }
}
