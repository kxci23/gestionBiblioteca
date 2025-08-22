using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class SolicitudPrestamo
{
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }
    public int EstudianteId { get; set; }
    public int LibroId { get; set; }
    public DateTime FechaSolicitud { get; set; }
    public string Estado { get; set; }
    public int? AprobadoPor { get; set; }
  
}
